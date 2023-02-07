using System;
using AutoMapper;
using YiSha.Entity.AppManage;
using YiSha.Entity.OrganizationManage;
using YiSha.Model.Result.AppManage;

namespace YiSha.Admin.WebApi.Profiles
{
    public class MaxAppsEntityProfile : Profile
    {
        public MaxAppsEntityProfile()
        {
            CreateMap<MaxAppsEntityDto, MaxAppsEntity>().ReverseMap();
        }
    }
}