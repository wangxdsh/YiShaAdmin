using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Web.Code
{
    public class MaxSoftUserInfo
    {
        [JsonConverter(typeof(StringJsonConverter))]
        public long? UserId { get; set; }
        [JsonConverter(typeof(StringJsonConverter))]
        public string UserName { get; set; }
        [JsonConverter(typeof(StringJsonConverter))]
        public string RealName { get; set; }
        public string ApiToken { get; set; }
        public int ViewHistory { get; set; }
        public int ShareHistory { get; set; }
        public int DownLoadHistory { get; set; }
    }
}

