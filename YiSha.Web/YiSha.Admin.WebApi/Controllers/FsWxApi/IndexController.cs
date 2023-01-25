using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YiSha.Business.AppManage;
using YiSha.Business.OrganizationManage;
using YiSha.Entity.AppManage;
using YiSha.Entity.OrganizationManage;
using YiSha.Model.Param;
using YiSha.Model.Param.AppManage;
using YiSha.Model.Param.OrganizationManage;
using YiSha.Model.Result.AppManage;
using YiSha.Util.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YiSha.Admin.WebApi.Controllers.FsWxApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AuthorizeFilter]
    public class IndexController : ControllerBase
    {
        private FsBannerBLL bannerBLL = new FsBannerBLL();
        private FsKingConsBLL kingconsBll = new FsKingConsBLL();


        private static IMapper _mapper;

        public IndexController(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region 获取数据

        /// <summary>
        /// 获取Banner图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<TData<List<FsBannerEntityDto>>> GetBanner([FromQuery] FsBannerListParam param)
        {
            TData<List<FsBannerEntity>> obj = await bannerBLL.GetList(param);
            TData<List<FsBannerEntityDto>> objDto = new TData<List<FsBannerEntityDto>>();
            objDto.initDto(obj.Tag, obj.Message, obj.Description, obj.Total);
            objDto.Data = _mapper.Map<List<FsBannerEntityDto>>(obj.Data);
            return objDto;
        }

        /// <summary>
        /// 获取金刚位
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<TData<List<FsKingConsEntityDto>>> GetKingCons([FromQuery] FsKingConsListParam param)
        {
            TData<List<FsKingConsEntity>> obj = await kingconsBll.GetList(param);
            TData<List<FsKingConsEntityDto>> objDto = new TData<List<FsKingConsEntityDto>>();
            objDto.initDto(obj.Tag, obj.Message, obj.Description, obj.Total);
            objDto.Data = _mapper.Map<List<FsKingConsEntityDto>>(obj.Data);
            return objDto;
        }
        #endregion

        
    }
}

