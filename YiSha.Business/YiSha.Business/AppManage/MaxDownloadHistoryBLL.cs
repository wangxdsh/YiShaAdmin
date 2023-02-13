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
    /// 日 期：2023-02-09 19:20
    /// 描 述：Max软件下载记录表业务类
    /// </summary>
    public class MaxDownloadHistoryBLL
    {
        private MaxDownloadHistoryService maxDownloadHistoryService = new MaxDownloadHistoryService();

        #region 获取数据
        public async Task<TData<List<MaxDownloadHistoryEntity>>> GetList(MaxDownloadHistoryListParam param)
        {
            TData<List<MaxDownloadHistoryEntity>> obj = new TData<List<MaxDownloadHistoryEntity>>();
            obj.Data = await maxDownloadHistoryService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<MaxDownloadHistoryEntity>>> GetPageList(MaxDownloadHistoryListParam param, Pagination pagination)
        {
            TData<List<MaxDownloadHistoryEntity>> obj = new TData<List<MaxDownloadHistoryEntity>>();
            obj.Data = await maxDownloadHistoryService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<MaxDownloadHistoryEntity>> GetEntity(long id)
        {
            TData<MaxDownloadHistoryEntity> obj = new TData<MaxDownloadHistoryEntity>();
            obj.Data = await maxDownloadHistoryService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(MaxDownloadHistoryEntity entity)
        {
            TData<string> obj = new TData<string>();
            await maxDownloadHistoryService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await maxDownloadHistoryService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
