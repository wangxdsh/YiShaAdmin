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
    /// 日 期：2023-01-11 16:48
    /// 描 述：文章大类控制器类
    /// </summary>
    [Area("AppManage")]
    public class FsCatgoryController :  BaseController
    {
        private FsCatgoryBLL fsCatgoryBLL = new FsCatgoryBLL();

        #region 视图功能
        [AuthorizeFilter("app:fscatgory:view")]
        public ActionResult FsCatgoryIndex()
        {
            return View();
        }

        public ActionResult FsCatgoryForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:fscatgory:search")]
        public async Task<ActionResult> GetListJson(FsCatgoryListParam param)
        {
            TData<List<FsCatgoryEntity>> obj = await fsCatgoryBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:fscatgory:search")]
        public async Task<ActionResult> GetPageListJson(FsCatgoryListParam param, Pagination pagination)
        {
            TData<List<FsCatgoryEntity>> obj = await fsCatgoryBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<FsCatgoryEntity> obj = await fsCatgoryBLL.GetEntity(id);
            return Json(obj);
        }
        [HttpGet]
        public async Task<IActionResult> GetMaxSortJson()
        {
            TData<int> obj = await fsCatgoryBLL.GetMaxSort();
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:fscatgory:add,app:fscatgory:edit")]
        public async Task<ActionResult> SaveFormJson(FsCatgoryEntity entity)
        {
            TData<string> obj = await fsCatgoryBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:fscatgory:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await fsCatgoryBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
