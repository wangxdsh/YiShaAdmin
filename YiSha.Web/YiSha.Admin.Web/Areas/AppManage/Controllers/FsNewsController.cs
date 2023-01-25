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
    /// 日 期：2023-01-12 16:14
    /// 描 述：资源内容控制器类
    /// </summary>
    [Area("AppManage")]
    public class FsNewsController :  BaseController
    {
        private FsNewsBLL fsNewsBLL = new FsNewsBLL();

        #region 视图功能
        [AuthorizeFilter("app:fsnews:view")]
        public ActionResult FsNewsIndex()
        {
            return View();
        }

        public ActionResult FsNewsForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:fsnews:search")]
        public async Task<ActionResult> GetListJson(FsNewsListParam param)
        {
            TData<List<FsNewsEntity>> obj = await fsNewsBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:fsnews:search")]
        public async Task<ActionResult> GetPageListJson(FsNewsListParam param, Pagination pagination)
        {
            TData<List<FsNewsEntity>> obj = await fsNewsBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<FsNewsEntity> obj = await fsNewsBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:fsnews:add,app:fsnews:edit")]
        public async Task<ActionResult> SaveFormJson(FsNewsEntity entity)
        {
            TData<string> obj = await fsNewsBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:fsnews:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await fsNewsBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
