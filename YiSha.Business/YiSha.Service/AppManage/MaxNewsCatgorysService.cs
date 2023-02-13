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
    /// 日 期：2023-02-09 19:23
    /// 描 述：Max软件所属分类表服务类
    /// </summary>
    public class MaxNewsCatgorysService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<MaxNewsCatgorysEntity>> GetList(MaxNewsCatgorysListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<MaxNewsCatgorysEntity>> GetPageList(MaxNewsCatgorysListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }
        public async Task<int> GetMaxSort()
        {
            object result = await this.BaseRepository().FindObject("SELECT MAX(Sort) FROM maxnewscatgorys");
            int sort = result.ParseToInt();
            sort++;
            return sort;
        }

        public async Task<MaxNewsCatgorysEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<MaxNewsCatgorysEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(MaxNewsCatgorysEntity entity)
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
            await this.BaseRepository().Delete<MaxNewsCatgorysEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<MaxNewsCatgorysEntity, bool>> ListFilter(MaxNewsCatgorysListParam param)
        {
            var expression = LinqExtensions.True<MaxNewsCatgorysEntity>();
            if (param != null)
            {
            }
            expression = expression.And(t => t.BaseIsDelete==0);
            return expression;
        }
        #endregion
    }
}
