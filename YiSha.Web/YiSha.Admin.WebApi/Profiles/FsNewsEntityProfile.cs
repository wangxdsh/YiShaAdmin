using System;
using AutoMapper;
using YiSha.Entity.AppManage;
using YiSha.Model.Result.AppManage;

namespace YiSha.Admin.WebApi.Profiles
{
    public class FsNewsEntityProfile : Profile
    {
        public FsNewsEntityProfile()
        {
            CreateMap<FsNewsEntityDto, FsNewsEntity>().ReverseMap();
        }
    }
}

