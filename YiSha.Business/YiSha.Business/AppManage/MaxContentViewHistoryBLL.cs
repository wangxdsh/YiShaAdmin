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
    /// 日 期：2023-02-12 02:42
    /// 描 述：Max软件浏览历史表业务类
    /// </summary>
    public class MaxContentViewHistoryBLL
    {
        private MaxContentViewHistoryService maxContentViewHistoryService = new MaxContentViewHistoryService();

        #region 获取数据
        public async Task<TData<List<MaxContentViewHistoryEntity>>> GetList(MaxContentViewHistoryListParam param)
        {
            TData<List<MaxContentViewHistoryEntity>> obj = new TData<List<MaxContentViewHistoryEntity>>();
            obj.Data = await maxContentViewHistoryService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<MaxContentViewHistoryEntity>>> GetPageList(MaxContentViewHistoryListParam param, Pagination pagination)
        {
            TData<List<MaxContentViewHistoryEntity>> obj = new TData<List<MaxContentViewHistoryEntity>>();
            obj.Data = await maxContentViewHistoryService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<MaxContentViewHistoryEntity>> GetEntity(long id)
        {
            TData<MaxContentViewHistoryEntity> obj = new TData<MaxContentViewHistoryEntity>();
            obj.Data = await maxContentViewHistoryService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(MaxContentViewHistoryEntity entity)
        {
            TData<string> obj = new TData<string>();
            await maxContentViewHistoryService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await maxContentViewHistoryService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
