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
    /// 日 期：2023-02-03 19:25
    /// 描 述：应用管理服务类
    /// </summary>
    public class MaxAppsService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<MaxCatgoryEntity>> GetList(MaxAppsListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<MaxCatgoryEntity>> GetPageList(MaxAppsListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<MaxCatgoryEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<MaxCatgoryEntity>(id);
        }
        public async Task<int> GetMaxSort()
        {
            object result = await this.BaseRepository().FindObject("SELECT MAX(sortIndex) FROM apps");
            int sort = result.ParseToInt();
            sort++;
            return sort;
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
        private Expression<Func<MaxCatgoryEntity, bool>> ListFilter(MaxAppsListParam param)
        {
            var expression = LinqExtensions.True<MaxCatgoryEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
