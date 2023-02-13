using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-12 02:44
    /// 描 述：Max会员权益-拥有多少次实体类
    /// </summary>
    [Table("maxuserrights")]
    public class MaxUserRightsEntity : BaseExtensionEntity
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
        /// 获取来源-1分享-2购买-3后台-4登录
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public int? Source { get; set; }
        /// <summary>
        /// 权益id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? RightsId { get; set; }
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
        /// 开始时间
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 每日次数，次卡有效期999
        /// </summary>
        /// <returns></returns>
        public int? DailyTimes { get; set; }
    }
}
