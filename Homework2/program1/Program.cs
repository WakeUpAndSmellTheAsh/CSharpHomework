/*
 *    对应课本  习题2 三、6       
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
            Console.WriteLine("输入一个正整数：");
            String s;
            s = Console.ReadLine();
            int n,n2, i = 2, j = 0;
            n = Int32.Parse(s);
            n2 = n;
            Console.WriteLine(n+"的素数因子有：");
            while (n2 >= i)
            {

                if (n2 % i == 0)
                {
                    if (j == 0)
                    {
                        Console.WriteLine(i); j++;
                    }
                    n2 = n2 / i;
                }
                else
                {
                    i++;
                    j = 0;
                }
            }
            if(n!=i)
                Console.WriteLine(n);
            Thread.Sleep(3000);
        }
    }
}
