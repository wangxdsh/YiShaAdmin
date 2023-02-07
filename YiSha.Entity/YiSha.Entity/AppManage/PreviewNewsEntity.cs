using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-06 23:45
    /// 描 述：爬虫文章实体类
    /// </summary>
    [Table("previewnews")]
    public class PreviewNewsEntity : BaseCreateEntity
    {
        /// <summary>
        /// 原始id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? RemoteId { get; set; }
        /// <summary>
        /// 本地newId
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? NewsId { get; set; }
        /// <summary>
        /// 新闻标题
        /// </summary>
        /// <returns></returns>
        public string NewsTitle { get; set; }
        /// <summary>
        /// 新闻内容
        /// </summary>
        /// <returns></returns>
        public string NewsContent { get; set; }
        /// <summary>
        /// 新闻标签
        /// </summary>
        /// <returns></returns>
        public string NewsTag { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        /// <returns></returns>
        public string ThumbImage { get; set; }
        /// <summary>
        /// 新闻排序
        /// </summary>
        /// <returns></returns>
        public int? NewsSort { get; set; }
        /// <summary>
        /// 发布者
        /// </summary>
        /// <returns></returns>
        public string NewsAuthor { get; set; }
        /// <summary>
        /// 下载地址
        /// </summary>
        /// <returns></returns>
        public string DownLoadUrl { get; set; }
        /// <summary>
        /// 一级分类
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? CatgoryId { get; set; }
        /// <summary>
        /// 二级分类
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? SubCatgoryId { get; set; }
    }
}
