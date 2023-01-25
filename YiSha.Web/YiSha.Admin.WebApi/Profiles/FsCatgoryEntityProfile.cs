using System;
using AutoMapper;
using YiSha.Entity.AppManage;
using YiSha.Model.Result.AppManage;

namespace YiSha.Admin.WebApi.Profiles
{
    public class FsCatgoryEntityProfile : Profile
    {
        public FsCatgoryEntityProfile()
        {
            CreateMap<FsCatgoryEntityDto, FsCatgoryEntity>().ReverseMap();
        }
    }
}

