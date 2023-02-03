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
using YiSha.Entity.OrganizationManage;
using YiSha.Business.OrganizationManage;
using YiSha.Model.Param.OrganizationManage;
using YiSha.Business.AppManage;

namespace YiSha.Admin.Web.Areas.OrganizationManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2023-01-09 16:06
    /// 描 述：Banner管理控制器类
    /// </summary>
    [Area("OrganizationManage")]
    public class FsBannerController :  BaseController
    {
        private FsBannerBLL fsBannerBLL = new FsBannerBLL();

        #region 视图功能
        [AuthorizeFilter("organization:fsbanner:view")]
        public ActionResult FsBannerIndex()
        {
            return View();
        }

        public ActionResult FsBannerForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("organization:fsbanner:search")]
        public async Task<ActionResult> GetListJson(FsBannerListParam param)
        {
            TData<List<FsBannerEntity>> obj = await fsBannerBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("organization:fsbanner:search")]
        public async Task<ActionResult> GetPageListJson(FsBannerListParam param, Pagination pagination)
        {
            TData<List<FsBannerEntity>> obj = await fsBannerBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<FsBannerEntity> obj = await fsBannerBLL.GetEntity(id);
            return Json(obj);
        }
        [HttpGet]
        public async Task<IActionResult> GetMaxSortJson()
        {
            TData<int> obj = await fsBannerBLL.GetMaxSort();
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("organization:fsbanner:add,organization:fsbanner:edit")]
        public async Task<ActionResult> SaveFormJson(FsBannerEntity entity)
        {
            TData<string> obj = await fsBannerBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("organization:fsbanner:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await fsBannerBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
