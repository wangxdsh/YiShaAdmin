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
using YiSha.Model.Result.AppManage;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection.Metadata;

namespace YiSha.Service.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-09 19:22
    /// 描 述：Max软件分类表服务类
    /// </summary>
    public class MaxCatgoryService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<MaxCatgoryEntity>> GetList(MaxCatgoryListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<MaxCatgoryEntity>> GetPageList(MaxCatgoryListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<List<MaxCatgoryEntityDto>> GetCategoryList(MaxCatgoryListParam param)
        {
            var strSql = new StringBuilder();

            strSql.Append(@"SELECT mc.Id,
                            mc.CatgoryTitle,
                            mc.ParentId,
                            mc.CatgorySort,
                            (SELECT COUNT(DISTINCT(NewsId)) FROM maxnewscatgorys mnc WHERE mnc.BaseIsDelete=0");
            strSql.Append(" and mnc.CatgoryId in (SELECT Id FROM maxcatgory mci WHERE mci.ParentId = mc.Id or mci.Id = mc.Id)) ");
            strSql.Append(@" AS 'ConentCount'  ");
            strSql.Append(@" FROM maxcatgory mc where 1=1");

            var parameter = new List<DbParameter>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.Id.ToString()))
                {
                    strSql.Append(" AND mc.Id=@Id ");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@Id", param.Id));
                }
                if (!string.IsNullOrEmpty(param.ParentId.ToString()))
                {
                    strSql.Append(" AND mc.ParentId=@ParentId ");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@ParentId", param.ParentId));
                }  
            }

            var list = await this.BaseRepository().FindList<MaxCatgoryEntityDto>(strSql.ToString(), parameter.ToArray());
            return list.ToList();

        }

        public async Task<int> GetMaxSort()
        {
            object result = await this.BaseRepository().FindObject("SELECT MAX(CatgorySort) FROM maxcatgory");
            int sort = result.ParseToInt();
            sort++;
            return sort;
        }
        
        public async Task<int> ConentCount(MaxCatgoryListParam param)
        {
            string sqlStr = "SELECT count(*) FROM MaxNewsCatgorys mx";
            if(param != null)
            {
                if(param.Id != 0)
                    sqlStr = sqlStr + "where mx.CatgoryId=" + param.Id
                        + "or mx.CatgoryId in (SELECT Id FROM maxcatgory mc WHERE ParentId ="+ param.Id+")";
            }
            object result = await this.BaseRepository().FindObject(sqlStr);
            int sort = result.ParseToInt();
            sort++;
            return sort;
        }

        public async Task<MaxCatgoryEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<MaxCatgoryEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(MaxCatgoryEntity entity)
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
            await this.BaseRepository().Delete<MaxCatgoryEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<MaxCatgoryEntity, bool>> ListFilter(MaxCatgoryListParam param)
        {
            var expression = LinqExtensions.True<MaxCatgoryEntity>();
            if (param != null)
            {
                if(!string.IsNullOrEmpty(param.CatgoryTitle))
                {
                    expression = expression.And(t => t.CatgoryTitle == param.CatgoryTitle);
                }
            }
            else
            {
                expression = expression.And(t => t.Id == 0 && t.BaseIsDelete == 0);
            }
            //expression = expression.And(t => t.BaseIsDelete==0);
            return expression;
        }
        #endregion
    }
}
