using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    
        public class Order                          //创建订单类
        {
            public int OrderNumber;                 //订单号
            public string CustomerName;             //顾客名 
        }

    public class OrderDetails : Order              //创建订单详情类
    {
        public string GoodsName { get; }           //商品名称
        public int GoodsNumber { set; get; }       //商品数量
        public double GoodsPrice { get; }          //商品价格
        public OrderDetails(int OrderNumber,string CustomerName, string GoodsName, int GoodsNumber,double GoodsPrice)  //重载构造函数 对订单进行初始化
        {
            this.OrderNumber = OrderNumber;
            this.CustomerName = CustomerName;
            this.GoodsName = GoodsName;
            this.GoodsNumber = GoodsNumber;
            this.GoodsPrice = GoodsPrice;
        }
        
    }

     public class OrderService
     { 
        List<OrderDetails> OrderList = new List<OrderDetails>();        //创建储存订单的列表

        public void AddOrder(OrderDetails first)                        //增加订单
        {
            OrderList.Add(first);
        }

        public void DeleteOrder(int input)                              //根据订单号删除订单
        {
            int count = 0;
            for (int i = 0; i < OrderList.Count; i++)
            {
                if (input == OrderList[i].OrderNumber)
                {
                    OrderList.Remove(OrderList[i]);
                    count++;
                }
            }
            if (count == 0)
            { Console.WriteLine("未查到该订单！！删除错误！！！"); Console.WriteLine(); }
        }
        public void DeleteOrder(string inname)                          //根据商品名称或者顾客名删除订单
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

        public void ChangeOrder(int input, int newNumber)               //根据订单号修改订单的商品数量
        {
            int count = 0;
            for (int i = 0; i < OrderList.Count; i++)
            {
                if (input == OrderList[i].OrderNumber)
                {
                    OrderList[i].GoodsNumber = newNumber;
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

        public void LookForOrder(int input)                             //根据订单号进行查询
        {
            int count = 0;
            for (int i = 0; i < OrderList.Count; i++)
            {
                if (input == OrderList[i].OrderNumber)
                {
                    Console.Write(" 商品名称是： " + OrderList[i].GoodsName + " 商品数量是： " + OrderList[i].GoodsNumber + " 商品价格是： " + OrderList[i].GoodsPrice );
                    Console.WriteLine();
                    count++;
                }
            }
            if(count==0)
            { Console.WriteLine("未找到该订单！！"); Console.WriteLine(); }
    }

        public void LookForOrder(string inname)                         //根据客户名或者商品名查找订单
        {
            int count = 0;
            for (int i = 0; i < OrderList.Count; i++)
            {
                if (inname == OrderList[i].CustomerName || inname == OrderList[i].GoodsName)
                {
                    Console.Write(" 商品名称是： " + OrderList[i].GoodsName + " 商品数量是： " + OrderList[i].GoodsNumber + " 商品价格是： " + OrderList[i].GoodsPrice );
                    Console.WriteLine();
                    count++;
                }
            }
            if (count == 0)
            { Console.WriteLine("未找到该订单！！"); Console.WriteLine(); }

        }
        static void Main()
        {
            OrderDetails FirstOrder = new OrderDetails(01, "JX1", "一点点",1,1.5);         //初始化订单
            OrderDetails SecondOrder = new OrderDetails(02, "JX2", "两点点", 2, 2.5);
            OrderDetails ThirdOrder = new OrderDetails(03, "JX3", "三点点", 3, 3.5);
            OrderDetails FourthOrder = new OrderDetails(04, "JX4", "四点点", 4, 4.5);

            
            OrderService Oporder = new OrderService();                                    

            Oporder.AddOrder(FirstOrder);                     //添加订单
            Oporder.AddOrder(SecondOrder);
            Oporder.AddOrder(ThirdOrder);
            Oporder.AddOrder(FourthOrder);

            Oporder.DeleteOrder(06);                         //删除指定订单


            Oporder.ChangeOrder("JX1", 5);                   //修改商品数量

            Oporder.LookForOrder("一点点");                  //查找指定订单

            for (int i = 0; i < Oporder.OrderList.Count; i++)
            {
                Console.Write(" 商品名称是： " + Oporder.OrderList[i].GoodsName + " 商品数量是： " + Oporder.OrderList[i].GoodsNumber + " 商品价格是： " + Oporder.OrderList[i].GoodsPrice);
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
   
    
}
