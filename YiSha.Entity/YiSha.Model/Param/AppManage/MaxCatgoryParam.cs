using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-09 19:22
    /// 描 述：Max软件分类表实体查询类
    /// </summary>
    public class MaxCatgoryListParam
    {
        /// <summary>
        /// 所有表的主键
        /// long返回到前端js的时候，会丢失精度，所以转成字符串
        /// </summary>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? Id { get; set; }
        /// <summary>
        /// 父分类Id(0表示是根分类)
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? ParentId { get; set; }

        public string CatgoryTitle { get; set; }
    }
}
