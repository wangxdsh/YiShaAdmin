using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-04 15:12
    /// 描 述：api授权实体类
    /// </summary>
    [Table("webapiauthorize")]
    public class MaxWebApiAuthorizeEntity : BaseCreateEntity
    {
        /// <summary>
        /// 授权Id(角色Id或者用户Id)
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? AuthorizeId { get; set; }
        /// <summary>
        /// 授权类型(1角色 2用户 3IP)
        /// </summary>
        /// <returns></returns>
        public int? AuthorizeType { get; set; }
        /// <summary>
        /// 限制时间
        /// </summary>
        /// <returns></returns>
        public int? LimitDate { get; set; }
        /// <summary>
        /// 限制次数
        /// </summary>
        /// <returns></returns>
        public int? LimitTimes { get; set; }
        /// <summary>
        /// 限制次数时间(天)
        /// </summary>
        /// <returns></returns>
        public int? LimitTimesLength { get; set; }
        /// <summary>
        /// 限制类型(1时间 2次数 3有效结果次数)
        /// </summary>
        /// <returns></returns>
        public int? LimitType { get; set; }
        /// <summary>
        /// 菜单Id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? WebApiId { get; set; }
    }
}
