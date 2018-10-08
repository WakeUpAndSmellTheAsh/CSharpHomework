using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService order1 = new OrderService();
            order1.add("001", "电池", "明月");
            order1.add("002", "奶茶", "明月");
            order1.add("003", "电池", "星宇");
            order1.add("004", "奶茶", "星宇");
            order1.add("005", "电池", "太阳");
            order1.add("006", "奶茶", "太阳");

            //会显示删除失败
            order1.delete("纸巾");
            //会显示删除成功
            order1.delete("002");
            //会显示 004 006 订单的所有内容
            order1.showSelet("奶茶");
            //会显示修改成功
            order1.change("电池","不变","奶茶","不变");
            //会显示修改失败
            order1.change("冰淇淋", "不变", "奶茶", "不变");
            //会显示所有订单内容
            order1.showAll();

            Console.ReadKey();

        }
    }
}
