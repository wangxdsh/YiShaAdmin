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
    /// 日 期：2023-02-12 02:42
    /// 描 述：Max软件浏览历史表控制器类
    /// </summary>
    [Area("AppManage")]
    public class MaxContentViewHistoryController :  BaseController
    {
        private MaxContentViewHistoryBLL maxContentViewHistoryBLL = new MaxContentViewHistoryBLL();

        #region 视图功能
        [AuthorizeFilter("app:maxcontentviewhistory:view")]
        public ActionResult MaxContentViewHistoryIndex()
        {
            return View();
        }

        public ActionResult MaxContentViewHistoryForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:maxcontentviewhistory:search")]
        public async Task<ActionResult> GetListJson(MaxContentViewHistoryListParam param)
        {
            TData<List<MaxContentViewHistoryEntity>> obj = await maxContentViewHistoryBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:maxcontentviewhistory:search")]
        public async Task<ActionResult> GetPageListJson(MaxContentViewHistoryListParam param, Pagination pagination)
        {
            TData<List<MaxContentViewHistoryEntity>> obj = await maxContentViewHistoryBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<MaxContentViewHistoryEntity> obj = await maxContentViewHistoryBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:maxcontentviewhistory:add,app:maxcontentviewhistory:edit")]
        public async Task<ActionResult> SaveFormJson(MaxContentViewHistoryEntity entity)
        {
            TData<string> obj = await maxContentViewHistoryBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:maxcontentviewhistory:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await maxContentViewHistoryBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
