using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3
{
    class Program
    {
        static int[] suArray =new int[100]; //建立存储素数的数组
        
        static void Delete(int a,int b,ref int i )
        {
            if( a < 101 && b <= a)
            {
                if (a % b == 0 && b != a )
                {
                    a++;
                    b = 2;
                    Delete(a, b, ref i);
                }
                else if (a % b == 0 && b == a )
                {
                    suArray[i] = a;
                    i++;
                    a++;
                    b = 2;
                    Delete(a, b, ref i);
                }
                else if (a % b != 0 )
                {
                    b++;
                    Delete(a, b, ref i);
                }
            }
        }
        static void Main(string[] args)
        {
            int i = 0;

            Delete(2,2,ref i);

            for (int a = 0; a < i; a++)            //将存储的素数输出
                Console.WriteLine(suArray[a]);

            Console.WriteLine(" ");
        }
    }
}
