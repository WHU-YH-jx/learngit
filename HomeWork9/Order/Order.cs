using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;
namespace Order
{
    public class Order                          //创建订单类
    {
        public string OrderNumber { set; get; }                 //订单号
        public string CustomerName { set; get; }        //顾客名 

    }
}
