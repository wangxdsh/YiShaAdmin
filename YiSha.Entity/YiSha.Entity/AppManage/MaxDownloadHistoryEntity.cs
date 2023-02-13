using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-09 19:20
    /// 描 述：Max软件下载记录表实体类
    /// </summary>
    [Table("maxdownloadhistory")]
    public class MaxDownloadHistoryEntity : BaseExtensionEntity
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
        /// <summary>
        /// 是否成功
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? Success { get; set; }
    }
}
