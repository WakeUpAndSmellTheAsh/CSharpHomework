using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    partial class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("输入时");
            int iHour = Int32.Parse(Console.ReadLine());
            Console.WriteLine("输入分");
            int iMinute = Int32.Parse(Console.ReadLine());
            Console.WriteLine("输入秒");
            int iSecond = Int32.Parse(Console.ReadLine());
            Ring r1=new Ring(iHour, iMinute, iSecond);
            Console.WriteLine("哼唧");

        }
    }
}
