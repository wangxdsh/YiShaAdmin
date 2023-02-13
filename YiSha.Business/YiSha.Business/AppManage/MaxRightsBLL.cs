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
    /// 日 期：2023-02-12 02:46
    /// 描 述：Max权益业务类
    /// </summary>
    public class MaxRightsBLL
    {
        private MaxRightsService maxRightsService = new MaxRightsService();

        #region 获取数据
        public async Task<TData<List<MaxRightsEntity>>> GetList(MaxRightsListParam param)
        {
            TData<List<MaxRightsEntity>> obj = new TData<List<MaxRightsEntity>>();
            obj.Data = await maxRightsService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<MaxRightsEntity>>> GetPageList(MaxRightsListParam param, Pagination pagination)
        {
            TData<List<MaxRightsEntity>> obj = new TData<List<MaxRightsEntity>>();
            obj.Data = await maxRightsService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<MaxRightsEntity>> GetEntity(long id)
        {
            TData<MaxRightsEntity> obj = new TData<MaxRightsEntity>();
            obj.Data = await maxRightsService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        public async Task<TData<int>> GetRightsCount(long userId, DateTime checkDate)
        {
            TData<int> obj = new TData<int>();
            obj.Data = await maxRightsService.GetRightsCount(userId, checkDate);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(MaxRightsEntity entity)
        {
            TData<string> obj = new TData<string>();
            await maxRightsService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await maxRightsService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
