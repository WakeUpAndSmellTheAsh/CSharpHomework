using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    interface Product
    {
        void Init();
        void getArea();
    }

    class triangle : Product
    {
        string s1, s2, s3;
        int i1, i2, i3;
        double p, S;
        public void Init()
        {
            Console.WriteLine("输入三角形的三边长:");
            s1 = Console.ReadLine();
            s2 = Console.ReadLine();
            s3 = Console.ReadLine();
            i1 = Int32.Parse(s1);
            i2 = Int32.Parse(s2);
            i3 = Int32.Parse(s3);
            if ((i1 + i2 > i3) && (i3 + i2 > i1) && (i1 + i3 > i2) &&
                (Math.Abs(i1 - i2) < i3) && (Math.Abs(i2 - i3) < i1) && (Math.Abs(i3 - i2) < i1))
            {
                i1 = Int32.Parse(s1);
                i2 = Int32.Parse(s2);
                i3 = Int32.Parse(s3);
            }
            else
                Console.WriteLine("不存在这样边长的三角形!!!");
            Console.WriteLine("↓↓↓为假!!!");
        }
        public void getArea()
        {
            p = (i1 + i2 + i3) / 2;
            S = System.Math.Sqrt(p * (p - i1) * (p - i2) * (p - i3));
            Console.WriteLine("该三角形的面积为：" + S);
        }
    }

    class circle : Product
    {
        string s1;
        int i1;
        const double PI = 3.1415926535;
        public void Init()
        {
            Console.WriteLine("输入圆形半径:");
            s1 = Console.ReadLine();
        }
        public void getArea()
        {
            i1 = Int32.Parse(s1);
            Console.WriteLine("该圆面积为：" + PI * i1 * i1);
        }
    }

    class square : Product
    {
        string s1;
        int i1;
        public void Init()
        {
            Console.WriteLine("输入正方形边长:");
            s1 = Console.ReadLine();
        }
        public void getArea()
        {
            i1 = Int32.Parse(s1);
            Console.WriteLine("该正方形面积为：" + i1 * i1);
        }
    }

    class rectangle : Product
    {
        string s1, s2;
        int i1, i2;
        public void Init()
        {
            Console.WriteLine("输入长方形的边长:");
            s1 = Console.ReadLine();
            s2 = Console.ReadLine();
        }
        public void getArea()
        {
            i1 = Int32.Parse(s1);
            i2 = Int32.Parse(s2);
            Console.WriteLine("该长方形的面积为：" + i1 * i2);
        }
    }
}
