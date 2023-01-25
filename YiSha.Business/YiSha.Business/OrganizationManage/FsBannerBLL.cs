using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.OrganizationManage;
using YiSha.Model.Param.OrganizationManage;
using YiSha.Service.OrganizationManage;

namespace YiSha.Business.OrganizationManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2023-01-09 16:06
    /// 描 述：Banner管理业务类
    /// </summary>
    public class FsBannerBLL
    {
        private FsBannerService fsBannerService = new FsBannerService();

        #region 获取数据
        public async Task<TData<List<FsBannerEntity>>> GetList(FsBannerListParam param)
        {
            TData<List<FsBannerEntity>> obj = new TData<List<FsBannerEntity>>();
            obj.Data = await fsBannerService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<FsBannerEntity>>> GetPageList(FsBannerListParam param, Pagination pagination)
        {
            TData<List<FsBannerEntity>> obj = new TData<List<FsBannerEntity>>();
            obj.Data = await fsBannerService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<FsBannerEntity>> GetEntity(long id)
        {
            TData<FsBannerEntity> obj = new TData<FsBannerEntity>();
            obj.Data = await fsBannerService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(FsBannerEntity entity)
        {
            TData<string> obj = new TData<string>();
            await fsBannerService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await fsBannerService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
