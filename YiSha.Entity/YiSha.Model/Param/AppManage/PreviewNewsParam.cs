using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-06 23:45
    /// 描 述：爬虫文章实体查询类
    /// </summary>
    public class PreviewNewsListParam
    {
        /// <summary>
        /// 原始id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? RemoteId { get; set; }
    }
}
