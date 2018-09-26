/*
 *   使用简单工厂模式 建立 圆形正方形长方形三角形 并 求面积
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("选择图形类型输入：circle square rectangle triangle");
            string s = Console.ReadLine();
            Product p1 = Factory.GetShape(s);
            p1.Init();
            p1.getArea();
            Console.WriteLine("byebye~end");
        }
    }
}
