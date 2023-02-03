using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.AppManage
{
    /// <summary>
    /// 创 建：wangxd
    /// 日 期：2023-02-03 19:25
    /// 描 述：应用管理实体类
    /// </summary>
    [Table("apps")]
    public class MaxAppsEntity : BaseExtensionEntity
    {
        /// <summary>
        /// AppSecret
        /// </summary>
        /// <returns></returns>
        public string AppID { get; set; }
        /// <summary>
        /// 秘钥
        /// </summary>
        /// <returns></returns>
        public string AppSecret { get; set; }
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
        /// <summary>
        /// 顺序
        /// </summary>
        /// <returns></returns>
        public int? sortIndex { get; set; }
        /// <summary>
        /// 类型，wx,alipay
        /// </summary>
        /// <returns></returns>
        public string type { get; set; }
    }
}
