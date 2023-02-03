using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.AppManage;
using YiSha.Model.Param.AppManage;
using YiSha.Service.AppManage;
using YiSha.Service.OrganizationManage;

namespace YiSha.Business.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-03 19:25
    /// 描 述：应用管理业务类
    /// </summary>
    public class MaxAppsBLL
    {
        private MaxAppsService maxAppsService = new MaxAppsService();

        #region 获取数据
        public async Task<TData<List<MaxAppsEntity>>> GetList(MaxAppsListParam param)
        {
            TData<List<MaxAppsEntity>> obj = new TData<List<MaxAppsEntity>>();
            obj.Data = await maxAppsService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<MaxAppsEntity>>> GetPageList(MaxAppsListParam param, Pagination pagination)
        {
            TData<List<MaxAppsEntity>> obj = new TData<List<MaxAppsEntity>>();
            obj.Data = await maxAppsService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<MaxAppsEntity>> GetEntity(long id)
        {
            TData<MaxAppsEntity> obj = new TData<MaxAppsEntity>();
            obj.Data = await maxAppsService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        public async Task<TData<int>> GetMaxSort()
        {
            TData<int> obj = new TData<int>();
            obj.Data = await maxAppsService.GetMaxSort();
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(MaxAppsEntity entity)
        {
            TData<string> obj = new TData<string>();
            await maxAppsService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await maxAppsService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
