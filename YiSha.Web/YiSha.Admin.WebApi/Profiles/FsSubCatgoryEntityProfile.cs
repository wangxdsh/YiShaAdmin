using System;
using AutoMapper;
using YiSha.Entity.AppManage;
using YiSha.Entity.OrganizationManage;
using YiSha.Model.Result.AppManage;

namespace YiSha.Admin.WebApi.Profiles
{
    public class FsSubCatgoryEntityProfile : Profile
    {
        public FsSubCatgoryEntityProfile()
        {
            CreateMap<FsSubCatgoryEntityDto, FsSubCatgoryEntity>().ReverseMap();
        }
    }
}

