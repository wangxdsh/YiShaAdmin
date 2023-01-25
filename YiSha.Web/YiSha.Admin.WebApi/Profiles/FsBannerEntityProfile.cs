using System;
using AutoMapper;
using YiSha.Entity.AppManage;
using YiSha.Entity.OrganizationManage;
using YiSha.Model.Result.AppManage;

namespace YiSha.Admin.WebApi.Profiles
{
    public class FsBannerEntityProfile : Profile
    {
        public FsBannerEntityProfile()
        {
            CreateMap<FsBannerEntityDto, FsBannerEntity>().ReverseMap();
        }
    }
}

