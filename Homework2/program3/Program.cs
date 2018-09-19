/*
 *    对应课本  习题2 三、9        
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;                    // 另外添加的 

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = new int[101];        //（开始i=2)如果i是合数，num[i]=1；否则为0
            int primeCount = 0;              // 记录 素数个数
            int[] prime = new int[101];      // 记录 素数 

            findPrime();
            //输出素数
            for (int i = 1; i < primeCount+1; ++i)
            {
                    Console.WriteLine(prime[i]);
            }
            void findPrime()
            { 
                for (int i = 2; i <= 100; ++i)
                {
                    bool t = true;              //t用来记录i是否是素数
                    if (0 != num[i])            // num[i]=1 时  t为假 
                        t = false;
                    if (t)
                    {
                        primeCount++;                                     //素数个数加一
                        prime[primeCount] = i;                            //素数保存到数组中
                        for (int j = 2 * i; j <= 100; j += i)             //j是i的n（n>=2）倍，记num[j]=1
                        {
                            num[j] = 1;
                        }
                    }
                }
            }
            Thread.Sleep(99999);
        }
    }
}
