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
    /// 日 期：2023-02-12 02:50
    /// 描 述：Max软件-分享表结果,一对一的用户只能分享一次控制器类
    /// </summary>
    [Area("AppManage")]
    public class MaxShareCostController :  BaseController
    {
        private MaxShareCostBLL maxShareCostBLL = new MaxShareCostBLL();

        #region 视图功能
        [AuthorizeFilter("app:maxsharecost:view")]
        public ActionResult MaxShareCostIndex()
        {
            return View();
        }

        public ActionResult MaxShareCostForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:maxsharecost:search")]
        public async Task<ActionResult> GetListJson(MaxShareCostListParam param)
        {
            TData<List<MaxShareCostEntity>> obj = await maxShareCostBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:maxsharecost:search")]
        public async Task<ActionResult> GetPageListJson(MaxShareCostListParam param, Pagination pagination)
        {
            TData<List<MaxShareCostEntity>> obj = await maxShareCostBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<MaxShareCostEntity> obj = await maxShareCostBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:maxsharecost:add,app:maxsharecost:edit")]
        public async Task<ActionResult> SaveFormJson(MaxShareCostEntity entity)
        {
            TData<string> obj = await maxShareCostBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:maxsharecost:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await maxShareCostBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
