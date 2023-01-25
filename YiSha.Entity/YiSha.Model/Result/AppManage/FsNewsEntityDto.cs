using System;
using YiSha.Util;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace YiSha.Model.Result.AppManage
{
    public class FsNewsEntityDto
    {
        /// <summary>
        /// 新闻标题
        /// </summary>
        /// <returns></returns>
        public string NewsTitle { get; set; }
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
        /// 查看次数
        /// </summary>
        /// <returns></returns>
        public int? ViewTimes { get; set; }

        public DateTime? BaseCreateTime { get; set; }
        [JsonConverter(typeof(StringJsonConverter))]
        public long? Id;
    }
}

