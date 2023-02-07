using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using YiSha.Util;
using YiSha.Util.Model;
using YiSha.Entity;
using YiSha.Model;
using YiSha.Admin.Web.Controllers;
using YiSha.Entity.AppManage;
using YiSha.Business.AppManage;
using YiSha.Model.Param.AppManage;

namespace YiSha.Admin.Web.Areas.AppManage.Controllers
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-04 15:12
    /// 描 述：api授权控制器类
    /// </summary>
    [Area("AppManage")]
    public class MaxWebApiAuthorizeController :  BaseController
    {
        private MaxWebApiAuthorizeBLL maxWebApiAuthorizeBLL = new MaxWebApiAuthorizeBLL();

        #region 视图功能
        [AuthorizeFilter("app:maxwebapiauthorize:view")]
        public ActionResult MaxWebApiAuthorizeIndex()
        {
            return View();
        }

        public ActionResult MaxWebApiAuthorizeForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:maxwebapiauthorize:search")]
        public async Task<ActionResult> GetListJson(MaxWebApiAuthorizeListParam param)
        {
            TData<List<MaxWebApiAuthorizeEntity>> obj = await maxWebApiAuthorizeBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:maxwebapiauthorize:search")]
        public async Task<ActionResult> GetPageListJson(MaxWebApiAuthorizeListParam param, Pagination pagination)
        {
            TData<List<MaxWebApiAuthorizeEntity>> obj = await maxWebApiAuthorizeBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<MaxWebApiAuthorizeEntity> obj = await maxWebApiAuthorizeBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:maxwebapiauthorize:add,app:maxwebapiauthorize:edit")]
        public async Task<ActionResult> SaveFormJson(MaxWebApiAuthorizeEntity entity)
        {
            TData<string> obj = await maxWebApiAuthorizeBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:maxwebapiauthorize:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await maxWebApiAuthorizeBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
