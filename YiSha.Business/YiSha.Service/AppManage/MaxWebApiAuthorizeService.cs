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
    /// 日 期：2023-02-04 15:12
    /// 描 述：api授权服务类
    /// </summary>
    public class MaxWebApiAuthorizeService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<MaxWebApiAuthorizeEntity>> GetList(MaxWebApiAuthorizeListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<MaxWebApiAuthorizeEntity>> GetPageList(MaxWebApiAuthorizeListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<MaxWebApiAuthorizeEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<MaxWebApiAuthorizeEntity>(id);
        }
        public async Task<MaxWebApiAuthorizeEntity> GetEntityByAuthorizeId(long AuthorizeId)
        {
            return await this.BaseRepository().FindEntity<MaxWebApiAuthorizeEntity>(AuthorizeId);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(MaxWebApiAuthorizeEntity entity)
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
            await this.BaseRepository().Delete<MaxWebApiAuthorizeEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<MaxWebApiAuthorizeEntity, bool>> ListFilter(MaxWebApiAuthorizeListParam param)
        {
            var expression = LinqExtensions.True<MaxWebApiAuthorizeEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
