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
    /// 日 期：2023-01-12 16:14
    /// 描 述：资源内容服务类
    /// </summary>
    public class FsNewsService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<FsNewsEntity>> GetList(FsNewsListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<FsNewsEntity>> GetPageList(FsNewsListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<List<FsNewsEntity>> GetListForApi(FsNewsListParam param, Pagination pagination)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter(param, strSql);
            var list = await this.BaseRepository().FindList<FsNewsEntity>(strSql.ToString(), filter.ToArray(), pagination);
            return list.ToList();
        }

        public async Task<FsNewsEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<FsNewsEntity>(id);
        }
        public async Task<int> GetMaxSort()
        {
            object result = await this.BaseRepository().FindObject("SELECT MAX(NewsSort) FROM newsitems");
            int sort = result.ParseToInt();
            sort++;
            return sort;
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(FsNewsEntity entity)
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
            await this.BaseRepository().Delete<FsNewsEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<FsNewsEntity, bool>> ListFilter(FsNewsListParam param)
        {
            var expression = LinqExtensions.True<FsNewsEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        private List<DbParameter> ListFilter(FsNewsListParam param, StringBuilder strSql)
        {
            strSql.Append(@"SELECT  a.Id,
                                    a.CatgoryId,
                                    a.SubCatgoryId,
                                    a.NewsTitle,
                                    a.NewsTag,
                                    a.ThumbImage,
                                    a.NewsSort,
                                    a.NewsAuthor,
                                    a.ViewTimes,a.DownLoadUrl,a.BaseCreateTime ");
            strSql.Append(@" from newsItems a where 1=1");
            var parameter = new List<DbParameter>();
            if (param != null)
            {
                if (param.catgoryId!=null && !param.catgoryId.ToString().Equals("0"))
                {
                    strSql.Append(" AND a.CatgoryId=@CatgoryId");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@CatgoryId", param.catgoryId));
                }
                if (param.subCatgoryId != null && !param.subCatgoryId.ToString().Equals("0"))
                {
                    strSql.Append(" AND a.SubCatgoryId=@SubCatgoryId");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@SubCatgoryId", param.subCatgoryId));
                }
            }
            return parameter;
        }
        #endregion
    }
}
