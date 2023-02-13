using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-12 02:44
    /// 描 述：Max会员权益-拥有多少次实体查询类
    /// </summary>
    public class MaxUserRightsListParam
    {
        /// <summary>
        /// 用户id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? UserId { get; set; }
        /// <summary>
        /// 应用id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? AppsId { get; set; }
        /// <summary>
        /// 权益名称
        /// </summary>
        /// <returns></returns>
        public string RightsName { get; set; }
        /// <summary>
        /// 权益名称
        /// </summary>
        /// <returns></returns>
        public int? Source { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? StartTime { get; set; }
    }
}
