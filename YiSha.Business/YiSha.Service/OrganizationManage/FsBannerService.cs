using System;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Data;
using YiSha.Data.Repository;
using YiSha.Entity.OrganizationManage;
using YiSha.Model.Param.OrganizationManage;

namespace YiSha.Service.OrganizationManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2023-01-09 16:06
    /// 描 述：Banner管理服务类
    /// </summary>
    public class FsBannerService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<FsBannerEntity>> GetList(FsBannerListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<FsBannerEntity>> GetPageList(FsBannerListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<FsBannerEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<FsBannerEntity>(id);
        }
        public async Task<int> GetMaxSort()
        {
            object result = await this.BaseRepository().FindObject("SELECT MAX(sortIndex) FROM banner");
            int sort = result.ParseToInt();
            sort++;
            return sort;
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(FsBannerEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                await entity.Create();
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                
                await this.BaseRepository().Update(entity);
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<FsBannerEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<FsBannerEntity, bool>> ListFilter(FsBannerListParam param)
        {
            var expression = LinqExtensions.True<FsBannerEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
