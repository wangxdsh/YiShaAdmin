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
    /// 日 期：2023-02-12 02:46
    /// 描 述：Max权益控制器类
    /// </summary>
    [Area("AppManage")]
    public class MaxRightsController :  BaseController
    {
        private MaxRightsBLL maxRightsBLL = new MaxRightsBLL();

        #region 视图功能
        [AuthorizeFilter("app:maxrights:view")]
        public ActionResult MaxRightsIndex()
        {
            return View();
        }

        public ActionResult MaxRightsForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:maxrights:search")]
        public async Task<ActionResult> GetListJson(MaxRightsListParam param)
        {
            TData<List<MaxRightsEntity>> obj = await maxRightsBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:maxrights:search")]
        public async Task<ActionResult> GetPageListJson(MaxRightsListParam param, Pagination pagination)
        {
            TData<List<MaxRightsEntity>> obj = await maxRightsBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<MaxRightsEntity> obj = await maxRightsBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:maxrights:add,app:maxrights:edit")]
        public async Task<ActionResult> SaveFormJson(MaxRightsEntity entity)
        {
            TData<string> obj = await maxRightsBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:maxrights:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await maxRightsBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
