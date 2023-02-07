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
    /// 日 期：2023-02-04 15:14
    /// 描 述：webApi日志控制器类
    /// </summary>
    [Area("AppManage")]
    public class MaxWebApiLogController :  BaseController
    {
        private MaxWebApiLogBLL maxWebApiLogBLL = new MaxWebApiLogBLL();

        #region 视图功能
        [AuthorizeFilter("app:maxwebapilog:view")]
        public ActionResult MaxWebApiLogIndex()
        {
            return View();
        }

        public ActionResult MaxWebApiLogForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:maxwebapilog:search")]
        public async Task<ActionResult> GetListJson(MaxWebApiLogListParam param)
        {
            TData<List<MaxWebApiLogEntity>> obj = await maxWebApiLogBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:maxwebapilog:search")]
        public async Task<ActionResult> GetPageListJson(MaxWebApiLogListParam param, Pagination pagination)
        {
            TData<List<MaxWebApiLogEntity>> obj = await maxWebApiLogBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<MaxWebApiLogEntity> obj = await maxWebApiLogBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:maxwebapilog:add,app:maxwebapilog:edit")]
        public async Task<ActionResult> SaveFormJson(MaxWebApiLogEntity entity)
        {
            TData<string> obj = await maxWebApiLogBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:maxwebapilog:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await maxWebApiLogBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
