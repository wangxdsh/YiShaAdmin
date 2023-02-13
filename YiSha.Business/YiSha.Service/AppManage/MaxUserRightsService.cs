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
    /// 日 期：2023-02-12 02:44
    /// 描 述：Max会员权益-拥有多少次服务类
    /// </summary>
    public class MaxUserRightsService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<MaxUserRightsEntity>> GetList(MaxUserRightsListParam param)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter(param, strSql);
            var list = await this.BaseRepository().FindList<MaxUserRightsEntity> (strSql.ToString(), filter.ToArray());
            return list.ToList();
        }

        public async Task<List<MaxUserRightsEntity>> GetPageList(MaxUserRightsListParam param, Pagination pagination)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter(param, strSql);
            var list= await this.BaseRepository().FindList<MaxUserRightsEntity>(strSql.ToString(), filter.ToArray(), pagination);
            return list.ToList();
        }

        public async Task<MaxUserRightsEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<MaxUserRightsEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(MaxUserRightsEntity entity)
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
            await this.BaseRepository().Delete<MaxUserRightsEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<MaxUserRightsEntity, bool>> ListFilter(MaxUserRightsListParam param)
        {
            var expression = LinqExtensions.True<MaxUserRightsEntity>();
            if (param != null)
            {
            }
            expression = expression.And(t => t.BaseIsDelete==0);
            return expression;
        }
        private List<DbParameter> ListFilter(MaxUserRightsListParam param, StringBuilder strSql)
        {
            strSql.Append(@"SELECT  a.Id,
                                    a.UserId,
                                    a.AppsId,
                                    a.Source,
                                    a.RightsId,
                                    a.RightsName,
                                    a.ValidTimeLength,
                                    a.StartTime,
                                    a.EndTime,a.DailyTimes ");
            strSql.Append(@" from MaxUserRights a where 1=1 and BaseIsDelete=0");
            var parameter = new List<DbParameter>();
            if (param != null)
            {
                if (param.UserId != null && !param.UserId.ToString().Equals("0"))
                {
                    strSql.Append(" AND a.UserId=@UserId  ");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@UserId", param.UserId));
                }
                if (!string.IsNullOrEmpty(param.RightsName))
                {
                    strSql.Append(" AND a.RightsName=@RightsName  ");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@RightsName", param.RightsName));
                }
                if (param.Source != null && !param.Source.ToString().Equals("0"))
                {
                    strSql.Append(" AND a.Source=@Source  ");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@Source", param.Source));
                }
            }
            return parameter;
        }
        #endregion
    }
}
