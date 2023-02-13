using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-09 19:23
    /// 描 述：Max软件所属分类表实体类
    /// </summary>
    [Table("maxnewscatgorys")]
    public class MaxNewsCatgorysEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 分类id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? CatgoryId { get; set; }
        /// <summary>
        /// 内容id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? NewsId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        /// <returns></returns>
        public int? Sort { get; set; }
    }
}
