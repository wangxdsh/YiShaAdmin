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
    /// 日 期：2023-02-09 19:23
    /// 描 述：Max软件所属分类表业务类
    /// </summary>
    public class MaxNewsCatgorysBLL
    {
        private MaxNewsCatgorysService maxNewsCatgorysService = new MaxNewsCatgorysService();

        #region 获取数据
        public async Task<TData<List<MaxNewsCatgorysEntity>>> GetList(MaxNewsCatgorysListParam param)
        {
            TData<List<MaxNewsCatgorysEntity>> obj = new TData<List<MaxNewsCatgorysEntity>>();
            obj.Data = await maxNewsCatgorysService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<MaxNewsCatgorysEntity>>> GetPageList(MaxNewsCatgorysListParam param, Pagination pagination)
        {
            TData<List<MaxNewsCatgorysEntity>> obj = new TData<List<MaxNewsCatgorysEntity>>();
            obj.Data = await maxNewsCatgorysService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<MaxNewsCatgorysEntity>> GetEntity(long id)
        {
            TData<MaxNewsCatgorysEntity> obj = new TData<MaxNewsCatgorysEntity>();
            obj.Data = await maxNewsCatgorysService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        public async Task<TData<int>> GetMaxSort()
        {
           TData<int> obj = new TData<int>();
           obj.Data = await maxNewsCatgorysService.GetMaxSort();
           obj.Tag = 1;
           return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(MaxNewsCatgorysEntity entity)
        {
            TData<string> obj = new TData<string>();
            await maxNewsCatgorysService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await maxNewsCatgorysService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
