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
    /// 日 期：2023-02-12 02:46
    /// 描 述：Max软件-权益消费表服务类
    /// </summary>
    public class MaxRightsCostService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<MaxRightsCostEntity>> GetList(MaxRightsCostListParam param)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter(param, strSql);
            var list = await this.BaseRepository().FindList<MaxRightsCostEntity>(strSql.ToString(), filter.ToArray());
            return list.ToList();
        }

        public async Task<List<MaxRightsCostEntity>> GetPageList(MaxRightsCostListParam param, Pagination pagination)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter(param, strSql);
            var list = await this.BaseRepository().FindList<MaxRightsCostEntity>(strSql.ToString(), filter.ToArray(), pagination);
            return list.ToList();
        }

        public async Task<MaxRightsCostEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<MaxRightsCostEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(MaxRightsCostEntity entity)
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
            await this.BaseRepository().Delete<MaxRightsCostEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<MaxRightsCostEntity, bool>> ListFilter(MaxRightsCostListParam param)
        {
            var expression = LinqExtensions.True<MaxRightsCostEntity>();
            if (param != null)
            {
            }
            expression = expression.And(t => t.BaseIsDelete==0);
            return expression;
        }
        private List<DbParameter> ListFilter(MaxRightsCostListParam param, StringBuilder strSql)
        {
            strSql.Append(@"SELECT  a.Id,
                                    a.UserId,
                                    a.AppsId,
                                    a.NewsId,
                                    a.UseDate ");
            strSql.Append(@" from MaxRightsCost a where 1=1 and BaseIsDelete=0");
            var parameter = new List<DbParameter>();
            if (param != null)
            {
                if (param.UserId != 0)
                {
                    strSql.Append(" AND a.UserId=@UserId  ");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@UserId", param.UserId));
                }
                if (param.NewsId != 0)
                {
                    strSql.Append(" AND a.NewsId=@NewsId  ");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@NewsId", param.NewsId));
                }
            }
            return parameter;
        }
        #endregion
    }
}
