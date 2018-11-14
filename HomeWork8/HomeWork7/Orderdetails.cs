using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;
namespace HomeWork7
{
    public class OrderDetails : Order              //创建订单详情类
    {
        public string GoodsName { set; get; }           //商品名称
        public int GoodsNumber { set; get; }       //商品数量
        public double GoodsPrice { set; get; }          //商品价格
        public string CustomerPNumber { set; get; }
        public OrderDetails(string OrderNumber, string CustomerName, string GoodsName, int GoodsNumber, double GoodsPrice,string CustomerPNumber)  //重载构造函数 对订单进行初始化
        {
            this.OrderNumber = OrderNumber;
            this.CustomerName = CustomerName;
            this.GoodsName = GoodsName;
            this.GoodsNumber = GoodsNumber;
            this.GoodsPrice = GoodsPrice;
            this.CustomerPNumber = CustomerPNumber;
        }
        public override string ToString() { return $"客户名：{CustomerName}客户手机号：{CustomerPNumber}商品名：{GoodsName}商品数量：{GoodsNumber}订单号：{OrderNumber};"; }
        public OrderDetails() { }

    }
}