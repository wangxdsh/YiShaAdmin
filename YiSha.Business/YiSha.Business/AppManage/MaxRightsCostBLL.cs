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
    /// 日 期：2023-02-12 02:46
    /// 描 述：Max软件-权益消费表业务类
    /// </summary>
    public class MaxRightsCostBLL
    {
        private MaxRightsCostService maxRightsCostService = new MaxRightsCostService();

        #region 获取数据
        public async Task<TData<List<MaxRightsCostEntity>>> GetList(MaxRightsCostListParam param)
        {
            TData<List<MaxRightsCostEntity>> obj = new TData<List<MaxRightsCostEntity>>();
            obj.Data = await maxRightsCostService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<MaxRightsCostEntity>>> GetPageList(MaxRightsCostListParam param, Pagination pagination)
        {
            TData<List<MaxRightsCostEntity>> obj = new TData<List<MaxRightsCostEntity>>();
            obj.Data = await maxRightsCostService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<MaxRightsCostEntity>> GetEntity(long id)
        {
            TData<MaxRightsCostEntity> obj = new TData<MaxRightsCostEntity>();
            obj.Data = await maxRightsCostService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(MaxRightsCostEntity entity)
        {
            TData<string> obj = new TData<string>();
            await maxRightsCostService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await maxRightsCostService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
