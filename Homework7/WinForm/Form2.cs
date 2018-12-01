using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form2 : Form
    {
        public event setGood setGoodValue;
        public event setDetail setDetailValue;
        public event setOrder setOrderValue;
       

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            setGoodValue(textBox1.Text,double.Parse(textBox2.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setDetailValue(int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setOrderValue(int.Parse(textBox7.Text), textBox5.Text);
        }
    }
    public delegate void setGood(string Name, double price);
    public delegate void setDetail(int GoodId, int Quantity);
    public delegate void setOrder(int DetailId, string Name);

}
