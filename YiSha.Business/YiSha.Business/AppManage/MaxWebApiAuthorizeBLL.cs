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
    /// 日 期：2023-02-04 15:12
    /// 描 述：api授权业务类
    /// </summary>
    public class MaxWebApiAuthorizeBLL
    {
        private MaxWebApiAuthorizeService maxWebApiAuthorizeService = new MaxWebApiAuthorizeService();

        #region 获取数据
        public async Task<TData<List<MaxWebApiAuthorizeEntity>>> GetList(MaxWebApiAuthorizeListParam param)
        {
            TData<List<MaxWebApiAuthorizeEntity>> obj = new TData<List<MaxWebApiAuthorizeEntity>>();
            obj.Data = await maxWebApiAuthorizeService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<MaxWebApiAuthorizeEntity>>> GetPageList(MaxWebApiAuthorizeListParam param, Pagination pagination)
        {
            TData<List<MaxWebApiAuthorizeEntity>> obj = new TData<List<MaxWebApiAuthorizeEntity>>();
            obj.Data = await maxWebApiAuthorizeService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<MaxWebApiAuthorizeEntity>> GetEntity(long id)
        {
            TData<MaxWebApiAuthorizeEntity> obj = new TData<MaxWebApiAuthorizeEntity>();
            obj.Data = await maxWebApiAuthorizeService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(MaxWebApiAuthorizeEntity entity)
        {
            TData<string> obj = new TData<string>();
            await maxWebApiAuthorizeService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await maxWebApiAuthorizeService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
