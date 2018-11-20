using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using System.Runtime.Serialization;

using System.Xml.Serialization;
using System.Xml.Xsl;

/*
 * 验证数据并利用xslt写html
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

                Order order1 = new Order("001", "张三","13471087643");
                Order order2 = new Order("002", "李四", "13471087644");
                Order order3 = new Order("003", "王五", "13471087645");

                order1.AddDetails(orderDetails1);
                order1.AddDetails(orderDetails2);

                order2.AddDetails(orderDetails2);
                order3.AddDetails(orderDetails1);
                order3.AddDetails(orderDetails3);
                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.AddOrder(order2);
                os.AddOrder(order3);
                //显示所有订单
                Console.WriteLine("GetAllOrders");
                List<Order> orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine(os.legal());

                //通过客户名字查询
                Console.WriteLine("GetOrdersByCustomerName:'李四'");
                orders = os.QueryByCustomerName("李四");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                ////通过商品名称查询
                //Console.WriteLine("GetOrdersByGoodsName:'apple'");
                //orders = os.QueryByGoodsName("apple");
                //foreach (Order od in orders)
                //    Console.WriteLine(od.ToString());
                ////通过订单名查询
                //Console.WriteLine("GetOrdersByOrderID:' order2'");
                //orders = os.QueryByOrderID("2");
                //foreach (Order od in orders)
                //    Console.WriteLine(od.ToString());
                ////查询订单进而超过某一个值的订单
                //Console.WriteLine("GetOrdersByAmount:'over 10000'");
                //List<Order> orders2 = os.QueryByAmount(10000);
                //foreach (Order od in orders2)
                //    Console.WriteLine(od.ToString());


                Console.WriteLine("___________序列化___和____反序列化__________");
                Console.WriteLine("_____________");
                os.Export("../../orderService.xml");
          
                List<Order> ods = OrderService.Import(@"../../orderService.xml").QueryAllOrders();
                foreach (Order od in ods)
                    Console.WriteLine(od.ToString());

                XslCompiledTransform trans = new XslCompiledTransform();
                trans.Load(@"../../orderService.xslt");
                trans.Transform(@"../../orderService.xml", @"../../orderService.html");

              

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
