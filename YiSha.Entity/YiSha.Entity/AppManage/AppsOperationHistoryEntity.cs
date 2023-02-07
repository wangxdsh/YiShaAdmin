using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-04 15:15
    /// 描 述：用户操作历史-业务实体类
    /// </summary>
    [Table("appsoperationhistory")]
    public class AppsOperationHistoryEntity : BaseCreateEntity
    {
        /// <summary>
        /// 应用id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? AppsId { get; set; }
        /// <summary>
        /// 类型(客户端自定义)
        /// </summary>
        /// <returns></returns>
        public string OperationType { get; set; }
        /// <summary>
        /// 操作参数
        /// </summary>
        /// <returns></returns>
        public string Param { get; set; }
        /// <summary>
        /// 操作结果
        /// </summary>
        /// <returns></returns>
        public string Result { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? UserId { get; set; }
        /// <summary>
        /// 接口
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? WebApiId { get; set; }
    }
}
