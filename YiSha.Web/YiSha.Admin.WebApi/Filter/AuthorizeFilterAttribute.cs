using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using YiSha.Business.SystemManage;
using YiSha.Entity.SystemManage;
using YiSha.Enum;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Web.Code;
using YiSha.Business.OrganizationManage;
using YiSha.Entity.OrganizationManage;
using YiSha.Model.Result;

namespace YiSha.Admin.WebApi.Controllers
{
    /// <summary>
    /// 验证token和记录日志
    /// </summary>
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {
        public AuthorizeFilterAttribute() { }

        public AuthorizeFilterAttribute(string authorize)
        {
            this.Authorize = authorize;
        }

        /// <summary>
        /// 权限字符串，例如 organization:user:view
        /// </summary>
        public string Authorize { get; set; }

        /// <summary>
        /// 忽略token的方法
        /// </summary>
        public static readonly string[] IgnoreToken = { "GetWxOpenId", "Login", "LoginOff" };

        /// <summary>
        /// 异步接口日志，调用接口时，校验token，校验失败重新登录
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool hasPermission = false;
            //var resultContext = new ;

            string token = context.HttpContext.Request.Headers["ApiToken"].ParseToString();

            OperatorInfo user = await Operator.Instance.Current(token);
            if (user != null)// 缓存里有用户，就继续判断权限
            {
                #region 看不懂，注释掉不用了
                //// 根据传入的Token，设置CustomerId
                //if (context.ActionArguments != null && context.ActionArguments.Count > 0)
                //{
                //    PropertyInfo property = context.ActionArguments.FirstOrDefault().Value.GetType().GetProperty("Token");
                //    if (property != null)
                //    {
                //        property.SetValue(context.ActionArguments.FirstOrDefault().Value, token, null);
                //    }
                //    switch (context.HttpContext.Request.Method.ToUpper())
                //    {
                //        case "GET":
                //            break;

                //        case "POST":
                //            property = context.ActionArguments.FirstOrDefault().Value.GetType().GetProperty("CustomerId");
                //            if (property != null)
                //            {
                //                property.SetValue(context.ActionArguments.FirstOrDefault().Value, user.UserId, null);
                //            }
                //            break;
                //    }
                //}
                #endregion
                // 权限判断
                if (!string.IsNullOrEmpty(Authorize))
                {
                    string[] authorizeList = Authorize.Split(',');
                    TData<List<MenuAuthorizeInfo>> objMenuAuthorize = await new MenuAuthorizeBLL().GetAuthorizeList(user);
                    List<MenuAuthorizeInfo> authorizeInfoList = objMenuAuthorize.Data.Where(p => authorizeList.Contains(p.Authorize)).ToList();
                    if (authorizeInfoList.Any())
                    {
                        hasPermission = true;

                        #region  新增和修改判断
                        if (context.RouteData.Values["Action"].ToString() == "SaveFormJson")
                        {
                            var id = context.HttpContext.Request.Form["Id"];
                            if (id.ParseToLong() > 0)
                            {
                                if (!authorizeInfoList.Where(p => p.Authorize.Contains("edit")).Any())
                                {
                                    hasPermission = false;
                                }
                            }
                            else
                            {
                                if (!authorizeInfoList.Where(p => p.Authorize.Contains("add")).Any())
                                {
                                    hasPermission = false;
                                }
                            }
                        }
                        #endregion
                    }
                    if (!hasPermission)
                    {
                        if (context.HttpContext.Request.IsAjaxRequest())
                        {
                            TData obj = new TData();
                            obj.Message = "抱歉，没有权限";
                            context.Result = new JsonResult(obj);
                        }
                        else
                        {
                            context.Result = new RedirectResult("~/Home/NoPermission");
                        }
                    }
                }
            }
            else
            {
                TData obj = new TData();
                obj.Message = "先去登录！";
                obj.Tag = 0;
                context.Result = new JsonResult(obj);
            }
            if (hasPermission)
            {
                var resultContext = await next();
            }

            sw.Stop();

            #region 保存日志
            LogApiEntity logApiEntity = new LogApiEntity();
            logApiEntity.ExecuteUrl = context.HttpContext.Request.Path;
            logApiEntity.LogStatus = OperateStatusEnum.Success.ParseToInt();

            #region 获取Post参数
            switch (context.HttpContext.Request.Method.ToUpper())
            {
                case "GET":
                    logApiEntity.ExecuteParam = context.HttpContext.Request.QueryString.Value.ParseToString();
                    break;

                case "POST":
                    if (context.ActionArguments?.Count > 0)
                    {
                        logApiEntity.ExecuteUrl += context.HttpContext.Request.QueryString.Value.ParseToString();
                        logApiEntity.ExecuteParam = TextHelper.GetSubString(JsonConvert.SerializeObject(context.ActionArguments), 4000);
                    }
                    else
                    {
                        logApiEntity.ExecuteParam = context.HttpContext.Request.QueryString.Value.ParseToString();
                    }
                    break;
            }
            #endregion

            //if (resultContext.Exception != null)
            //{
            //    #region 异常获取
            //    StringBuilder sbException = new StringBuilder();
            //    Exception exception = resultContext.Exception;
            //    sbException.AppendLine(exception.Message);
            //    while (exception.InnerException != null)
            //    {
            //        sbException.AppendLine(exception.InnerException.Message);
            //        exception = exception.InnerException;
            //    }
            //    sbException.AppendLine(TextHelper.GetSubString(resultContext.Exception.StackTrace, 8000));
            //    #endregion

            //    logApiEntity.ExecuteResult = sbException.ToString();
            //    logApiEntity.LogStatus = OperateStatusEnum.Fail.ParseToInt();
            //}
            //else
            //{
            //    ObjectResult result = context.Result as ObjectResult;
            //    if (result != null)
            //    {
            //        logApiEntity.ExecuteResult = JsonConvert.SerializeObject(result.Value);
            //        logApiEntity.LogStatus = OperateStatusEnum.Success.ParseToInt();
            //    }
            //}
            if (user != null)
            {
                logApiEntity.BaseCreatorId = user.UserId;
            }
            logApiEntity.ExecuteParam = TextHelper.GetSubString(logApiEntity.ExecuteParam, 4000);
            logApiEntity.ExecuteResult = TextHelper.GetSubString(logApiEntity.ExecuteResult, 4000);
            logApiEntity.ExecuteTime = sw.ElapsedMilliseconds.ParseToInt();

            Action taskAction = async () =>
             {
                 // 让底层不用获取HttpContext
                 logApiEntity.BaseCreatorId = logApiEntity.BaseCreatorId ?? 0;

                 await new LogApiBLL().SaveForm(logApiEntity);
             };
            AsyncTaskHelper.StartTask(taskAction);
            #endregion
        }
    }
}
