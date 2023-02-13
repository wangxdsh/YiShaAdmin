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
    /// 日 期：2023-02-12 02:50
    /// 描 述：Max软件-分享表结果,一对一的用户只能分享一次业务类
    /// </summary>
    public class MaxShareCostBLL
    {
        private MaxShareCostService maxShareCostService = new MaxShareCostService();

        #region 获取数据
        public async Task<TData<List<MaxShareCostEntity>>> GetList(MaxShareCostListParam param)
        {
            TData<List<MaxShareCostEntity>> obj = new TData<List<MaxShareCostEntity>>();
            obj.Data = await maxShareCostService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<MaxShareCostEntity>>> GetPageList(MaxShareCostListParam param, Pagination pagination)
        {
            TData<List<MaxShareCostEntity>> obj = new TData<List<MaxShareCostEntity>>();
            obj.Data = await maxShareCostService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<MaxShareCostEntity>> GetEntity(long id)
        {
            TData<MaxShareCostEntity> obj = new TData<MaxShareCostEntity>();
            obj.Data = await maxShareCostService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(MaxShareCostEntity entity)
        {
            TData<string> obj = new TData<string>();
            await maxShareCostService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await maxShareCostService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
