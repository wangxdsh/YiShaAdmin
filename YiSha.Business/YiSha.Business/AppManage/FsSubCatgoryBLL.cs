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
    /// 创 建：admin
    /// 日 期：2023-01-12 14:29
    /// 描 述：文章二级分类业务类
    /// </summary>
    public class FsSubCatgoryBLL
    {
        private FsSubCatgoryService fsSubCatgoryService = new FsSubCatgoryService();

        #region 获取数据
        public async Task<TData<List<FsSubCatgoryEntity>>> GetList(FsSubCatgoryListParam param)
        {
            TData<List<FsSubCatgoryEntity>> obj = new TData<List<FsSubCatgoryEntity>>();
            obj.Data = await fsSubCatgoryService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<FsSubCatgoryEntity>>> GetPageList(FsSubCatgoryListParam param, Pagination pagination)
        {
            TData<List<FsSubCatgoryEntity>> obj = new TData<List<FsSubCatgoryEntity>>();
            obj.Data = await fsSubCatgoryService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<FsSubCatgoryEntity>>> GetListByCatgoryIdForApi(FsSubCatgoryListParam param)
        {
            TData<List<FsSubCatgoryEntity>> obj = new TData<List<FsSubCatgoryEntity>>();
            obj.Data = await fsSubCatgoryService.GetListByCatgoryIdForApi(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<FsSubCatgoryEntity>> GetEntity(long id)
        {
            TData<FsSubCatgoryEntity> obj = new TData<FsSubCatgoryEntity>();
            obj.Data = await fsSubCatgoryService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        public async Task<TData<int>> GetMaxSort()
        {
            TData<int> obj = new TData<int>();
            obj.Data = await fsSubCatgoryService.GetMaxSort();
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(FsSubCatgoryEntity entity)
        {
            TData<string> obj = new TData<string>();
            await fsSubCatgoryService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await fsSubCatgoryService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
