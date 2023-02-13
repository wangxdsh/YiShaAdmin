using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-12 02:50
    /// 描 述：Max软件-分享表结果,一对一的用户只能分享一次实体类
    /// </summary>
    [Table("maxsharecost")]
    public class MaxShareCostEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 分享用户id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? SUserId { get; set; }
        /// <summary>
        /// 接收用户id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? GUserId { get; set; }
    }
}
