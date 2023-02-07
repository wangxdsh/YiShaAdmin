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
    /// 创 建：wangxd
    /// 日 期：2023-02-04 15:09
    /// 描 述：webApi管理服务类
    /// </summary>
    public class MaxWebApisService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<MaxWebApisEntity>> GetList(MaxWebApisListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<MaxWebApisEntity>> GetPageList(MaxWebApisListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<MaxWebApisEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<MaxWebApisEntity>(id);
        }
        public async Task<MaxWebApisEntity> GetEntityByAuthorize(long Appid, string Authorize)
        {
            var expression = LinqExtensions.True<MaxWebApisEntity>();
            expression = expression.And(t => t.Authorize == Authorize);
            expression = expression.And(t => t.AppsId == Appid);
            return await this.BaseRepository().FindEntity(expression);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(MaxWebApisEntity entity)
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
            await this.BaseRepository().Delete<MaxWebApisEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<MaxWebApisEntity, bool>> ListFilter(MaxWebApisListParam param)
        {
            var expression = LinqExtensions.True<MaxWebApisEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
