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
    /// 日 期：2023-02-09 19:23
    /// 描 述：Max软件所属分类表控制器类
    /// </summary>
    [Area("AppManage")]
    public class MaxNewsCatgorysController :  BaseController
    {
        private MaxNewsCatgorysBLL maxNewsCatgorysBLL = new MaxNewsCatgorysBLL();

        #region 视图功能
        [AuthorizeFilter("app:maxnewscatgorys:view")]
        public ActionResult MaxNewsCatgorysIndex()
        {
            return View();
        }

        public ActionResult MaxNewsCatgorysForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:maxnewscatgorys:search")]
        public async Task<ActionResult> GetListJson(MaxNewsCatgorysListParam param)
        {
            TData<List<MaxNewsCatgorysEntity>> obj = await maxNewsCatgorysBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:maxnewscatgorys:search")]
        public async Task<ActionResult> GetPageListJson(MaxNewsCatgorysListParam param, Pagination pagination)
        {
            TData<List<MaxNewsCatgorysEntity>> obj = await maxNewsCatgorysBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<MaxNewsCatgorysEntity> obj = await maxNewsCatgorysBLL.GetEntity(id);
            return Json(obj);
        }
        [HttpGet]
        public async Task<IActionResult> GetMaxSortJson()
        {
            TData<int> obj = await maxNewsCatgorysBLL.GetMaxSort();
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:maxnewscatgorys:add,app:maxnewscatgorys:edit")]
        public async Task<ActionResult> SaveFormJson(MaxNewsCatgorysEntity entity)
        {
            TData<string> obj = await maxNewsCatgorysBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:maxnewscatgorys:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await maxNewsCatgorysBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
