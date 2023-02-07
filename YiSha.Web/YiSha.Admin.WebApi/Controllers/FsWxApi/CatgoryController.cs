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
using YiSha.Model.Param.OrganizationManage;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YiSha.Admin.WebApi.Controllers.FsWxApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatgoryController : Controller
    {
        private FsCatgoryBLL newsBLL = new FsCatgoryBLL();
        private FsSubCatgoryBLL subCatgoryBLL = new FsSubCatgoryBLL();
        private FsNewsBLL FsNewsBLL = new FsNewsBLL();
        private static IMapper _mapper;

        public CatgoryController(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region 获取数据
        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<TData<List<FsCatgoryEntityDto>>> GetCategoryList([FromQuery] FsCatgoryListParam param)
        {
            TData<List<FsCatgoryEntity>> obj = await newsBLL.GetList(param);
            TData<List<FsCatgoryEntityDto>> objDto = new TData<List<FsCatgoryEntityDto>>();

            objDto.initDto(obj.Tag, obj.Message, obj.Description, obj.Total);
            objDto.Data = _mapper.Map<List<FsCatgoryEntityDto>>(obj.Data);

            foreach (FsCatgoryEntityDto fsCatgoryEntity in objDto.Data)
            {
                // 拉去结果
                TData<List<FsSubCatgoryEntity>> subCatagory =
                    await subCatgoryBLL.GetListByCatgoryIdForApi(new FsSubCatgoryListParam() { CatgoryId = fsCatgoryEntity.Id });
                if(subCatagory.Data!=null && subCatagory.Data.Count > 0)
                {
                    // map
                    List<FsSubCatgoryEntityDto> tempDtoList = _mapper.Map<List<FsSubCatgoryEntityDto>>(subCatagory.Data);
                    
                    foreach(FsSubCatgoryEntityDto subCatgoryEntityDto in tempDtoList)
                    {
                        TData<List<FsNewsEntity>> obj_news = await FsNewsBLL.GetListForApi(
                            new FsNewsListParam() { subCatgoryId = subCatgoryEntityDto.Id },
                            new Pagination() { PageIndex = 1 ,PageSize = 6}) ;
                        if(obj_news.Data != null && obj_news.Data.Count>0)
                            subCatgoryEntityDto.newsList = _mapper.Map<List<FsNewsEntityDto>>(obj_news.Data);
                    }
                    fsCatgoryEntity.subCatgorys = tempDtoList;
                }
            }
            
            return objDto;
        }

        /// <summary>
        /// 获取指定分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<TData<FsCatgoryEntityDto>> GetForm([FromQuery] long id)
        {
            TData<FsCatgoryEntity>  obj = await newsBLL.GetEntity(id);
            TData<FsCatgoryEntityDto> objDto = new TData<FsCatgoryEntityDto>();
            objDto.initDto(obj.Tag,obj.Message,obj.Description,obj.Total);
            objDto.Data = _mapper.Map<FsCatgoryEntityDto>(obj.Data);
            return objDto;
        }
        #endregion

    }
}

