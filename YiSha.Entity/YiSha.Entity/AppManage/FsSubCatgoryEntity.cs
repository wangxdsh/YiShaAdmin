using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.AppManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2023-01-12 14:29
    /// 描 述：文章二级分类实体类
    /// </summary>
    [Table("subcatgory")]
    public class FsSubCatgoryEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 所属一级分类
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? CatgoryId { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        /// <summary>
        /// 广告
        /// </summary>
        /// <returns></returns>
        public string SubCatgoryAd { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        /// <returns></returns>
        public string ThumbImage { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        /// <returns></returns>
        public int? Sort { get; set; }
    }
}
