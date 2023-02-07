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

namespace YiSha.Business.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-04 15:15
    /// 描 述：用户操作历史-业务业务类
    /// </summary>
    public class AppsOperationHistoryBLL
    {
        private AppsOperationHistoryService appsOperationHistoryService = new AppsOperationHistoryService();

        #region 获取数据
        public async Task<TData<List<AppsOperationHistoryEntity>>> GetList(AppsOperationHistoryListParam param)
        {
            TData<List<AppsOperationHistoryEntity>> obj = new TData<List<AppsOperationHistoryEntity>>();
            obj.Data = await appsOperationHistoryService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<AppsOperationHistoryEntity>>> GetPageList(AppsOperationHistoryListParam param, Pagination pagination)
        {
            TData<List<AppsOperationHistoryEntity>> obj = new TData<List<AppsOperationHistoryEntity>>();
            obj.Data = await appsOperationHistoryService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<AppsOperationHistoryEntity>> GetEntity(long id)
        {
            TData<AppsOperationHistoryEntity> obj = new TData<AppsOperationHistoryEntity>();
            obj.Data = await appsOperationHistoryService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(AppsOperationHistoryEntity entity)
        {
            TData<string> obj = new TData<string>();
            await appsOperationHistoryService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await appsOperationHistoryService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
