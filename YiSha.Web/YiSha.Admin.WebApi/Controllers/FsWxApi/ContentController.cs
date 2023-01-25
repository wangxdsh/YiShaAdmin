using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YiSha.Business.AppManage;
using YiSha.Entity.AppManage;
using YiSha.Model.Param;
using YiSha.Model.Param.AppManage;
using YiSha.Util.Model;
using YiSha.Model.Result.AppManage;
using AutoMapper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YiSha.Admin.WebApi.Controllers.FsWxApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AuthorizeFilter]
    public class ContentController : Controller
    {
        private FsNewsBLL newsBLL = new FsNewsBLL();
        private static IMapper _mapper;

        public ContentController(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region 获取数据
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<TData<List<FsNewsEntity>>> GetPageList([FromQuery] FsNewsListParam param, [FromQuery] Pagination pagination)
        {
            TData<List<FsNewsEntity>> obj = await newsBLL.GetPageList(param, pagination);
            return obj;
        }
        /// <summary>
        /// 分类页-文章列表
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<TData<List<FsNewsEntityDto>>> GetListForApi([FromQuery] FsNewsListParam param, [FromQuery] Pagination pagination)
        {
            TData<List<FsNewsEntity>> obj = await newsBLL.GetListForApi(param, pagination);
            TData<List<FsNewsEntityDto>> objDto = new TData<List<FsNewsEntityDto>>();

            objDto.initDto(obj.Tag, obj.Message, obj.Description, obj.Total);
            objDto.Data = _mapper.Map<List<FsNewsEntityDto>>(obj.Data);

            return objDto;
        }


        /// <summary>
        /// 获取文章内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<TData<FsNewsEntity>> GetForm([FromQuery] long id)
        {
            TData<FsNewsEntity> obj = await newsBLL.GetEntity(id);
            return obj;
        }
        #endregion

        #region 提交数据

        [HttpPost]
        public async Task<TData<string>> SaveContentViewTimes([FromBody] IdParam param)
        {
            TData<string> obj = null;
            TData<FsNewsEntity> objNews = await newsBLL.GetEntity(param.Id.Value);
            FsNewsEntity newsEntity = new FsNewsEntity();
            if (objNews.Data != null)
            {
                newsEntity.Id = param.Id.Value;
                newsEntity.ViewTimes = objNews.Data.ViewTimes;
                newsEntity.ViewTimes++;
                obj = await newsBLL.SaveForm(newsEntity);
            }
            else
            {
                obj = new TData<string>();
                obj.Message = "文章不存在";
            }
            return obj;
        }
        #endregion
    }
}

