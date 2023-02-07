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
    /// 日 期：2023-02-04 15:15
    /// 描 述：用户操作历史-业务控制器类
    /// </summary>
    [Area("AppManage")]
    public class AppsOperationHistoryController :  BaseController
    {
        private AppsOperationHistoryBLL appsOperationHistoryBLL = new AppsOperationHistoryBLL();

        #region 视图功能
        [AuthorizeFilter("app:appsoperationhistory:view")]
        public ActionResult AppsOperationHistoryIndex()
        {
            return View();
        }

        public ActionResult AppsOperationHistoryForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:appsoperationhistory:search")]
        public async Task<ActionResult> GetListJson(AppsOperationHistoryListParam param)
        {
            TData<List<AppsOperationHistoryEntity>> obj = await appsOperationHistoryBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:appsoperationhistory:search")]
        public async Task<ActionResult> GetPageListJson(AppsOperationHistoryListParam param, Pagination pagination)
        {
            TData<List<AppsOperationHistoryEntity>> obj = await appsOperationHistoryBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<AppsOperationHistoryEntity> obj = await appsOperationHistoryBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:appsoperationhistory:add,app:appsoperationhistory:edit")]
        public async Task<ActionResult> SaveFormJson(AppsOperationHistoryEntity entity)
        {
            TData<string> obj = await appsOperationHistoryBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:appsoperationhistory:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await appsOperationHistoryBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
