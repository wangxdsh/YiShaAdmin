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
    /// 日 期：2023-02-12 02:47
    /// 描 述：Max软件-分享表控制器类
    /// </summary>
    [Area("AppManage")]
    public class MaxShareController :  BaseController
    {
        private MaxShareBLL maxShareBLL = new MaxShareBLL();

        #region 视图功能
        [AuthorizeFilter("app:maxshare:view")]
        public ActionResult MaxShareIndex()
        {
            return View();
        }

        public ActionResult MaxShareForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:maxshare:search")]
        public async Task<ActionResult> GetListJson(MaxShareListParam param)
        {
            TData<List<MaxShareEntity>> obj = await maxShareBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:maxshare:search")]
        public async Task<ActionResult> GetPageListJson(MaxShareListParam param, Pagination pagination)
        {
            TData<List<MaxShareEntity>> obj = await maxShareBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<MaxShareEntity> obj = await maxShareBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:maxshare:add,app:maxshare:edit")]
        public async Task<ActionResult> SaveFormJson(MaxShareEntity entity)
        {
            TData<string> obj = await maxShareBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:maxshare:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await maxShareBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
