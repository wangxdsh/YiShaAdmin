using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.AppManage;
using YiSha.Model.Param.AppManage;
using YiSha.Service.AppManage;

namespace YiSha.Business.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-04 15:14
    /// 描 述：webApi日志业务类
    /// </summary>
    public class MaxWebApiLogBLL
    {
        private MaxWebApiLogService maxWebApiLogService = new MaxWebApiLogService();

        #region 获取数据
        public async Task<TData<List<MaxWebApiLogEntity>>> GetList(MaxWebApiLogListParam param)
        {
            TData<List<MaxWebApiLogEntity>> obj = new TData<List<MaxWebApiLogEntity>>();
            obj.Data = await maxWebApiLogService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<MaxWebApiLogEntity>>> GetPageList(MaxWebApiLogListParam param, Pagination pagination)
        {
            TData<List<MaxWebApiLogEntity>> obj = new TData<List<MaxWebApiLogEntity>>();
            obj.Data = await maxWebApiLogService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<MaxWebApiLogEntity>> GetEntity(long id)
        {
            TData<MaxWebApiLogEntity> obj = new TData<MaxWebApiLogEntity>();
            obj.Data = await maxWebApiLogService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(MaxWebApiLogEntity entity)
        {
            TData<string> obj = new TData<string>();
            await maxWebApiLogService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await maxWebApiLogService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
