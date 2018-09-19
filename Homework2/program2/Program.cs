/*
 *    对应课本  习题2 三、7  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;                    // 另外添加的 

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入数组元素个数:");      //键盘输入数组元素个数
            string s = Console.ReadLine();
            int n = Int32.Parse(s);

            int[] A = new int[n];                      //创建数组并键盘赋值
            Console.WriteLine("输入数组元素:");
            for (int i = 0; i < n; i++)
            {
                string s1 = Console.ReadLine();
                A[i] = Int32.Parse(s1);
            }

            int Max = A[0], Min = A[0], Sum = 0;       //变量：最大值 最小值 和
            float aver = 0;                            //变量：平均值 float 型
            for (int i = 0; i < n; i++)                //求最大最小以及和
            {
                if (Max < A[i])
                    Max = A[i];
                if (Min > A[i])
                    Min = A[i];
                Sum += A[i];
            }
            aver = (float)Sum / n;                     //求平均值

            Console.WriteLine("最大的元素是：" + Max); 
            Console.WriteLine("最小的元素是：" + Min);
            Console.WriteLine("所有元素的和是：" + Sum);
            Console.WriteLine("数组元素的平均值是：" + aver);
            Thread.Sleep(10000);


        }
    }
}
