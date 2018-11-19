using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using System.Runtime.Serialization;

using System.Xml.Serialization;

/*
 序列化和反序列化 （还存在一点问题
 */
namespace program1
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
             

                Goods milk = new Goods(1, "Milk", 69.9);
                Goods eggs = new Goods(2, "eggs", 4.99);
                Goods apple = new Goods(3, "apple", 5.59);

                OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
                OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
                OrderDetail orderDetails3 = new OrderDetail(3, milk, 1000);


                Order order1 = new Order(1, "张三");
                Order order2 = new Order(2, "李四");
                Order order3 = new Order(3, "王五");

                order1.AddDetails(orderDetails1);
                order1.AddDetails(orderDetails2);

                order2.AddDetails(orderDetails2);
                order2.AddDetails(orderDetails3);
                order3.AddDetails(orderDetails1);

                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.AddOrder(order2);
                os.AddOrder(order3);
                //显示所有订单
                Console.WriteLine("GetAllOrders");
                List<Order> orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                //通过客户名字查询
                Console.WriteLine("GetOrdersByCustomerName:'李四'");
                orders = os.QueryByCustomerName("李四");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                //通过商品名称查询
                Console.WriteLine("GetOrdersByGoodsName:'apple'");
                orders = os.QueryByGoodsName("apple");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                //通过订单名查询
                Console.WriteLine("GetOrdersByOrderID:' order2'");
                orders = os.QueryByOrderID("2");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                //查询订单进而超过某一个值的订单
                Console.WriteLine("GetOrdersByAmount:'over 10000'");
                orders = os.QueryByAmount(10000);
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("___________序列化___和____反序列化__________");
              
                os.Export(@"D:\orderService.xml");
                List<Order> ods = OrderService.Import(@"D:\orderService.xml").QueryAllOrders();
                foreach (Order od in ods)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("END");

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
