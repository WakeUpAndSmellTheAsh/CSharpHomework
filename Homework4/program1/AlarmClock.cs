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
        class AlarmClock
        {
            public int Hour;
            public int Minute;
            public int Second;
            public AlarmClock(int hour, int minute, int second)
            {
                try
                {
                    if (hour < 0 || hour > 23)
                        throw new TimeException("Hours out of range");
                    else
                        Hour = hour;
                    if (minute < 0 || Minute > 59)
                        throw new TimeException("Minute out of range");
                    else
                        Minute = minute;
                    if (second < 0 || Second > 59)
                        throw new TimeException("Second out of range");
                    else
                        Second = second;

                }
                catch (TimeException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                Console.WriteLine("设置的闹钟为:"+Hour+":"+Minute+":"+Second);
                //if(Event1!=null)
                //Event1();
        }
            public delegate void EventHandler();
            public event EventHandler Event1;

        }

        class Ring
        {
            public int Hour;
            public int Minute;
            public int Second;
            public Ring(int hour, int minute, int second)
            {
                AlarmClock alarm1 = new AlarmClock(hour, minute, second);
                Hour = hour;
                Minute = minute;
                Second = second;
               
                Timer timer = new Timer
                {
                    Enabled = true,
                    Interval = 10
                };
                timer.Start();
                timer.Elapsed += RingOrNot;

                //  alarm1.Event1 += RingOrNot;


                //while(true)
                //{
                //Timer timer = new Timer
                //{
                //    Enabled = true,
                //    Interval = 10
                //};
                //timer.Start();
                //timer.Elapsed += RingOrNot;

                //}
            }
         
               
        
          
            public void RingOrNot(object sourse,ElapsedEventArgs e)
            {
                if (DateTime.Now.Hour == Hour && DateTime.Now.Minute == Minute && DateTime.Now.Second==Second)
                {
                    Console.WriteLine("现在是：" + DateTime.Now+"!!!!!!");
                }
            }
        }
    }
}
