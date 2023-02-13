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
using Newtonsoft.Json;
using YiSha.Util;
using YiSha.Business.OrganizationManage;
using YiSha.Entity.OrganizationManage;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YiSha.Admin.WebApi.Controllers.FsWxApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContentController : Controller
    {
        private FsNewsBLL newsBLL = new FsNewsBLL();
        private UserBLL userBLL = new UserBLL();
        private MaxRightsBLL maxRightsBLL = new MaxRightsBLL();
        private MaxRightsCostBLL maxRightsCostBLL = new MaxRightsCostBLL();

        private MaxContentViewHistoryBLL maxContentViewHistoryBLL = new MaxContentViewHistoryBLL();
        private MaxDownloadHistoryBLL downloadHistoryBLL = new MaxDownloadHistoryBLL();

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
        /// 分类页-文章列表
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<TData<List<FsNewsEntityDto>>> GetContentHistory([FromQuery] FsNewsListParam param, [FromQuery] Pagination pagination)
        {
            TData<List<FsNewsEntityDto>> objDto = new TData<List<FsNewsEntityDto>>();
            string ApiToken = HttpContext.Request.Headers["ApiToken"];
            if (!string.IsNullOrEmpty(ApiToken) && param.HistoryType != 0 )
            {
                TData<UserEntity> user = await userBLL.GetUserByToken(ApiToken);
                if (user.Data != null)
                {
                    TData<List<FsNewsEntity>> obj = await newsBLL.GetHistory((long)user.Data.Id, param.HistoryType, pagination);
                    objDto.initDto(obj.Tag, obj.Message, obj.Description, obj.Total);
                    objDto.Data = _mapper.Map<List<FsNewsEntityDto>>(obj.Data);
                }
                else
                {
                    objDto.Tag = 3;
                    objDto.Message = "未找到用户";
                }
            }
            else
            {
                objDto.Tag = 3;
                objDto.Message = "登录失效";
            }
            
            return objDto;
        }

        /// <summary>
        /// 获取文章内容,不验证登录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<TData<FsNewsEntity>> GetForm([FromQuery] long id)
        {
            TData<FsNewsEntity> obj = await newsBLL.GetEntity(id);
            
            if (obj.Data != null)
            {
                MaxContentViewHistoryEntity maxContentViewHistoryEntity = new MaxContentViewHistoryEntity()
                {
                    NewsId = obj.Data.Id
                };
                
                if(!string.IsNullOrEmpty(HttpContext.Request.Headers["ApiToken"]))
                {
                    TData<UserEntity> user = await userBLL.GetUserByToken(HttpContext.Request.Headers["ApiToken"]);
                    maxContentViewHistoryEntity.UserId = user.Data.Id;
                }
                await maxContentViewHistoryBLL.SaveForm(maxContentViewHistoryEntity);

                if (obj.Data.DownLoadUrl.Contains("123mac.cn") || string.IsNullOrEmpty(obj.Data.DownLoadUrl))
                {
                    RabbitMQHelper.sendMessage(JsonConvert.SerializeObject(new FsNewsMqParam() { Id = id }));
                    FsNewsEntity temp = obj.Data;
                    temp.DownLoadUrl = "loading";
                    await newsBLL.SaveForm(temp);
                }
            }
            return obj;
        }
        /// <summary>
        /// 校验文章是否下载过
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<TData<int>> HasDownLoad(long id)
        {
            TData<int> obj = new TData<int>()
            {
                Tag = 3,
                Message = "校验失败"
            };
            string token = HttpContext.Request.Headers["ApiToken"];
            if (!string.IsNullOrEmpty(token) || id != 0)
            {
                TData<UserEntity> user = await userBLL.GetUserByToken(token);
                if (user.Data != null)
                {
                    TData<List<MaxRightsCostEntity>> maxDownloadHistoryEntity = await maxRightsCostBLL.GetList(new MaxRightsCostListParam()
                    {
                        NewsId = id,
                        UserId = (long)user.Data.Id
                    });
                    obj.Tag = 1;
                    if (maxDownloadHistoryEntity.Data.Count > 0)
                    {
                        obj.Message = "已下载";
                        obj.Data = 1;
                    }
                    else
                    {
                        obj.Message = "没下载过";
                        obj.Data = 0;
                    }
                }
                else
                {
                    obj.Message = "找不到对应用户";
                }

            }
            else
            {
                obj.Message = "登录失效";
            }
            return obj;
        }

        [HttpGet]
        public async Task<TData<string>> getDownLoadUrlById([FromQuery] long id)
        {
            TData<string> resObj = new TData<string>();
            string ApiToken = HttpContext.Request.Headers["ApiToken"];
            if (!string.IsNullOrEmpty(ApiToken))
            {
                TData<UserEntity> user = await userBLL.GetUserByToken(ApiToken);
                if (user.Data != null)
                {
                    TData <int> rightCount = await maxRightsBLL.GetRightsCount((long)user.Data.Id);
                    TData<FsNewsEntity> newObj = await newsBLL.GetEntity(id);
                    if (newObj.Data != null)
                    {
                        // 下载历史
                        MaxDownloadHistoryEntity downloadHistoryEntity = new MaxDownloadHistoryEntity()
                        {
                            UserId = user.Data.Id,
                            NewsId = newObj.Data.Id,
                            Success = 0
                        };
                        
                        if (newObj.Data.DownLoadUrl.Contains("123mac.cn") || string.IsNullOrEmpty(newObj.Data.DownLoadUrl))
                        {
                            resObj.Tag = 2;//表示发送抓取请求
                            resObj.Message = "资源解析中...";
                            resObj.Total = 1;
                            RabbitMQHelper.sendMessage(JsonConvert.SerializeObject(new FsNewsMqParam() { Id = id }));
                            newObj.Data.DownLoadUrl = "loading";
                            await newsBLL.SaveForm(newObj.Data);
                        }
                        else if (newObj.Data.DownLoadUrl.Equals("loading"))
                        {
                            resObj.Message = "资源解析中...";
                            resObj.Tag = 2;
                            resObj.Total = 1;
                        }
                        else if (!string.IsNullOrEmpty(newObj.Data.DownLoadUrl))
                        {
                            downloadHistoryEntity.Success = 1;
                            resObj.Data = newObj.Data.DownLoadUrl;
                            resObj.Tag = newObj.Tag;
                            resObj.Total = 1;
                            TData<List<MaxRightsCostEntity>> cost = await maxRightsCostBLL.GetList(new MaxRightsCostListParam() {
                                UserId = (long)user.Data.Id,
                                NewsId = (long)newObj.Data.Id,
                            });
                            if(cost.Data.Count==0)
                            {
                                MaxRightsCostEntity maxRightsCostEntity = new MaxRightsCostEntity()
                                {
                                    UserId = user.Data.Id,
                                    NewsId = newObj.Data.Id,
                                    UseDate = DateTime.Now
                                };
                                
                                await maxRightsCostBLL.SaveForm(maxRightsCostEntity);
                            }
                        }
                        await downloadHistoryBLL.SaveForm(downloadHistoryEntity);

                    }
                    else
                    {
                        resObj.Data = string.Empty;
                        resObj.Message = "资源无效";
                        resObj.Tag = 5;
                        resObj.Total = 0;
                    }
                    if(rightCount.Data <= 0)
                    {
                        resObj.Data = string.Empty;
                        resObj.Message = "免费次数已用完";
                        resObj.Tag = 4;
                        resObj.Total = 0;
                    }
                }
                else
                {
                    resObj.Tag = 3;
                    resObj.Message = "登录信息已失效";
                }
            }
            else
            {
                resObj.Message = "请登录";
                resObj.Tag = 3;
            }
            // 1.成功 2.资源加载中 3.登录失效 4.次数用完  5.资源无效
            
            return resObj;
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

