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
using YiSha.Entity.OrganizationManage;

namespace YiSha.Service.AppManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2023-01-12 14:29
    /// 描 述：文章二级分类服务类
    /// </summary>
    public class FsSubCatgoryService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<FsSubCatgoryEntity>> GetList(FsSubCatgoryListParam param)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter(param, strSql);
            var list = await this.BaseRepository().FindList<FsSubCatgoryEntity>(strSql.ToString(), filter.ToArray());
            return list.ToList();
        }

        public async Task<List<FsSubCatgoryEntity>> GetPageList(FsSubCatgoryListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<FsSubCatgoryEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<FsSubCatgoryEntity>(id);
        }

        public async Task<List<FsSubCatgoryEntity>> GetListByCatgoryIdForApi(FsSubCatgoryListParam param)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter(param, strSql);
            var list = await this.BaseRepository().FindList<FsSubCatgoryEntity>(strSql.ToString(), filter.ToArray());
            return list.ToList();
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(FsSubCatgoryEntity entity)
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
            await this.BaseRepository().Delete<FsSubCatgoryEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<FsSubCatgoryEntity, bool>> ListFilter(FsSubCatgoryListParam param)
        {
            var expression = LinqExtensions.True<FsSubCatgoryEntity>();
            if (param != null)
            {
            }
            return expression;
        }

        private List<DbParameter> ListFilter(FsSubCatgoryListParam param, StringBuilder strSql)
        {
            strSql.Append(@"SELECT  a.Id,
                                    a.CatgoryId,
                                    a.Name,
                                    a.SubCatgoryAd,
                                    a.ThumbImage,
                                    a.Sort");
            strSql.Append(@" from subCatgory a where 1=1");
            var parameter = new List<DbParameter>();
            if (param != null)
            {
                if(!string.IsNullOrEmpty(param.CatgoryId.ToString()))
                {
                    strSql.Append(" AND a.CatgoryId=@CatgoryId");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@CatgoryId", param.CatgoryId ));
                }
            }
            return parameter;
        }
        #endregion
    }
}
