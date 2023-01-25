using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.AppManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2023-01-11 16:48
    /// 描 述：文章大类实体类
    /// </summary>
    [Table("catgory")]
    public class FsCatgoryEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        /// <summary>
        /// 广告
        /// </summary>
        /// <returns></returns>
        public string CatgoryAd { get; set; }
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
