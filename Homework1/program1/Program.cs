/*
 *    对应课本  习题1 三、4
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;                    // 另外添加的 

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "";
            string s2 = "";
            int n1 = 0;
            int n2 = 0;
            Console.Write("输入第一个数：");
            s1 = Console.ReadLine();
            n1 = Int32.Parse(s1);
            Console.Write("输入第二个数：");
            s2 = Console.ReadLine();
            n2 = Int32.Parse(s2);
            Console.Write(n1 + "和" + n2 + "的积为：" + (n1 * n2));
            Thread.Sleep(3000);            //为了看到 “积”的效果
        }
    }
}
