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
    /// 创 建：admin
    /// 日 期：2023-01-11 16:48
    /// 描 述：文章大类服务类
    /// </summary>
    public class FsCatgoryService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<FsCatgoryEntity>> GetList(FsCatgoryListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<FsCatgoryEntity>> GetPageList(FsCatgoryListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<FsCatgoryEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<FsCatgoryEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(FsCatgoryEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                await entity.Create();
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                await entity.Modify();
                await this.BaseRepository().Update(entity);
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<FsCatgoryEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<FsCatgoryEntity, bool>> ListFilter(FsCatgoryListParam param)
        {
            var expression = LinqExtensions.True<FsCatgoryEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
