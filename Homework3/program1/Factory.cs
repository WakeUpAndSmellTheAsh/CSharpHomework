using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Factory
    {
        public static Product GetShape(string shape)

        {
            Product iproduct = null;
            if (shape.Equals("triangle"))
            {
                iproduct = new triangle();
            }
            else if (shape.Equals("circle"))
            {
                iproduct = new circle();
            }
            else if (shape.Equals("square"))
            {
                iproduct = new square();
            }
            else if (shape.Equals("rectangle"))
            {
                iproduct = new rectangle();
            }
            else
            {
                Console.WriteLine("不支持此图形！！");
            }

            return iproduct;
        }
    }
}
