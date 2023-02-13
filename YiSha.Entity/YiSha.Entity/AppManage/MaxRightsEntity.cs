using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-12 02:46
    /// 描 述：Max权益实体类
    /// </summary>
    [Table("maxrights")]
    public class MaxRightsEntity : BaseExtensionEntity
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
        /// 有效期-天
        /// </summary>
        /// <returns></returns>
        public int? ValidTimeLength { get; set; }
        /// <summary>
        /// 每日次数，次卡不计算有效期
        /// </summary>
        /// <returns></returns>
        public int? DailyTimes { get; set; }
    }
}
