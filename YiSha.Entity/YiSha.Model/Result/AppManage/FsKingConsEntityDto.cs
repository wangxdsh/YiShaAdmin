using System;
namespace YiSha.Model.Result.AppManage
{
    public class FsKingConsEntityDto
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        /// <returns></returns>
        public string Title { get; set; }
        /// <summary>
        /// 跳转地址
        /// </summary>
        /// <returns></returns>
        public string LinkUrl { get; set; }
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

