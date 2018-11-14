using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace HomeWork7
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderDetails FirstOrder = new OrderDetails("2018/11/13/001", "JX1", "一点点", 1, 1.5, "125-5211-3142");         //初始化订单
            OrderDetails SecondOrder = new OrderDetails("2018/11/13/002", "JX2", "两点点", 2, 2.5, "134-5211-3142");
            OrderDetails ThirdOrder = new OrderDetails("2018/11/13/003", "JX3", "三点点", 3, 3.5, "125-5211-3142");
            OrderDetails FourthOrder = new OrderDetails("2018/11/13/004", "JX4", "四点点", 4, 4.5, "521-5211-3142");

            Regex rx = new Regex("[0-9]{3}-[0-9]{4}-[0-9]{4}");
            string u = "123-1234-1234";
            bool l = rx.IsMatch(u);
            OrderService Oporder = new OrderService();
        
            Oporder.AddOrder(FirstOrder);                     //添加订单
            Oporder.AddOrder(SecondOrder);
            Oporder.AddOrder(ThirdOrder);
            Oporder.AddOrder(FourthOrder);


            Oporder.Export("a.xml", Oporder.OrderList);

            Oporder.Import("a.xml");

            //Oporder.DeleteOrder(06);                         //删除指定订单
            //Oporder.ChangeOrder("JX1", 5);                   //修改商品数量

            //Oporder.LookForOrder("一点点");                  //查找指定订单

            //for (int i = 0; i < Oporder.OrderList.Count; i++)
            //{
            //    Console.Write(" 商品名称是： " + Oporder.OrderList[i].GoodsName + " 商品数量是： " + Oporder.OrderList[i].GoodsNumber + " 商品价格是： " + Oporder.OrderList[i].GoodsPrice);
            //    Console.WriteLine();
            //}

            Console.WriteLine();
        }
    }
   
}
