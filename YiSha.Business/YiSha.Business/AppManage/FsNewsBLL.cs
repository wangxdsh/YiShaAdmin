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
    /// 日 期：2023-01-12 16:14
    /// 描 述：资源内容业务类
    /// </summary>
    public class FsNewsBLL
    {
        private FsNewsService fsNewsService = new FsNewsService();

        #region 获取数据
        public async Task<TData<List<FsNewsEntity>>> GetList(FsNewsListParam param)
        {
            TData<List<FsNewsEntity>> obj = new TData<List<FsNewsEntity>>();
            obj.Data = await fsNewsService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<FsNewsEntity>>> GetPageList(FsNewsListParam param, Pagination pagination)
        {
            TData<List<FsNewsEntity>> obj = new TData<List<FsNewsEntity>>();
            obj.Data = await fsNewsService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<FsNewsEntity>>> GetListForApi(FsNewsListParam param, Pagination pagination)
        {
            TData<List<FsNewsEntity>> obj = new TData<List<FsNewsEntity>>();
            obj.Data = await fsNewsService.GetListForApi(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }
        public async Task<TData<FsNewsEntity>> GetEntity(long id)
        {
            TData<FsNewsEntity> obj = new TData<FsNewsEntity>();
            obj.Data = await fsNewsService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(FsNewsEntity entity)
        {
            TData<string> obj = new TData<string>();
            await fsNewsService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await fsNewsService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
