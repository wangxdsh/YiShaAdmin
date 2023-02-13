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
using YiSha.Model.Result.AppManage;

namespace YiSha.Business.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-09 19:22
    /// 描 述：Max软件分类表业务类
    /// </summary>
    public class MaxCatgoryBLL
    {
        private MaxCatgoryService maxCatgoryService = new MaxCatgoryService();

        #region 获取数据
        public async Task<TData<List<MaxCatgoryEntity>>> GetList(MaxCatgoryListParam param)
        {
            TData<List<MaxCatgoryEntity>> obj = new TData<List<MaxCatgoryEntity>>();
            obj.Data = await maxCatgoryService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<MaxCatgoryEntity>>> GetPageList(MaxCatgoryListParam param, Pagination pagination)
        {
            TData<List<MaxCatgoryEntity>> obj = new TData<List<MaxCatgoryEntity>>();
            obj.Data = await maxCatgoryService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<MaxCatgoryEntity>> GetEntity(long id)
        {
            TData<MaxCatgoryEntity> obj = new TData<MaxCatgoryEntity>();
            obj.Data = await maxCatgoryService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }

        public async Task<TData<int>> GetMaxSort()
        {
           TData<int> obj = new TData<int>();
           obj.Data = await maxCatgoryService.GetMaxSort();
           obj.Tag = 1;
           return obj;
        }
        public async Task<TData<int>> GetConentCount(MaxCatgoryListParam param)
        {
            TData<int> obj = new TData<int>();
            obj.Data = await maxCatgoryService.ConentCount(param);
            obj.Tag = 1;
            return obj;
        }
        public async Task<TData<List<MaxCatgoryEntityDto>>> GetCategoryList(MaxCatgoryListParam param)
        {
            TData<List<MaxCatgoryEntityDto>> obj = new TData<List<MaxCatgoryEntityDto>>();
            obj.Data = await maxCatgoryService.GetCategoryList(param);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(MaxCatgoryEntity entity)
        {
            TData<string> obj = new TData<string>();
            await maxCatgoryService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await maxCatgoryService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
