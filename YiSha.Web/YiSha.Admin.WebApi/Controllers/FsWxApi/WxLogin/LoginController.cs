using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using YiSha.Business.OrganizationManage;
using YiSha.Entity.OrganizationManage;
using YiSha.Enum;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Web.Code;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreWeChatCode2Session.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly WeChat _weChat;

        private UserBLL userBLL = new UserBLL();

        static string session_key = "";
        public LoginController(WeChat weChat)
        {
            _weChat = weChat;
        }
        /// <summary>
        ///  响应 uni.login,用code换openid，生成新的token
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("{code}")]
        public async Task<IActionResult> Get(string code)
        {
            var res = await _weChat.GetCode2Session(new WeChat.Code2SessionParamter(code));
            session_key = res.session_key;
            string openId = res.openid;
            TData<OperatorInfo> obj = new TData<OperatorInfo>();
            if (!string.IsNullOrEmpty(openId))
            {
                //1. 使用openId 获取用户
                //2. 如果没有，就创建一个新用户
                //3. 生成token
                TData<UserEntity> userObj = await userBLL.CheckLogin(openId);
                if (userObj.Data != null && userObj.Tag == 1)
                {
                    await new UserBLL().UpdateUser(userObj.Data);
                    await Operator.Instance.AddCurrent(userObj.Data.ApiToken);
                    obj.Data = await Operator.Instance.Current(userObj.Data.ApiToken);
                }
                else if (userObj.Data == null)
                {
                    Random r = new Random();
                    UserEntity user = new UserEntity()
                    {
                        UserName = r.Next(1000000, 11000000).ToString(),
                        Password = "123456",
                        RealName = "微信用户" + r.Next(1000000, 11000000),
                        Wechat = openId,
                        Gender = 1,
                        IsSystem = 0,
                        UserStatus = 1,
                        FirstVisit = DateTime.Now,
                        PreviousVisit = DateTime.Now,
                        LastVisit = DateTime.Now,
                        ApiToken = SecurityHelper.GetGuid(true)
                    };
                    TData<string> addRes = await new UserBLL().SaveForm(user);
                    if (addRes.Tag == 1)
                    {
                        await Operator.Instance.AddCurrent(user.ApiToken);
                        obj.Data = await Operator.Instance.Current(user.ApiToken);
                        userObj.Message = "创建了新的用户！";
                    }
                }
                obj.Tag = userObj.Tag;
                obj.Message = userObj.Message;
            }
            else
            {
                obj.Tag = 0;
                obj.Message = "code过期，重新申请code再试。code时效5分钟";
            }
            
            
            // 注意: 这里是为了方便演示，开发的时候不应该去传给前端。
            // 为了数据不被篡改，开发者不应该把 session_key 传到小程序客户端等服务器外的环境。
            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginParameter parameter)
        {
            if (!string.IsNullOrEmpty(parameter.code)) await Get(parameter.code);
            
            return new JsonResult(_weChat.GetUserInfo(parameter.iv, parameter.encryptedData, session_key, parameter.rawData, parameter.signature));
        }
        /// <summary>
        /// token校验
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("LoginByToken/{token}")]
        public async Task<IActionResult> LoginByToken(string token)
        {
            TData<OperatorInfo> obj = new TData<OperatorInfo>();
            // 从缓存和数据库，先拿 OperatorInfo
            OperatorInfo user = await Operator.Instance.Current(token);
            if(user != null)
            {
                //1. 到数据库里找用户，找到后更新登录信息，如果过期了，让用户重新登录，重新发token
                TData<UserEntity> userObj = await userBLL.CheckLoginByToken(token);
                //2. 找到用户，且未过期，返回操作对象，更新缓存
                if (userObj.Data != null && userObj.Tag == 1)
                {
                    await new UserBLL().UpdateUser(userObj.Data);
                    await Operator.Instance.AddCurrent(userObj.Data.ApiToken);
                    obj.Data = await Operator.Instance.Current(userObj.Data.ApiToken);
                }
                obj.Tag = userObj.Tag;
                obj.Message = userObj.Message;
            }
            else
            {
                obj.Tag = 0;
                obj.Message = "缓存里没的账号！";
            }
            
            return new JsonResult(obj);;
        }

        public class LoginParameter
        {
            /// <summary>
            /// 用于解析session_key
            /// </summary>
            public string? code { get; set; }
            /// <summary>
            /// 不包括敏感信息的原始数据字符串，用于计算签名
            /// </summary>
            public string rawData { get; set; }

            /// <summary>
            /// 包括敏感数据在内的完整用户信息的加密数据
            /// </summary>
            public string encryptedData { get; set; }
            /// <summary>
            /// 加密算法的初始向量
            /// </summary>
            public string iv { get; set; }
            /// <summary>
            /// 使用 sha1( rawData + sessionkey ) 得到字符串，用于校验用户信息
            /// </summary>
            public string signature { get; set; }
        }
    }
}
