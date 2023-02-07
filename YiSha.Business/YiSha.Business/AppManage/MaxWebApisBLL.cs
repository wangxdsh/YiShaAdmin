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
    /// 日 期：2023-02-04 15:09
    /// 描 述：webApi管理业务类
    /// </summary>
    public class MaxWebApisBLL
    {
        private MaxWebApisService maxWebApisService = new MaxWebApisService();

        #region 获取数据
        public async Task<TData<List<MaxWebApisEntity>>> GetList(MaxWebApisListParam param)
        {
            TData<List<MaxWebApisEntity>> obj = new TData<List<MaxWebApisEntity>>();
            obj.Data = await maxWebApisService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<MaxWebApisEntity>>> GetPageList(MaxWebApisListParam param, Pagination pagination)
        {
            TData<List<MaxWebApisEntity>> obj = new TData<List<MaxWebApisEntity>>();
            obj.Data = await maxWebApisService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<MaxWebApisEntity>> GetEntity(long id)
        {
            TData<MaxWebApisEntity> obj = new TData<MaxWebApisEntity>();
            obj.Data = await maxWebApisService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        public async Task<TData<MaxWebApisEntity>> GetEntityByAuthorize(long Appid,string Authorize)
        {
            TData<MaxWebApisEntity> obj = new TData<MaxWebApisEntity>();
            obj.Data = await maxWebApisService.GetEntityByAuthorize(Appid, Authorize);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(MaxWebApisEntity entity)
        {
            TData<string> obj = new TData<string>();
            await maxWebApisService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await maxWebApisService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
