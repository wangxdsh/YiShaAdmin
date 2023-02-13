using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.AppManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2023-01-11 16:49
    /// 描 述：文章二级分类实体查询类
    /// </summary>
    public class FsSubCatgoryListParam : EntityBaseParam
    {
        /// <summary>
        /// 所属一级分类
        /// </summary>
        public long? CatgoryId { get; set; }
    }
}
