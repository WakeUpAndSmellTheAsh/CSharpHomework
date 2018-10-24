using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *    上次作业结构太过混乱  差不多所有方法都放在 OrderService里了 也没有Goods\Customer类
 *    上次作业已经在删除查找中用了一些linq语句 Romove、foreach等
 *    本次作业直接在示例代码上做了一些更改........求原谅.......
 *    1 可根据客户名称\商品名称\订单号查询订单
 *    2 可传入数字，查询账单金额大于这个数的订单
 */
namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Customer customer1 = new Customer(1, "Customer1");
                Customer customer2 = new Customer(2, "Customer2");

                Goods milk = new Goods(1, "Milk", 69.9);
                Goods eggs = new Goods(2, "eggs", 4.99);
                Goods apple = new Goods(3, "apple", 5.59);

                OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
                OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
                OrderDetail orderDetails3 = new OrderDetail(3, milk, 1000);
              
                Order order1 = new Order(1, customer1);
                Order order2 = new Order(2, customer2);
                Order order3 = new Order(3, customer2);
                order1.AddDetails(orderDetails1);
                order1.AddDetails(orderDetails2);
      
                order2.AddDetails(orderDetails2);
                order2.AddDetails(orderDetails3);
                order3.AddDetails(orderDetails1);

                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.AddOrder(order2);
                os.AddOrder(order3);

                Console.WriteLine("GetAllOrders");
                List<Order> orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("GetOrdersByCustomerName:'Customer2'");
                orders = os.QueryByCustomerName("Customer2");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("GetOrdersByGoodsName:'apple'");
                orders = os.QueryByGoodsName("apple");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("GetOrdersByOrderID:' order2'");
                orders = os.QueryByOrderID("2");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("GetOrdersByAmount:'over 10000'");
                orders = os.QueryByAmount(10000);
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
