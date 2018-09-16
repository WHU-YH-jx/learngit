using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] test2 = { 1, 2, 3, 4, 5 };    //初始化数组
            int Max=test2[0], Min=test2[0], Average = 0, Sum = 0;
            for(int i = 0;i<test2.Length;i++)
            {
                if (Max <= test2[i]) Max = test2[i];
                if (Min >= test2[i]) Min = test2[i];
                Sum += test2[i];
            }
            Average = Sum / test2.Length;
            Console.Write("最大值为：" + Max + " 最小值为：" + Min + " 平均值为：" + Average + "数组和为： " + Sum);
        }
    }
}
