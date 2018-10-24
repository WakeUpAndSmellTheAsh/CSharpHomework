using Microsoft.VisualStudio.TestTools.UnitTesting;
using program1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddOrderTest()
        {
            Customer customer1 = new Customer(1, "王五");
            Customer customer2 = new Customer(2, "马六");
            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);
            Goods apple = new Goods(3, "apple", 5.59);
            OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);

        }



        [TestMethod()]
        public void QueryAllOrdersTest()
        {
            Customer customer1 = new Customer(1, "张三");
            Customer customer2 = new Customer(2, "李四");

            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);


            OrderDetail orderDetails1 = new OrderDetail(1, milk, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);


            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            order1.AddDetails(orderDetails1);
            order2.AddDetails(orderDetails2);

            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.QueryAllOrders();

        }
        [TestMethod()]
        public void QueryByGoodsNameTest()
        {
            Customer customer1 = new Customer(1, "张三");
            Customer customer2 = new Customer(2, "李四");

            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);


            OrderDetail orderDetails1 = new OrderDetail(1, milk, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);


            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            order1.AddDetails(orderDetails1);
            order2.AddDetails(orderDetails2);

            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.QueryByGoodsName("milk");

        }
        [TestMethod()]
        public void QueryByCustomerNameTest()
        {
            Customer customer1 = new Customer(1, "张三");
            Customer customer2 = new Customer(2, "李四");

            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);


            OrderDetail orderDetails1 = new OrderDetail(1, milk, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);


            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            order1.AddDetails(orderDetails1);
            order2.AddDetails(orderDetails2);

            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.QueryByCustomerName("张三");
        }

        [TestMethod()]
        public void QueryByOrderIDTest()
        {
            Customer customer1 = new Customer(1, "张三");
            Customer customer2 = new Customer(2, "李四");

            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);


            OrderDetail orderDetails1 = new OrderDetail(1, milk, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);


            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            order1.AddDetails(orderDetails1);
            order2.AddDetails(orderDetails2);

            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.QueryByOrderID("1");
        }

        [TestMethod()]
        public void QueryByAmountTest()
        {
            Customer customer1 = new Customer(1, "张三");
            Customer customer2 = new Customer(2, "李四");
            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);
            OrderDetail orderDetails1 = new OrderDetail(1, milk, 1000);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            order1.AddDetails(orderDetails1);
            order2.AddDetails(orderDetails2);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            List<Order> orders = os.QueryAllOrders();
            orders = os.QueryByAmount(10000);
            foreach (var order in orders)
            {

                Assert.IsTrue(order.Amount > 10000);

            }
        }

        [TestMethod()]
        public void ExportTest()
        {
            Customer customer1 = new Customer(1, "张三");
            Customer customer2 = new Customer(2, "李四");
            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);
            OrderDetail orderDetails1 = new OrderDetail(1, milk, 1000);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            order1.AddDetails(orderDetails1);
            order2.AddDetails(orderDetails2);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.Export(@"D:\orders.xml");
            System.IO.FileInfo file = new System.IO.FileInfo(@"D:\orders.xml");
            Assert.IsTrue(file.Exists);
        }

        [TestMethod()]
        public void ImportTest()
        {
            OrderService os = OrderService.Import(@"D:\orders.xml");
            List<Order> orders = os.QueryAllOrders();
            foreach (var order in orders)
            {

                Assert.IsTrue(order.OrderId==1|| order.OrderId == 2);

            }
        }
    }
}