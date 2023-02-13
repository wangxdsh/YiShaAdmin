using System;
using AutoMapper;
using YiSha.Entity.AppManage;
using YiSha.Model.Result.AppManage;

using YiSha.Entity.OrganizationManage;


namespace YiSha.Admin.WebApi.Profiles 
{
    public class MaxCatgoryProfile : Profile
    {
        public MaxCatgoryProfile()
        {
            CreateMap<MaxCatgoryEntityDto, MaxCatgoryEntity>().ReverseMap();
        }
    }
}

