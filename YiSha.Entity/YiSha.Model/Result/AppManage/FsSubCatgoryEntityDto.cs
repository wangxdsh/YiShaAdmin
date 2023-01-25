using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using YiSha.Util;

namespace YiSha.Model.Result.AppManage
{
    public class FsSubCatgoryEntityDto
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
        [JsonConverter(typeof(StringJsonConverter))]
        public long? Id { get; set; }

        public List<FsNewsEntityDto> newsList { get; set; }
    }
}

