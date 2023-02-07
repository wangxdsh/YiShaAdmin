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
using YiSha.Entity.AppManage;
using YiSha.Model.Param.AppManage;

namespace YiSha.Service.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-06 23:45
    /// 描 述：爬虫文章服务类
    /// </summary>
    public class PreviewNewsService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<PreviewNewsEntity>> GetList(PreviewNewsListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<PreviewNewsEntity>> GetPageList(PreviewNewsListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<PreviewNewsEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<PreviewNewsEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(PreviewNewsEntity entity)
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
            await this.BaseRepository().Delete<PreviewNewsEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<PreviewNewsEntity, bool>> ListFilter(PreviewNewsListParam param)
        {
            var expression = LinqExtensions.True<PreviewNewsEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
