using System;
using System.Text.Json.Serialization;
using YiSha.Util;

namespace YiSha.Model.Result.AppManage
{
    public class MaxAppsEntityDto
    {
        /// <summary>
        /// 所有表的主键
        /// long返回到前端js的时候，会丢失精度，所以转成字符串
        /// </summary>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? Id { get; set; }
        /// <summary>
        /// 审核中(0正常运行 1审核中)
        /// </summary>
        /// <returns></returns>
        public int? IsReviewing { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        /// <summary>
        /// 二维码
        /// </summary>
        /// <returns></returns>
        public string QRImage { get; set; }
        /// <summary>
        /// 分享图片链接
        /// </summary>
        /// <returns></returns>
        public string shareImage { get; set; }

    }
}

