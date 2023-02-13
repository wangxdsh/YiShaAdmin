using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YiSha.Business.AppManage;
using YiSha.Business.OrganizationManage;
using YiSha.Entity.AppManage;
using YiSha.Model.Param.AppManage;
using YiSha.Util;
using YiSha.Util.Model;
using YiSha.Entity.OrganizationManage;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YiSha.Admin.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaxRightsController : Controller
    {
        private MaxRightsBLL maxRightsBLL = new MaxRightsBLL();
        private MaxUserRightsBLL maxUserRightsBLL = new MaxUserRightsBLL();
        private UserBLL userBLL = new UserBLL();
        MaxShareCostBLL maxShareCostBLL = new MaxShareCostBLL();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        // 1. 分享接收
        [HttpGet("{sUserId}")]
        public async Task<TData<int>> GetShare(string sUserId)
        {
            TData<int> obj = new TData<int>();
            string gToken =  HttpContext.Request.Headers["ApiToken"];
            if(!string.IsNullOrEmpty(gToken) && !string.IsNullOrEmpty(sUserId))
            {
                TData<UserEntity> suser = await userBLL.GetEntity(long.Parse(sUserId));
                TData<UserEntity> guser = await userBLL.GetUserByToken(gToken);
                if(suser.Data != null && guser != null)
                {
                    MaxShareCostEntity maxShareCostEntity = new MaxShareCostEntity()
                    {
                        GUserId = guser.Data.Id,
                        SUserId = suser.Data.Id
                    };
                    await maxShareCostBLL.SaveForm(maxShareCostEntity);
                    MaxUserRightsEntity maxRightsEntity = new MaxUserRightsEntity()
                    {
                        UserId = suser.Data.Id,
                        RightsName = "分享次卡",
                        ValidTimeLength = 999,
                        DailyTimes = 1,
                        Source = 1,
                        StartTime = DateTime.Today,
                        EndTime = DateTime.Now.AddYears(30)
                    };
                    TData<string> resId = await maxUserRightsBLL.SaveForm(maxRightsEntity);
                    obj.Data = string.IsNullOrEmpty(resId.Data) ? 0 : 1;
                    obj.Message = obj.Data == 1 ? "分享接收成功":"数据操作失败";
                }
                obj.Tag = 1;
            }
            else
            {
                obj.Message = "请登录";
                obj.Tag = 0;
            }
            return obj;
        }
        // 2. 获取可用次数，动态计算
        [HttpGet]
        public async Task<TData<int>> GetRightsCount()
        {
            TData<int> obj = new TData<int>();
            string ApiToken = HttpContext.Request.Headers["ApiToken"];
            if (!string.IsNullOrEmpty(ApiToken))
            {
                TData<UserEntity> user = await userBLL.GetUserByToken(ApiToken);
                if(user.Data != null)
                {
                    obj = await maxRightsBLL.GetRightsCount((long)user.Data.Id);
                }
                else
                {
                    obj.Data = 0;
                    obj.Tag = 0;
                    obj.Message = "没找到用户";
                }
            }
            else
            {
                obj.Message = "请登录";
                obj.Tag = 0;
            }
            return obj; 
        }
        // 3. 
        // 4. 权益记录，来源，已过期等
        [HttpGet]
        public async Task<TData<List<MaxUserRightsEntity>>> GetRightsList()
        {
            TData<List<MaxUserRightsEntity>> obj = new TData<List<MaxUserRightsEntity>>();
            string ApiToken = HttpContext.Request.Headers["ApiToken"];
            if (!string.IsNullOrEmpty(ApiToken))
            {
                TData<UserEntity> user = await userBLL.GetUserByToken(ApiToken);
                if (user.Data != null)
                {
                    obj = await maxUserRightsBLL.GetList(new MaxUserRightsListParam()
                    {
                        UserId = user.Data.Id
                    });
                }
                else
                {
                    obj.Tag = 0;
                    obj.Message = "没找到用户";
                }
            }
            else
            {
                obj.Message = "请登录";
                obj.Tag = 0;
            }
            return obj;
        }
        // 5. 系统权益
    }
}

