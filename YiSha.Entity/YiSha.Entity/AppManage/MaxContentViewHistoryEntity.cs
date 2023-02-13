using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-12 02:42
    /// 描 述：Max软件浏览历史表实体类
    /// </summary>
    [Table("maxcontentviewhistory")]
    public class MaxContentViewHistoryEntity : BaseExtensionEntity
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
        /// 数据id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? NewsId { get; set; }
        /// <summary>
        /// 数据id
        /// </summary>
        /// <returns></returns>
        public string ContentURL { get; set; }
    }
}
