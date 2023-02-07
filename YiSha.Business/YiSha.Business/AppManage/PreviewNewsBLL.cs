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
    /// 日 期：2023-02-06 23:45
    /// 描 述：爬虫文章业务类
    /// </summary>
    public class PreviewNewsBLL
    {
        private PreviewNewsService previewNewsService = new PreviewNewsService();

        #region 获取数据
        public async Task<TData<List<PreviewNewsEntity>>> GetList(PreviewNewsListParam param)
        {
            TData<List<PreviewNewsEntity>> obj = new TData<List<PreviewNewsEntity>>();
            obj.Data = await previewNewsService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<PreviewNewsEntity>>> GetPageList(PreviewNewsListParam param, Pagination pagination)
        {
            TData<List<PreviewNewsEntity>> obj = new TData<List<PreviewNewsEntity>>();
            obj.Data = await previewNewsService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<PreviewNewsEntity>> GetEntity(long id)
        {
            TData<PreviewNewsEntity> obj = new TData<PreviewNewsEntity>();
            obj.Data = await previewNewsService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(PreviewNewsEntity entity)
        {
            TData<string> obj = new TData<string>();
            await previewNewsService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await previewNewsService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
