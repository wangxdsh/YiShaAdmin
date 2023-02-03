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
using YiSha.Business.OrganizationManage;

namespace YiSha.Admin.Web.Areas.AppManage.Controllers
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-03 19:25
    /// 描 述：应用管理控制器类
    /// </summary>
    [Area("AppManage")]
    public class MaxAppsController :  BaseController
    {
        private MaxAppsBLL maxAppsBLL = new MaxAppsBLL();

        #region 视图功能
        [AuthorizeFilter("app:maxapps:view")]
        public ActionResult MaxAppsIndex()
        {
            return View();
        }

        public ActionResult MaxAppsForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:maxapps:search")]
        public async Task<ActionResult> GetListJson(MaxAppsListParam param)
        {
            TData<List<MaxAppsEntity>> obj = await maxAppsBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:maxapps:search")]
        public async Task<ActionResult> GetPageListJson(MaxAppsListParam param, Pagination pagination)
        {
            TData<List<MaxAppsEntity>> obj = await maxAppsBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<MaxAppsEntity> obj = await maxAppsBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:maxapps:add,app:maxapps:edit")]
        public async Task<ActionResult> SaveFormJson(MaxAppsEntity entity)
        {
            TData<string> obj = await maxAppsBLL.SaveForm(entity);
            return Json(obj);
        }
        [HttpGet]
        public async Task<IActionResult> GetMaxSortJson()
        {
            TData<int> obj = await maxAppsBLL.GetMaxSort();
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:maxapps:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await maxAppsBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
