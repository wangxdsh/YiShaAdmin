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

using YiSha.Entity.OrganizationManage;
using YiSha.Business.OrganizationManage;
using YiSha.Model.Param.OrganizationManage;

namespace YiSha.Admin.Web.Areas.AppManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2023-01-11 16:45
    /// 描 述：首页金刚位控制器类
    /// </summary>
    [Area("AppManage")]
    public class FsKingConsController :  BaseController
    {
        private FsKingConsBLL fsKingConsBLL = new FsKingConsBLL();

        #region 视图功能
        [AuthorizeFilter("app:fskingcons:view")]
        public ActionResult FsKingConsIndex()
        {
            return View();
        }

        public ActionResult FsKingConsForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:fskingcons:search")]
        public async Task<ActionResult> GetListJson(FsKingConsListParam param)
        {
            TData<List<FsKingConsEntity>> obj = await fsKingConsBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:fskingcons:search")]
        public async Task<ActionResult> GetPageListJson(FsKingConsListParam param, Pagination pagination)
        {
            TData<List<FsKingConsEntity>> obj = await fsKingConsBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<FsKingConsEntity> obj = await fsKingConsBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:fskingcons:add,app:fskingcons:edit")]
        public async Task<ActionResult> SaveFormJson(FsKingConsEntity entity)
        {
            TData<string> obj = await fsKingConsBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:fskingcons:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await fsKingConsBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
