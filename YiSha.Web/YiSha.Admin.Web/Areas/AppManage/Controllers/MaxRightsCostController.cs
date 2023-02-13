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
    /// 描 述：Max软件-权益消费表控制器类
    /// </summary>
    [Area("AppManage")]
    public class MaxRightsCostController :  BaseController
    {
        private MaxRightsCostBLL maxRightsCostBLL = new MaxRightsCostBLL();

        #region 视图功能
        [AuthorizeFilter("app:maxrightscost:view")]
        public ActionResult MaxRightsCostIndex()
        {
            return View();
        }

        public ActionResult MaxRightsCostForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:maxrightscost:search")]
        public async Task<ActionResult> GetListJson(MaxRightsCostListParam param)
        {
            TData<List<MaxRightsCostEntity>> obj = await maxRightsCostBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:maxrightscost:search")]
        public async Task<ActionResult> GetPageListJson(MaxRightsCostListParam param, Pagination pagination)
        {
            TData<List<MaxRightsCostEntity>> obj = await maxRightsCostBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<MaxRightsCostEntity> obj = await maxRightsCostBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:maxrightscost:add,app:maxrightscost:edit")]
        public async Task<ActionResult> SaveFormJson(MaxRightsCostEntity entity)
        {
            TData<string> obj = await maxRightsCostBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:maxrightscost:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await maxRightsCostBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
