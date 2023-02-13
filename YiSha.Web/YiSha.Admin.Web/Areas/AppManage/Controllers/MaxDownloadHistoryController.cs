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
    /// 日 期：2023-02-09 19:20
    /// 描 述：Max软件下载记录表控制器类
    /// </summary>
    [Area("AppManage")]
    public class MaxDownloadHistoryController :  BaseController
    {
        private MaxDownloadHistoryBLL maxDownloadHistoryBLL = new MaxDownloadHistoryBLL();

        #region 视图功能
        [AuthorizeFilter("app:maxdownloadhistory:view")]
        public ActionResult MaxDownloadHistoryIndex()
        {
            return View();
        }

        public ActionResult MaxDownloadHistoryForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:maxdownloadhistory:search")]
        public async Task<ActionResult> GetListJson(MaxDownloadHistoryListParam param)
        {
            TData<List<MaxDownloadHistoryEntity>> obj = await maxDownloadHistoryBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:maxdownloadhistory:search")]
        public async Task<ActionResult> GetPageListJson(MaxDownloadHistoryListParam param, Pagination pagination)
        {
            TData<List<MaxDownloadHistoryEntity>> obj = await maxDownloadHistoryBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<MaxDownloadHistoryEntity> obj = await maxDownloadHistoryBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:maxdownloadhistory:add,app:maxdownloadhistory:edit")]
        public async Task<ActionResult> SaveFormJson(MaxDownloadHistoryEntity entity)
        {
            TData<string> obj = await maxDownloadHistoryBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:maxdownloadhistory:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await maxDownloadHistoryBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
