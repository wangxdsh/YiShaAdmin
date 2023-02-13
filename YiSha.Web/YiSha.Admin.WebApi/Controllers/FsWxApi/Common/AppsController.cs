using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YiSha.Business.AppManage;
using YiSha.Entity.OrganizationManage;
using YiSha.Model.Param;
using YiSha.Model.Param.AppManage;
using YiSha.Util.Model;
using YiSha.Entity.AppManage;
using YiSha.Model.Result.AppManage;
using AutoMapper;
using YiSha.Business.OrganizationManage;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YiSha.Admin.WebApi.Controllers.FsWxApi
{
    [Route("api/[controller]")]
    public class AppsController : Controller
    {
        private MaxAppsBLL maxAppsBLL = new MaxAppsBLL();
        private static IMapper _mapper;

        public AppsController(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// 获取应用信息
        /// </summary>
        /// <param name="id">应用id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<TData<MaxAppsEntityDto>> GetForm([FromQuery] long id)
        {
            TData<MaxCatgoryEntity> obj = await maxAppsBLL.GetEntity(id);
            TData<MaxAppsEntityDto> objDto = new TData<MaxAppsEntityDto>();
            objDto.initDto(obj.Tag, obj.Message, obj.Description, obj.Total);
            objDto.Data = _mapper.Map<MaxAppsEntityDto>(obj.Data);
            return objDto;
        }
    }
}

