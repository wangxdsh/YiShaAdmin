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
    /// 创 建：admin
    /// 日 期：2023-01-12 14:29
    /// 描 述：文章二级分类控制器类
    /// </summary>
    [Area("AppManage")]
    public class FsSubCatgoryController :  BaseController
    {
        private FsSubCatgoryBLL fsSubCatgoryBLL = new FsSubCatgoryBLL();

        #region 视图功能
        [AuthorizeFilter("app:fssubcatgory:view")]
        public ActionResult FsSubCatgoryIndex()
        {
            return View();
        }

        public ActionResult FsSubCatgoryForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:fssubcatgory:search")]
        public async Task<ActionResult> GetListJson(FsSubCatgoryListParam param)
        {
            TData<List<FsSubCatgoryEntity>> obj = await fsSubCatgoryBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:fssubcatgory:search")]
        public async Task<ActionResult> GetPageListJson(FsSubCatgoryListParam param, Pagination pagination)
        {
            TData<List<FsSubCatgoryEntity>> obj = await fsSubCatgoryBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<FsSubCatgoryEntity> obj = await fsSubCatgoryBLL.GetEntity(id);
            return Json(obj);
        }
        [HttpGet]
        public async Task<IActionResult> GetMaxSortJson()
        {
            TData<int> obj = await fsSubCatgoryBLL.GetMaxSort();
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:fssubcatgory:add,app:fssubcatgory:edit")]
        public async Task<ActionResult> SaveFormJson(FsSubCatgoryEntity entity)
        {
            TData<string> obj = await fsSubCatgoryBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:fssubcatgory:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await fsSubCatgoryBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
