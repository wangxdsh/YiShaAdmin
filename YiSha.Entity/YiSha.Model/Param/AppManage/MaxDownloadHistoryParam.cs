using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-09 19:20
    /// 描 述：Max软件下载记录表实体查询类
    /// </summary>
    public class MaxDownloadHistoryListParam
    {
        [JsonConverter(typeof(StringJsonConverter))]
        public long UserId { get; set; }
        [JsonConverter(typeof(StringJsonConverter))]
        public long NewsId { get; set; }
    }
}
