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
    /// 日 期：2023-02-12 02:47
    /// 描 述：Max软件-分享表业务类
    /// </summary>
    public class MaxShareBLL
    {
        private MaxShareService maxShareService = new MaxShareService();

        #region 获取数据
        public async Task<TData<List<MaxShareEntity>>> GetList(MaxShareListParam param)
        {
            TData<List<MaxShareEntity>> obj = new TData<List<MaxShareEntity>>();
            obj.Data = await maxShareService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<MaxShareEntity>>> GetPageList(MaxShareListParam param, Pagination pagination)
        {
            TData<List<MaxShareEntity>> obj = new TData<List<MaxShareEntity>>();
            obj.Data = await maxShareService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<MaxShareEntity>> GetEntity(long id)
        {
            TData<MaxShareEntity> obj = new TData<MaxShareEntity>();
            obj.Data = await maxShareService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(MaxShareEntity entity)
        {
            TData<string> obj = new TData<string>();
            await maxShareService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await maxShareService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
