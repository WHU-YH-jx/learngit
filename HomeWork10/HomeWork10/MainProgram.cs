using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10
{
   public class MainProgram
   {
        static void Main(string[] args)
        {
            OrderService OpOrder = new OrderService();

            //每次创建新的订单的时候  不仅order的内容不能一一样 连detail也不能一样 而且同样的order不能重复加入 
            //可创建新的订单对功能进行检验 或在App.config修改连接的数据库 进行新的操作

            List<OrderDetails> detail1 = new List<OrderDetails>() { new OrderDetails("1", "C#", 1.0, 100) };
            List<OrderDetails> detail2 = new List<OrderDetails>() { new OrderDetails("2", "计组", 2.0, 100) };
            List<OrderDetails> detail3 = new List<OrderDetails>() { new OrderDetails("3", "JAVA", 100.0, 500) };
            List<OrderDetails> detail4 = new List<OrderDetails>() { new OrderDetails("4", "数据结构", 800.0, 5500) };
            List<OrderDetails> detail5 = new List<OrderDetails>() { new OrderDetails("5", "概率论", 9, 100) };
            Order order1 = new Order("01", "hjx", DateTime.Now, detail1);
            Order order2 = new Order("02", "hjx1", DateTime.Now, detail2);
            Order order3 = new Order("03", "hjx2", DateTime.Now, detail3);
            Order order4 = new Order("04", "hjx3", DateTime.Now, detail4);
            Order order5 = new Order("05", "hjx4", DateTime.Now, detail5);

            Order neworder1 = new Order("01", "ffzz", DateTime.Now, detail1);


            //OpOrder.AddOrder(order1);
            //OpOrder.AddOrder(order2);
            //OpOrder.AddOrder(order3);
            //OpOrder.AddOrder(order4);
            //OpOrder.AddOrder(order5);
            //OpOrder.ChangeOrder(neworder1);

            //OpOrder.DeleteOrder("04");
            // OpOrder.DeleteOrder("05");

        }
    }
}
