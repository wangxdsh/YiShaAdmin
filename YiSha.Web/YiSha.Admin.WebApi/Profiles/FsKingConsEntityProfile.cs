using System;
using AutoMapper;
using YiSha.Entity.AppManage;
using YiSha.Entity.OrganizationManage;
using YiSha.Model.Result.AppManage;

namespace YiSha.Admin.WebApi.Profiles
{
    public class FsKingConsEntityProfile : Profile
    {
        public FsKingConsEntityProfile()
        {
            CreateMap<FsKingConsEntityDto, FsKingConsEntity>().ReverseMap();
        }
    }
}

