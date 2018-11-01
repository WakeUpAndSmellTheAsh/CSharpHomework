using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using program1;

namespace WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         
            
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
            order3.AddDetails(orderDetails3);

            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);

          

            orderBindingSource.Add(order1);
            orderBindingSource.Add(order2);
            orderBindingSource.Add(order3);






        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            //显示所有订单


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
