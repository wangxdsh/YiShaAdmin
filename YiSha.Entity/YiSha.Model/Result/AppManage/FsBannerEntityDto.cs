using System;
namespace YiSha.Model.Result.AppManage
{
    public class FsBannerEntityDto
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

