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
    /// 日 期：2023-01-11 16:48
    /// 描 述：文章大类业务类
    /// </summary>
    public class FsCatgoryBLL
    {
        private FsCatgoryService fsCatgoryService = new FsCatgoryService();

        #region 获取数据
        public async Task<TData<List<FsCatgoryEntity>>> GetList(FsCatgoryListParam param)
        {
            TData<List<FsCatgoryEntity>> obj = new TData<List<FsCatgoryEntity>>();
            obj.Data = await fsCatgoryService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<FsCatgoryEntity>>> GetPageList(FsCatgoryListParam param, Pagination pagination)
        {
            TData<List<FsCatgoryEntity>> obj = new TData<List<FsCatgoryEntity>>();
            obj.Data = await fsCatgoryService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<FsCatgoryEntity>> GetEntity(long id)
        {
            TData<FsCatgoryEntity> obj = new TData<FsCatgoryEntity>();
            obj.Data = await fsCatgoryService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(FsCatgoryEntity entity)
        {
            TData<string> obj = new TData<string>();
            await fsCatgoryService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await fsCatgoryService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
