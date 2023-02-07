using System;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.AppManage
{
    public class FsNewsMqParam
    {
        [JsonConverter(typeof(StringJsonConverter))]
        public long? Id { get; set; }
    }
}

