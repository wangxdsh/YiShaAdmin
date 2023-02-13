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
    /// 日 期：2023-02-12 02:44
    /// 描 述：Max会员权益-拥有多少次控制器类
    /// </summary>
    [Area("AppManage")]
    public class MaxUserRightsController :  BaseController
    {
        private MaxUserRightsBLL maxUserRightsBLL = new MaxUserRightsBLL();

        #region 视图功能
        [AuthorizeFilter("app:maxuserrights:view")]
        public ActionResult MaxUserRightsIndex()
        {
            return View();
        }

        public ActionResult MaxUserRightsForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:maxuserrights:search")]
        public async Task<ActionResult> GetListJson(MaxUserRightsListParam param)
        {
            TData<List<MaxUserRightsEntity>> obj = await maxUserRightsBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:maxuserrights:search")]
        public async Task<ActionResult> GetPageListJson(MaxUserRightsListParam param, Pagination pagination)
        {
            TData<List<MaxUserRightsEntity>> obj = await maxUserRightsBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<MaxUserRightsEntity> obj = await maxUserRightsBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:maxuserrights:add,app:maxuserrights:edit")]
        public async Task<ActionResult> SaveFormJson(MaxUserRightsEntity entity)
        {
            TData<string> obj = await maxUserRightsBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:maxuserrights:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await maxUserRightsBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
