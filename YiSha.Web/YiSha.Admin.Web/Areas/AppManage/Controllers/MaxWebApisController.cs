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
    /// 日 期：2023-02-04 15:09
    /// 描 述：webApi管理控制器类
    /// </summary>
    [Area("AppManage")]
    public class MaxWebApisController :  BaseController
    {
        private MaxWebApisBLL maxWebApisBLL = new MaxWebApisBLL();

        #region 视图功能
        [AuthorizeFilter("app:maxwebapis:view")]
        public ActionResult MaxWebApisIndex()
        {
            return View();
        }

        public ActionResult MaxWebApisForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:maxwebapis:search")]
        public async Task<ActionResult> GetListJson(MaxWebApisListParam param)
        {
            TData<List<MaxWebApisEntity>> obj = await maxWebApisBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:maxwebapis:search")]
        public async Task<ActionResult> GetPageListJson(MaxWebApisListParam param, Pagination pagination)
        {
            TData<List<MaxWebApisEntity>> obj = await maxWebApisBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<MaxWebApisEntity> obj = await maxWebApisBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:maxwebapis:add,app:maxwebapis:edit")]
        public async Task<ActionResult> SaveFormJson(MaxWebApisEntity entity)
        {
            TData<string> obj = await maxWebApisBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:maxwebapis:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await maxWebApisBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
