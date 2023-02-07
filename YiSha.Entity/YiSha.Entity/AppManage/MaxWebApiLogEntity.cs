using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-04 15:14
    /// 描 述：webApi日志实体类
    /// </summary>
    [Table("webapilog")]
    public class MaxWebApiLogEntity : BaseCreateEntity
    {
        /// <summary>
        /// 用户id
        /// </summary>
        /// <returns></returns>
        public string AuthorizeId { get; set; }
        /// <summary>
        /// 请求参数
        /// </summary>
        /// <returns></returns>
        public string ExecuteParam { get; set; }
        /// <summary>
        /// 请求结果
        /// </summary>
        /// <returns></returns>
        public string ExecuteResult { get; set; }
        /// <summary>
        /// 总计执行次数
        /// </summary>
        /// <returns></returns>
        public int? ExecuteTime { get; set; }
        /// <summary>
        /// 接口地址
        /// </summary>
        /// <returns></returns>
        public string ExecuteUrl { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        /// <returns></returns>
        public string IP { get; set; }
        /// <summary>
        /// 是否计算累加
        /// </summary>
        /// <returns></returns>
        public int? IsAddExcuteTime { get; set; }
        /// <summary>
        /// 执行状态(0失败 1成功)
        /// </summary>
        /// <returns></returns>
        public int? LogStatus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// 菜单Id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? WebApiId { get; set; }
    }
}
