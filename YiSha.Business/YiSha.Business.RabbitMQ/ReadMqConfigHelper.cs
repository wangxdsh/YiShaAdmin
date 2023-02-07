using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NPOI.OpenXml4Net.OPC.Internal;
using YiSha.Entity;
using YiSha.Entity.SystemManage;
using YiSha.Util.Model;

namespace YiSha.Business.RabbitMQ
{
    public class ReadMqConfigHelper : IReadMqConfigHelper
    {
        private readonly ILogger<ReadMqConfigHelper> _logger;
        public IConfiguration Configuration { get; }
        public ReadMqConfigHelper(ILogger<ReadMqConfigHelper> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }
        public MqConfigEntity ReadMqConfig()
        {
            try
            {
                MqConfigEntity config = Configuration.GetSection("MQ").Get<MqConfigEntity>(); // 读取MQ配置信息
                if (config!=null)
                {
                    return config;
                }
                _logger.LogError($"获取MQ配置信息失败：没有可用数据集");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"获取MQ配置信息失败：{ex.Message}");
                return null;
            }
        }
    }
}

