using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    public class ClockEventArgs:EventArgs                                       //声明参数类型
    {
        public string SetTime
        {
            set;get;
        }
    }

    public delegate void ClockEventHandler(object sender, ClockEventArgs time); //声明委托类型

    public class Clock                                                          //定义事件源
    {
        public event ClockEventHandler Warning;                                 //声明事件（实际上Warning成为Clock类的一个属性）
        public void CheckTime()
        {
            ClockEventArgs setClock = new ClockEventArgs();                     //初始化参数
            setClock.SetTime = Console.ReadLine();                              //读取想要设置的闹钟时间
            while (true)
            {
                string localTime = DateTime.Now.ToShortTimeString().ToString();

                if (localTime == setClock.SetTime)                              //如果对时间进行判断
                {
                    Warning(this, setClock);
                    break;
                }
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("请输入想要设置的闹钟时间： ");
            var clock = new Clock();
            clock.Warning += ClockWarning;
            clock.CheckTime();
            
        }
        static void ClockWarning(object sender,ClockEventArgs time)
        {
            Console.WriteLine("时间已到！！！");
        }
    }
    
}
