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
    /// 描 述：Max权益服务类
    /// </summary>
    public class MaxRightsService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<MaxRightsEntity>> GetList(MaxRightsListParam param)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter(param, strSql);
            var list = await this.BaseRepository().FindList<MaxRightsEntity>(strSql.ToString(), filter.ToArray());
            return list.ToList();
        }

        public async Task<List<MaxRightsEntity>> GetPageList(MaxRightsListParam param, Pagination pagination)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter(param, strSql);
            var list = await this.BaseRepository().FindList<MaxRightsEntity>(strSql.ToString(), filter.ToArray(), pagination);
            return list.ToList();
        }

        public async Task<MaxRightsEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<MaxRightsEntity>(id);
        }

        public async Task<int> GetRightsCount(long id,DateTime checkDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT SUM(mur.DailyTimes)-(SELECT count(Id) FROM MaxRightsCost mrc WHERE mrc.BaseIsDelete=0 And UserId=@UserId)  ");
            strSql.Append(@" from MaxUserRights mur where UserId=@UserId AND mur.BaseIsDelete=0 ");
            strSql.Append(@" AND mur.StartTime>DATE(@checkDate) AND DATE(@checkDate)<DATE(mur.EndTime)   ");

            var parameter = new List<DbParameter>();
            parameter.Add(DbParameterExtension.CreateDbParameter("@UserId", id));
            parameter.Add(DbParameterExtension.CreateDbParameter("@checkDate", checkDate));

            object result = await this.BaseRepository().FindObject(strSql.ToString(), parameter.ToArray());
            int sort = result.ParseToInt();
            return sort;
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(MaxRightsEntity entity)
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
            await this.BaseRepository().Delete<MaxRightsEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<MaxRightsEntity, bool>> ListFilter(MaxRightsListParam param)
        {
            var expression = LinqExtensions.True<MaxRightsEntity>();
            if (param != null)
            {
            }
            expression = expression.And(t => t.BaseIsDelete==0);
            return expression;
        }
        private List<DbParameter> ListFilter(MaxRightsListParam param, StringBuilder strSql)
        {
            strSql.Append(@"SELECT  a.Id,
                                    a.UserId,
                                    a.AppsId,
                                    a.RightsName,
                                    a.ValidTimeLength,a.DailyTimes ");
            strSql.Append(@" from MaxRights a where 1=1 and BaseIsDelete=0");
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
                if (param.AppsId != null && !param.AppsId.ToString().Equals("0"))
                {
                    strSql.Append(" AND a.AppsId=@AppsId  ");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@Source", param.AppsId));
                }
            }
            return parameter;
        }
        #endregion
    }
}
