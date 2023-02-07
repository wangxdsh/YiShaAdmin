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
using YiSha.Web.Code;

namespace YiSha.Admin.Web.Areas.AppManage.Controllers
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-06 23:45
    /// 描 述：爬虫文章控制器类
    /// </summary>
    [Area("AppManage")]
    public class PreviewNewsController :  BaseController
    {
        private PreviewNewsBLL previewNewsBLL = new PreviewNewsBLL();

        #region 视图功能
        [AuthorizeFilter("app:previewnews:view")]
        public ActionResult PreviewNewsIndex()
        {
            return View();
        }

        public async Task<IActionResult> PreviewNewsForm()
        {
            ViewBag.OperatorInfo = await Operator.Instance.Current();
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:previewnews:search")]
        public async Task<ActionResult> GetListJson(PreviewNewsListParam param)
        {
            TData<List<PreviewNewsEntity>> obj = await previewNewsBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:previewnews:search")]
        public async Task<ActionResult> GetPageListJson(PreviewNewsListParam param, Pagination pagination)
        {
            TData<List<PreviewNewsEntity>> obj = await previewNewsBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<PreviewNewsEntity> obj = await previewNewsBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:previewnews:add,app:previewnews:edit")]
        public async Task<ActionResult> SaveFormJson(PreviewNewsEntity entity)
        {
            TData<string> obj = await previewNewsBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:previewnews:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await previewNewsBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
