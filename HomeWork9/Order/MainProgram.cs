using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;
namespace Order
{
    class MainProgram
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


            //在用MySQL创建名为：Ordersystem的数据库之后：
            string conStr = "Database=ordersystem;datasource=localhost;uid='root';pwd=123456789";
            MySqlConnection coon = new MySqlConnection(conStr);
            coon.Open();
            #region 插入
          // 正常插入一条数据
           string username = "lj";string password = "6666";
        MySqlCommand cmd = new MySqlCommand("insert into user set username ='" + username + "'" + ",password='" + password + "'", conn);
           cmd.ExecuteNonQuery();
            #endregion


            Console.WriteLine();
        }
    }
}
