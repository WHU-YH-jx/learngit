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
    [Serializable]
    public class OrderService
    {
        public List<OrderDetails> OrderList = new List<OrderDetails>();

        public List<OrderDetails> orderList { get => this.OrderList; }
        //创建储存订单的列表

        public OrderService() { }
        public void AddOrder(OrderDetails first)                        //增加订单
        {
            if (first != null)
                OrderList.Add(first);
        }

        public void DeleteOrderI(string input)                              //根据订单号删除订单
        {
            int count = 0;
            if (input != null)
            {
                for (int i = 0; i < OrderList.Count; i++)
                {
                    if (input == OrderList[i].OrderNumber)
                    {
                        OrderList.Remove(OrderList[i]);
                        count++;
                    }
                }
            }
            if (count == 0)
            { Console.WriteLine("未查到该订单！！删除错误！！！"); Console.WriteLine(); }
        }
        public void DeleteOrderN(string inname)                          //根据商品名称或者顾客名删除订单
        {
            int count = 0;
            for (int i = 0; i < OrderList.Count; i++)
            {
                if (inname == OrderList[i].CustomerName || inname == OrderList[i].GoodsName)
                {
                    OrderList.Remove(OrderList[i]);
                    count++;
                }
            }
            if (count == 0)
            { Console.WriteLine("未查到该订单！！删除错误！！！"); Console.WriteLine(); }
        }

        public void ChangeOrder(string input, int newNumber, string newName)               //根据订单号修改订单的商品数量
        {
            int count = 0;
            for (int i = 0; i < OrderList.Count; i++)
            {
                if (input == OrderList[i].OrderNumber)
                {
                    OrderList[i].GoodsNumber = newNumber;
                    OrderList[i].GoodsName = newName;
                    count++;
                }
            }
            if (count == 0)
            { Console.WriteLine("未查找到该商品！！修改错误！！！"); Console.WriteLine(); }
        }
        public void ChangeOrder(string input, int newNumber)            //根据客户名或者商品名修改订单的商品数量
        {
            int count = 0;
            for (int i = 0; i < OrderList.Count; i++)
            {
                if (input == OrderList[i].CustomerName || input == OrderList[i].GoodsName)
                {
                    OrderList[i].GoodsNumber = newNumber;
                    count++;
                }
            }
            if (count == 0)
            { Console.WriteLine("未查找到该商品！！修改错误！！！"); Console.WriteLine(); }
        }

        //    Homework5      用Linq实现订单查询功能   
        public void LookForOrderByLinq(string input)                                   //根据订单号进行查询(Linq语句)
        {
            var selorder = from n in OrderList where n.OrderNumber == input select n;
            foreach (var n in selorder)
            {
                Console.Write(" 商品名称是： " + n.GoodsName + " 商品数量是： " + n.GoodsNumber + " 商品价格是： " + n.GoodsPrice);
            }

        }
        public void LookForOrderByLinqS(string inname)                               //根据客户名或者商品名查找订单（Linq语句）
        {
            var selorder = from n in OrderList where n.CustomerName == inname || n.GoodsName == inname select n;
            foreach (var n in selorder)
            {
                Console.Write(" 商品名称是： " + n.GoodsName + " 商品数量是： " + n.GoodsNumber + " 商品价格是： " + n.GoodsPrice);
            }

        }
        public void LookOrByLinq()
        {
            var selorder = from n in OrderList where n.GoodsNumber * n.GoodsPrice > 10000 select n;          //订单价格大于一万（Linq语句）
            foreach (var n in selorder)
            {
                Console.Write(" 商品名称是： " + n.GoodsName + " 商品数量是： " + n.GoodsNumber + " 商品价格是： " + n.GoodsPrice);
            }
        }

        //HomeWork5 用Linq实现相关功能*/
        public void LookForOrder(string inname)                         //根据客户名或者商品名查找订单
        {
            int count = 0;
            for (int i = 0; i < OrderList.Count; i++)
            {
                if (inname == OrderList[i].CustomerName || inname == OrderList[i].GoodsName)
                {
                    Console.Write(" 商品名称是： " + OrderList[i].GoodsName + " 商品数量是： " + OrderList[i].GoodsNumber + " 商品价格是： " + OrderList[i].GoodsPrice);
                    Console.WriteLine();
                    count++;
                }
            }
            if (count == 0)
            { Console.WriteLine("未找到该订单！！"); Console.WriteLine(); }

        }
        public OrderDetails LookForOrderI(string input)                             //根据订单号进行查询
        {

            int a = 0;
            if (input == null) return null;
            for (int i = 0; i < OrderList.Count; i++)
            {
                if (input == OrderList[i].OrderNumber)
                {
                    a = i;
                }

            }
            return OrderList[a];

        }
        public OrderDetails LookForOrderS(string name)                             //根据订单号进行查询
        {
            int a = 0;
            for (int i = 0; i < OrderList.Count; i++)
            {
                if (name == OrderList[i].CustomerName)
                {
                    a = i;
                }

            }
            return OrderList[a];
        }

        //XML序列化
        public void Export(string filename, object obj)
        {
            XmlSerializer xmler = new XmlSerializer(typeof(List<OrderDetails>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                xmler.Serialize(fs, obj);
                fs.Close();
            }
        }
        //XML反序列化
        public void Import(string filename)
        {
            XmlSerializer xmler = new XmlSerializer(typeof(List<OrderDetails>));
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                List<OrderDetails> ol = (List<OrderDetails>)xmler.Deserialize(fs);
                ol.ForEach(o => Console.WriteLine(o.ToString()));
            }
        }
        public override string ToString()
        {
            string result = " ";
            for (int i = 0; i < orderList.Count; i++)
            {
                result += "订单号： " + orderList[i].OrderNumber + " 客户名： " + orderList[i].CustomerName + " 商品名： " + orderList[i].GoodsName + " 商品数量： " + orderList[i].GoodsNumber + " 商品价格： " + orderList[i].GoodsPrice + "\n";
            }
            return result;
        }

    }
}