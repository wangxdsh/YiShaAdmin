using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiSha.Util.Model
{
    /// <summary>
    /// 数据传输对象
    /// </summary>
    public class TData
    {
        /// <summary>
        /// 操作结果，Tag为1代表成功，0代表失败， 2.资源加载中 3.登录失效 4.次数用完  5.资源无效
        /// </summary>
        public int Tag { get; set; }

        /// <summary>
        /// 提示信息或异常信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 扩展Message
        /// </summary>
        public string Description { get; set; }
    }

    public class TData<T> : TData
    {
        /// <summary>
        /// 列表的记录数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }

        public void initDto( int tag,string message, string description, int total)
        {
            //data.GetType().GetProperty("").va;
            this.Tag = tag;
            this.Message = message;
            this.Description = description;
            this.Total = total;
        }
    }
}
