using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-09 19:22
    /// 描 述：Max软件分类表实体类
    /// </summary>
    [Table("maxcatgory")]
    public class MaxCatgoryEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 分类标题
        /// </summary>
        /// <returns></returns>
        public string CatgoryTitle { get; set; }
        /// <summary>
        /// 父分类Id(0表示是根分类)
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? ParentId { get; set; }
        /// <summary>
        /// 分类排序
        /// </summary>
        /// <returns></returns>
        public int? CatgorySort { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
    }
}
