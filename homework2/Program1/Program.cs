using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{

    class Program
    {

        static void YhDivide(ref int a, int b)           //通过递归调用
        {
            if (b <= a)
            {
                if (a % b == 0)
                {
                    System.Console.Write(b);
                    a = a / b;
                    if (a != 1)
                        Console.Write(" * ");
                    YhDivide(ref a, b);
                }
                else
                {
                    b++;
                    YhDivide(ref a, b);
                }
            }

        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Please input the number: ");
            int test;                                       //存储用户输入的数据
            string s1;
            s1 = System.Console.ReadLine();
            if (int.TryParse(s1, out test) == false)        //判断是否可以转换成整数
            {
                System.Console.WriteLine("Error!");
            }

            test = int.Parse(s1);
            if (test < 2)                                      //判断该数是否可以被分解
            {
                System.Console.WriteLine("The number is less than 2!");
            }
            int b = 2;
            System.Console.WriteLine("可分解为： ");
            YhDivide(ref test, b);
            if (test != 1)
            {
                Console.Write(test);
            }

            System.Console.Write(" ");
        }
    }
}