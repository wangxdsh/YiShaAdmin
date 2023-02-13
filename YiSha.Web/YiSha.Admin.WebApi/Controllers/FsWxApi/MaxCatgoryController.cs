using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YiSha.Business.AppManage;
using YiSha.Entity.AppManage;
using YiSha.Model.Param.AppManage;
using YiSha.Model.Result.AppManage;
using YiSha.Util.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YiSha.Admin.WebApi.Controllers.FsWxApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MxCatgoryController : Controller
    {
        private MaxCatgoryBLL maxCatgoryBLL = new MaxCatgoryBLL();
        private FsNewsBLL FsNewsBLL = new FsNewsBLL();
        private static IMapper _mapper;

        public MxCatgoryController(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region 获取数据
        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<TData<List<MaxCatgoryEntityDto>>> GetCategoryList([FromQuery] MaxCatgoryListParam param)
        {
            TData<List<MaxCatgoryEntityDto>> obj = await maxCatgoryBLL.GetCategoryList(param);
            obj.Total = obj.Data.Count();
            foreach (MaxCatgoryEntityDto maxCatgoryEntityDto in obj.Data)
            {
                // 拉去结果
                TData<List<MaxCatgoryEntityDto>> subCatagory =
                    await maxCatgoryBLL.GetCategoryList(new MaxCatgoryListParam() { ParentId = maxCatgoryEntityDto.Id});

                maxCatgoryEntityDto.subCatgoryList =subCatagory.Data.Where(p=>p.ConentCount>0).ToList();
            }
            return obj;
        }
        #endregion

    }
}

