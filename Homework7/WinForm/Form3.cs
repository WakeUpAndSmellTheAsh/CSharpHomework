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
    public partial class Form3 : Form
    {
        OrderService os = new OrderService();
        List<Goods> goods = new List<Goods>();
        List<OrderDetail> orderDetails = new List<OrderDetail>();
        List<Order> orders = null;

        public Form3(OrderService Os,  List<OrderDetail> OrderDetails, List<Goods> Goods)
        {
            os = Os;
            orders = os.QueryAllOrders();
            orderDetails = OrderDetails;
            goods = Goods;
           
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            foreach (Order od in orders)
                comboBox1.Items.Add(od.OrderId + od.OrderCustomer + od.Amount);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (OrderDetail od in orderDetails)
                comboBox2.Items.Add(od.Id + od.Goods.GoodName + "(" + od.Goods.GoodId + ")" + od.Quantity);
            foreach (Goods g in goods)
                comboBox3.Items.Add(g.GoodId);

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Goods g in goods)
                comboBox4.Items.Add(g.GoodId + g.GoodName + g.Price);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
