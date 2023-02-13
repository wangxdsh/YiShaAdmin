using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Result.AppManage
{
    public class MaxCatgoryEntityDto
    {
        /// <summary>
        /// 所有表的主键
        /// long返回到前端js的时候，会丢失精度，所以转成字符串
        /// </summary>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? Id { get; set; }
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
        /// 分类排序
        /// </summary>
        /// <returns></returns>
        public int? ConentCount { get; set; }
        
        public List<MaxCatgoryEntityDto> subCatgoryList { get; set; }

}
}

