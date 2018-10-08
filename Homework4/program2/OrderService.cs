using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class OrderService
    {
        List<Order> ordersList = new List<Order>();
        //添加订单
        public void add(string Number,string good,string guest)
        {
            ordersList.Add(new Order(Number, good, guest));
        }
        //修改订单
        public void change(string s, string Number, string good, string guest)
        {
            if (showSelet(s))
            {
                for (int i = ordersList.Count - 1; i >= 0; i--)
                {
                    if (ordersList[i].orderNumber == s || ordersList[i].guestName == s || ordersList[i].goodName == s)
                    {
                        if (Number != "不变")
                            ordersList[i].orderNumber = Number;
                        if (guest != "不变")
                            ordersList[i].guestName = guest;
                        if (good != "不变")
                            ordersList[i].goodName = good;
                        Console.WriteLine("修改成功：");
                        Console.Write("订单号：" + ordersList[i].orderNumber + "\t客户：" + ordersList[i].guestName + "\t商品：" + ordersList[i].goodName + "\n");
                       
                    }
                }
            }
            else
                          Console.WriteLine("修改失败！");
        }
        //删除订单
        public void delete(string s)
        {
            if (showSelet(s))
            {
                Console.WriteLine("将删除和" + s + "有关的订单");
                for (int i = ordersList.Count - 1; i >= 0; i--)
                {
                    if (ordersList[i].orderNumber == s || ordersList[i].guestName == s || ordersList[i].goodName == s)
                    {
                        Console.Write("订单号：" + ordersList[i].orderNumber + "\t客户：" + ordersList[i].guestName + "\t商品：" + ordersList[i].goodName + "\n");
                        ordersList.Remove(ordersList[i]);
                        Console.WriteLine("成功删除该条订单！");
                    }
                }
            }
            else
                Console.WriteLine("删除失败！");
        }
        public void showAll()
        {
            Console.WriteLine("全部订单：");
            foreach (var AOrder in ordersList)
                Console.Write("订单号：" + AOrder.orderNumber + "\t客户：" + AOrder.guestName + "\t商品：" + AOrder.goodName + "\n");
        }
        public bool showSelet(string s)
        {
            bool j = false;
            Console.WriteLine("将显示与" + s + "有关的订单：");
            foreach (var AOrder in ordersList)
                if (AOrder.orderNumber == s || AOrder.guestName == s || AOrder.goodName == s)
                {
                    Console.Write("订单号：" + AOrder.orderNumber + "\t客户：" + AOrder.guestName + "\t商品：" + AOrder.goodName + "\n");
                    j=true;
                }
            if (!j)
                Console.WriteLine("没有相关订单！");
            return j;
        }


    }
}
