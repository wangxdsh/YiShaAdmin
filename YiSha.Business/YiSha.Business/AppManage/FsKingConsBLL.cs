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
    /// 日 期：2023-01-11 16:45
    /// 描 述：首页金刚位业务类
    /// </summary>
    public class FsKingConsBLL
    {
        private FsKingConsService fsKingConsService = new FsKingConsService();

        #region 获取数据
        public async Task<TData<List<FsKingConsEntity>>> GetList(FsKingConsListParam param)
        {
            TData<List<FsKingConsEntity>> obj = new TData<List<FsKingConsEntity>>();
            obj.Data = await fsKingConsService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<FsKingConsEntity>>> GetPageList(FsKingConsListParam param, Pagination pagination)
        {
            TData<List<FsKingConsEntity>> obj = new TData<List<FsKingConsEntity>>();
            obj.Data = await fsKingConsService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<FsKingConsEntity>> GetEntity(long id)
        {
            TData<FsKingConsEntity> obj = new TData<FsKingConsEntity>();
            obj.Data = await fsKingConsService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(FsKingConsEntity entity)
        {
            TData<string> obj = new TData<string>();
            await fsKingConsService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await fsKingConsService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
