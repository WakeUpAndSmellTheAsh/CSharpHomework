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
        OrderService os = new OrderService();
        // DialogResult dialogResult = new DialogResult();
        List<Goods> Goods = new List<Goods>();
        List<OrderDetail> OrderDetails = new List<OrderDetail>();
        List<Order> orders = null;
        Form2 Form2 = new Form2();
        






        public Form1()
        {
            
            InitializeComponent();

            
            Goods good1 = new Goods(1, "Milk", 69.9);
            Goods good2 = new Goods(2, "eggs", 4.99);
            Goods good3 = new Goods(3, "apple", 5.59);
            Goods.Add(good1);
            Goods.Add(good2);
            Goods.Add(good3);

            OrderDetail orderDetails1 = new OrderDetail(1, good1, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, good2, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, good3, 1000);
            OrderDetails.Add(orderDetails1);
            OrderDetails.Add(orderDetails2);
            OrderDetails.Add(orderDetails3);

            Order order1 = new Order("1", "张三");
            Order order2 = new Order("2", "李四");
            Order order3 = new Order("3", "王五");

            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails2);
            order3.AddDetails(orderDetails3);
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);
       
            orderBindingSource.DataSource = os.orderDict;
            Form2.setGoodValue += new setGood(Form2_setGoodValue);
            Form2.setDetailValue += new setDetail(Form2_setDetailValue);
            Form2.setOrderValue += new setOrder(Form2_setOrderValue);

        }


        private void button1_Click(object sender, EventArgs e)
        {
           // orderBindingSource.Clear();

            OrderService os2 = new OrderService();
            switch (comboBox1.SelectedItem.ToString())
            {
                case "全部":
                    orders = os.QueryAllOrders(); break;
                case "按订单序号":
                    orders = os.QueryByOrderID(textBox1.Text); break;
                case "按客户名":
                    orders = os.QueryByCustomerName(textBox1.Text); break;
                case "按订单金额(大于等于)":
                    orders = os.QueryByAmount(Convert.ToDouble(textBox1.Text)); break;
            }
            foreach (Order od in orders)
                os2.AddOrder(od);
            orderBindingSource.DataSource = os2.orderDict;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            orderBindingSource.DataSource = os.orderDict;  //主窗口显示所有订单
            Form2.ShowDialog();
            

        }
        void Form2_setGoodValue(string Name, double price)
        {
            bool exit = false;
            int i = 0;
            foreach (Goods g in Goods)
            {
                i++;
                if (g.GoodName == Name && g.Price == price)
                {
                    Form2.label4.Text = "已存在" + i; exit = true; break;
                }
            }
            if (exit != true)
            {
                Goods good = new Goods();
                good.GoodId = i + 1;
                good.GoodName = Name;
                good.Price = price;
                Goods.Add(good);
                Form2.label4.Text = good.GoodId.ToString();
            }
        }
        void Form2_setDetailValue(int GoodId, int Quantity)
        {
            foreach (Goods g in Goods)
                if (g.GoodId == GoodId)
                {
                    OrderDetail orderDetail = new OrderDetail(g, Quantity);
                    int j = 0;
                    foreach (OrderDetail od in OrderDetails)
                        j++;
                    orderDetail.Id = j + 1;
                    OrderDetails.Add(orderDetail);
                    Form2.label5.Text = orderDetail.Id.ToString();
                }
          
        }
        void Form2_setOrderValue(int DetailId, string Name)
        {
            List<Order> orders =os.QueryAllOrders();
           int i = 0;
            Order orderNew = new Order();
            foreach (Order od in orders)
            {
                i++;
            }
            orderNew.OrderId = (i + 1).ToString();
            orderNew.OrderCustomer = Name;
            foreach (OrderDetail orderDetail in OrderDetails)
                if (orderDetail.Id == DetailId)
                    orderNew.AddDetails(orderDetail);
            os.AddOrder(orderNew);
             Form2.label6.Text = (i+1).ToString();
          
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

   
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "全部":
                    textBox1.Text = "点击 查询 按钮";break;
                case "按订单序号":
                    textBox1.Text = "如 1"; break;
                case "按客户名":
                    textBox1.Text = "如 张三"; break;
                case "按订单金额(大于等于)":
                    textBox1.Text = "如 1000"; break;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            foreach (var order in os.orderDict)
            {
                if (order.OrderId== dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                {
                    os.RemoveOrder(order);
                    label3.Text = "已删除订单" + dataGridView1.Rows[0].Cells[0].Value.ToString() + "请重新查询";
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(os, OrderDetails, Goods);
            Form3.ShowDialog();
        }
    }
}
