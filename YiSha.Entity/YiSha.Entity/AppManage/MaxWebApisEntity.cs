using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-04 15:09
    /// 描 述：webApi管理实体类
    /// </summary>
    [Table("webapis")]
    public class MaxWebApisEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        public int? ApiStatus { get; set; }
        /// <summary>
        /// 所属应用id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? AppsId { get; set; }
        /// <summary>
        /// 权限标识
        /// </summary>
        /// <returns></returns>
        public string Authorize { get; set; }
        /// <summary>
        /// 接口名称
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// 权限状态 1-限制权限，0-公开
        /// </summary>
        /// <returns></returns>
        public int? RolesStatus { get; set; }
    }
}
