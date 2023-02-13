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
    /// 日 期：2023-02-12 02:47
    /// 描 述：Max软件-分享表服务类
    /// </summary>
    public class MaxShareService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<MaxShareEntity>> GetList(MaxShareListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<MaxShareEntity>> GetPageList(MaxShareListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<MaxShareEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<MaxShareEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(MaxShareEntity entity)
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
            await this.BaseRepository().Delete<MaxShareEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<MaxShareEntity, bool>> ListFilter(MaxShareListParam param)
        {
            var expression = LinqExtensions.True<MaxShareEntity>();
            if (param != null)
            {
            }
            expression = expression.And(t => t.BaseIsDelete==0);
            return expression;
        }
        #endregion
    }
}
