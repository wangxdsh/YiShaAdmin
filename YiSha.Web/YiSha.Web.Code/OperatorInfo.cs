using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Web.Code
{
    /// <summary>
    /// 登录用户实体 对应user表
    /// </summary>
    public class OperatorInfo
    {
        [JsonConverter(typeof(StringJsonConverter))]
        public long? UserId { get; set; }
        public int? UserStatus { get; set; }
        public int? IsOnline { get; set; }
        [JsonConverter(typeof(StringJsonConverter))]
        public string UserName { get; set; }
        [JsonConverter(typeof(StringJsonConverter))]
        public string RealName { get; set; }
        public string WebToken { get; set; }
        public string ApiToken { get; set; }
        public int? IsSystem { get; set; }
        public string Portrait { get; set; }

        public long? DepartmentId { get; set; }

        [NotMapped]
        public string DepartmentName { get; set; }

        /// <summary>
        /// 岗位Id
        /// </summary>
        [NotMapped]
        public string PositionIds { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        [NotMapped]
        public string RoleIds { get; set; }
    }
    public class RoleInfo
    {
        public long RoleId { get; set; }
    }

}
