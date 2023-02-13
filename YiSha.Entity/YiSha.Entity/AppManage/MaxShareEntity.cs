using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-12 02:47
    /// 描 述：Max软件-分享表实体类
    /// </summary>
    [Table("maxshare")]
    public class MaxShareEntity : BaseExtensionEntity
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
        /// 内容id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? NewsId { get; set; }
    }
}
