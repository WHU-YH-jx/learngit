using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yh_firstC
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "";
            string s2 = "";
            string s3 = "";
            string s4= "";
            double n = 0;
            double m = 0;
            double exam = 0;
            Console.WriteLine("请输入想要计算的数字：");
            s1 = Console.ReadLine();
            s2 = Console.ReadLine();
            if (double.TryParse(s1, out exam) == false || double.TryParse(s2, out exam) == false)  //判断输入的是否为数字
            {
                Console.WriteLine("识别错误，请输入数字: ");
                s3 = Console.ReadLine();
                s4 = Console.ReadLine();
                m = double.Parse(s3);
                n = double.Parse(s4);
                Console.Write("乘积为:" + (m * n));
            }
            else
            {
                m = double.Parse(s1);
                n = double.Parse(s2);
                Console.Write("乘积为:" + (m * n));
            }
            
        }
    }
}
