using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.AppManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2023-01-12 16:14
    /// 描 述：资源内容实体查询类
    /// </summary>
    public class FsNewsListParam
    {
        public long? catgoryId { get; set; }
        public long? subCatgoryId { get; set; }
    }
}
