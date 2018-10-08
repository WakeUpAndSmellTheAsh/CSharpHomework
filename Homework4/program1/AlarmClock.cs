using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace program1
{
    partial class Program
    { 
           //声明委托
        public delegate void RingEventHandler();
        class Ring
        {
            //声明事件
            public event RingEventHandler Clock;
           

            private DateTime ringTime;
            private Timer timer;
            public bool OK { get => !timer.Enabled; }
            public Ring(int hour, int minute, int second)
            {
                if (DateTime.TryParse($"{hour}:{minute}:{second}", out ringTime))
                {                                                       // 返回parse成功
                    if (ringTime < DateTime.Now)
                    {
                        ringTime = ringTime.AddDays(1);               // 没有提供日期 会自动parse成今天的
                    }
                    Console.WriteLine($"闹钟定在了 {ringTime}");                 
                    Clock += tryRing;
                    Clock();
                }
                else
                {
                    Console.WriteLine("日期格式不对");
                }
            }
            
            public void tryRing()
            {
                timer = new Timer(100);
                timer.Elapsed += RingOrNot;
                timer.Start();
            }
            public void RingOrNot(object sender, ElapsedEventArgs e)
            {
                if (DateTime.Now >= ringTime)
                {
                    Console.WriteLine($"现在是： {DateTime.Now} !!!!!!");
                    var timer = sender as Timer;
                    timer.Stop();
                }
            }
        }
    }
}
