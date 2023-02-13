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
    /// 日 期：2023-02-12 02:44
    /// 描 述：Max会员权益-拥有多少次业务类
    /// </summary>
    public class MaxUserRightsBLL
    {
        private MaxUserRightsService maxUserRightsService = new MaxUserRightsService();

        #region 获取数据
        public async Task<TData<List<MaxUserRightsEntity>>> GetList(MaxUserRightsListParam param)
        {
            TData<List<MaxUserRightsEntity>> obj = new TData<List<MaxUserRightsEntity>>();
            obj.Data = await maxUserRightsService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<MaxUserRightsEntity>>> GetPageList(MaxUserRightsListParam param, Pagination pagination)
        {
            TData<List<MaxUserRightsEntity>> obj = new TData<List<MaxUserRightsEntity>>();
            obj.Data = await maxUserRightsService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<MaxUserRightsEntity>> GetEntity(long id)
        {
            TData<MaxUserRightsEntity> obj = new TData<MaxUserRightsEntity>();
            obj.Data = await maxUserRightsService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(MaxUserRightsEntity entity)
        {
            TData<string> obj = new TData<string>();
            await maxUserRightsService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await maxUserRightsService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
