using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace YiSha.Util
{
    public static class RabbitMQHelper
    {
        static ConnectionFactory factory = new ConnectionFactory()
        {
            HostName = "123.60.183.221",                //要连接到的主机，默认为 localhost
            Port = 5672,                    //连接断开，默认为 -1(5672)
            UserName = "wangxd",                 //RabbitMQ 连接用户名，默认为 guest
            Password = "shfogomq",                 //RabbitMQ 连接密码，默认为 guest
        };

        public static bool sendMessage(string msg)
        {
            //1:创建一个连接的工厂类  Port= 5672(端口号)
            string exchangeName = "fogoExchange";
            string queueName = "maxsoft";
            string routeKey = "soft";
            using (var connection = factory.CreateConnection())
            {
                //创建一个新的通道、会话和模型
                using (var channel = connection.CreateModel())
                {
                    //定义一个Direct类型交换机
                    channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, false, false, null);

                    //定义一个队列
                    channel.QueueDeclare(queueName, false, false, false, null);

                    //将队列绑定到交换机
                    channel.QueueBind(queueName, exchangeName, routeKey, null);

                    channel.QueueDeclare(queueName, false, false, false, null);

                    //消息内容
                    byte[] body = Encoding.UTF8.GetBytes(msg);
                    channel.BasicPublish(exchangeName, routeKey, null, body);              //发送（生产）消息
                    Console.WriteLine($"Send_Messages: {msg}");
                    //   channel.Close();
                }
            }
            return false;
        }
    }
}
