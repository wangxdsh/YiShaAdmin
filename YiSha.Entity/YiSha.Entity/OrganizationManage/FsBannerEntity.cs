using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.OrganizationManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2023-01-09 16:06
    /// 描 述：Banner管理实体类
    /// </summary>
    [Table("banner")]
    public class FsBannerEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        /// <returns></returns>
        public string BannerName { get; set; }
        /// <summary>
        /// 图片链接
        /// </summary>
        /// <returns></returns>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 跳转链接
        /// </summary>
        /// <returns></returns>
        public string LinkUrl { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        /// <returns></returns>
        public int? sortIndex { get; set; }
    }
}
