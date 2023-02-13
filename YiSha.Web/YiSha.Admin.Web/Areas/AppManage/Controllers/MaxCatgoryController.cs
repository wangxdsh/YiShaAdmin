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
    /// 日 期：2023-02-09 19:22
    /// 描 述：Max软件分类表控制器类
    /// </summary>
    [Area("AppManage")]
    public class MaxCatgoryController :  BaseController
    {
        private MaxCatgoryBLL maxCatgoryBLL = new MaxCatgoryBLL();

        #region 视图功能
        [AuthorizeFilter("app:maxcatgory:view")]
        public ActionResult MaxCatgoryIndex()
        {
            return View();
        }

        public ActionResult MaxCatgoryForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:maxcatgory:search")]
        public async Task<ActionResult> GetListJson(MaxCatgoryListParam param)
        {
            TData<List<MaxCatgoryEntity>> obj = await maxCatgoryBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:maxcatgory:search")]
        public async Task<ActionResult> GetPageListJson(MaxCatgoryListParam param, Pagination pagination)
        {
            TData<List<MaxCatgoryEntity>> obj = await maxCatgoryBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<MaxCatgoryEntity> obj = await maxCatgoryBLL.GetEntity(id);
            return Json(obj);
        }
        [HttpGet]
        public async Task<IActionResult> GetMaxSortJson()
        {
            TData<int> obj = await maxCatgoryBLL.GetMaxSort();
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:maxcatgory:add,app:maxcatgory:edit")]
        public async Task<ActionResult> SaveFormJson(MaxCatgoryEntity entity)
        {
            TData<string> obj = await maxCatgoryBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:maxcatgory:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await maxCatgoryBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
