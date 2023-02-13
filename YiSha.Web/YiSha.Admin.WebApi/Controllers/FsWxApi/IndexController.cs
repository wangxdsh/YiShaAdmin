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
using YiSha.Util;
using YiSha.Util.Model;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YiSha.Admin.WebApi.Controllers.FsWxApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Area("maxsoft")]
    public class IndexController : ControllerBase
    {
        private FsBannerBLL bannerBLL = new FsBannerBLL();
        private FsKingConsBLL kingconsBll = new FsKingConsBLL();
        private FsCatgoryBLL fsCatgoryBLL = new FsCatgoryBLL();
        private FsSubCatgoryBLL fsSubCatgoryBLL = new FsSubCatgoryBLL();
        private PreviewNewsBLL previewNewsBLL = new PreviewNewsBLL();

        private MaxCatgoryBLL maxCatgoryBLL = new MaxCatgoryBLL();
        private MaxNewsCatgorysBLL maxNewsCatgorysBLL = new MaxNewsCatgorysBLL();

        private FsNewsBLL fsNewsBLL = new FsNewsBLL();
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
       // [AuthorizeFilter("maxsoft:index:banner")]
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

        [HttpGet("{msg}")]
        public TData<string> sendMq(string msg)
        {
            TData<string> res = new TData<string>()
            {
                Data = "请求了",
                Message = "发送了:" + msg,
                Tag = 1
            };
            //RabbitMQHelper.sendMessage(JsonConvert.SerializeObject(msg));
            return res;
        }

        [HttpGet]
        public async Task<TData<FsKingConsEntity>> copyCatagory()
        {
            TData<FsKingConsEntity> res = await kingconsBll.GetEntity(1);

            TData<List<PreviewNewsEntity>> data = await previewNewsBLL.GetList(new PreviewNewsListParam());
            List<string> tags = new List<string>();
            foreach(PreviewNewsEntity item in data.Data)
            {
                string[] tempTags = item.NewsTag.Split(",");
                foreach(string tagStr in tempTags)
                {
                    if(!tags.Contains(tagStr))
                    {
                        tags.Add(tagStr);
                    }
                }
            }
            if(tags.Count>0)
            {
                int i = 0;
                foreach(string preData in tags)
                    await maxCatgoryBLL.SaveForm(new MaxCatgoryEntity() { CatgoryTitle = preData,ParentId = 543894528239603712,CatgorySort = (++i) });
            }

            return res;
        }

        [HttpGet]
        public async Task<TData<FsKingConsEntity>> copyContent()
        {
            TData<FsKingConsEntity> res = await kingconsBll.GetEntity(1);

            TData<List<PreviewNewsEntity>> data = await previewNewsBLL.GetList(new PreviewNewsListParam());

            foreach (PreviewNewsEntity item in data.Data.Where(p => p.NewsId == long.Parse("1") ))
            {
                TData<List<FsNewsEntity>> checkList = await fsNewsBLL.GetList(new FsNewsListParam() { NewsTitle = item.NewsTitle });
                if(checkList.Data.Count <= 0 )
                {
                    // 获取分类
                    string[] tempTags = item.NewsTag.Split(",");
                    TData<List<MaxCatgoryEntity>> catObj = await maxCatgoryBLL.GetList(new MaxCatgoryListParam());
                    // 创建实体
                    FsNewsEntity fsNewsEntity = new FsNewsEntity()
                    {
                        NewsTitle = item.NewsTitle,
                        NewsContent = item.NewsContent,
                        NewsTag = item.NewsTag,
                        ThumbImage = item.ThumbImage,
                        NewsSort = (int?)item.RemoteId,
                        NewsAuthor = "pachong",
                        DownLoadUrl = string.Empty,
                    };
                    // 储存实体
                    TData<string> resNewsId = await fsNewsBLL.SaveForm(fsNewsEntity);
                    // 关联分类
                    int sort = 0;
                    foreach (string catName in tempTags)
                    {
                        MaxNewsCatgorysEntity maxNewsCatgorysEntity = new MaxNewsCatgorysEntity();

                        maxNewsCatgorysEntity.NewsId = long.Parse(resNewsId.Data);

                        TData<List<MaxCatgoryEntity>> aimCat = await maxCatgoryBLL.GetList(new MaxCatgoryListParam() { CatgoryTitle = catName });

                        maxNewsCatgorysEntity.CatgoryId = aimCat.Data.FirstOrDefault().Id;
                        maxNewsCatgorysEntity.Sort = ++sort;
                        // 储存分类
                        await maxNewsCatgorysBLL.SaveForm(maxNewsCatgorysEntity);
                    }
                    // 更新爬虫本体
                    item.NewsId = long.Parse(resNewsId.Data);
                    await previewNewsBLL.SaveForm(item);
                }      
            }
            return res;
        }

        [HttpGet]
        public async Task<TData<FsKingConsEntity>> initCatagory()
        {
            TData<FsKingConsEntity> res = await kingconsBll.GetEntity(1);

            TData<List<FsNewsEntity>> data = await fsNewsBLL.GetList(new FsNewsListParam());

            foreach (FsNewsEntity item in data.Data)
            {
                string[] tempTags = item.NewsTag.Split(",");
                foreach (string tagStr in tempTags)
                {
                    TData < List<MaxCatgoryEntity>> maxCatgoryEntity = await maxCatgoryBLL.GetList(new MaxCatgoryListParam() { CatgoryTitle = tagStr });
                    if(maxCatgoryEntity.Data.Count>0)
                    {
                        MaxNewsCatgorysEntity maxNewsCatgorysEntity = new MaxNewsCatgorysEntity()
                        {
                            NewsId = item.Id,
                            CatgoryId = maxCatgoryEntity.Data.FirstOrDefault().Id
                        };
                        await maxNewsCatgorysBLL.SaveForm(maxNewsCatgorysEntity);
                    }
                    
                }
            }

            return res;
        }

        [HttpGet]
        public async Task<TData<FsKingConsEntity>> initContent()
        {
            TData<FsKingConsEntity> res = await kingconsBll.GetEntity(1);

            TData<List<FsNewsEntity>> data = await fsNewsBLL.GetList(new FsNewsListParam());

            foreach (FsNewsEntity item in data.Data)
            {
                string[] tempTags = item.NewsTag.Split(",");
                foreach (string tagStr in tempTags)
                {
                    TData<List<MaxCatgoryEntity>> maxCatgoryEntity = await maxCatgoryBLL.GetList(new MaxCatgoryListParam() { CatgoryTitle = tagStr });
                    if (maxCatgoryEntity.Data.Count > 0)
                    {
                        MaxNewsCatgorysEntity maxNewsCatgorysEntity = new MaxNewsCatgorysEntity()
                        {
                            NewsId = item.Id,
                            CatgoryId = maxCatgoryEntity.Data.FirstOrDefault().Id
                        };
                        await maxNewsCatgorysBLL.SaveForm(maxNewsCatgorysEntity);
                    }

                }
            }

            return res;
        }

        #endregion


    }
}

