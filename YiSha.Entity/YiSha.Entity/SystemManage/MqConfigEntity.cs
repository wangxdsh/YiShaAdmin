using System;
namespace YiSha.Entity.SystemManage
{
    public class MqConfigEntity
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string ExchangeName { get; set; }
        public bool Durable { get; set; }
    }
}

