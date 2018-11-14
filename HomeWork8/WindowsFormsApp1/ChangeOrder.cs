using HomeWork7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ChangeOrder : Form
    {
        OrderDetails changeOrder = null;
        public ChangeOrder()
        {
            InitializeComponent();
        }
        public OrderDetails GetOrderI()
        {
            return changeOrder;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string OrderNum = textBox1.Text;
            string Goodsname = textBox2.Text;
            string CustomerName = textBox5.Text;
            string GoodsNum = textBox3.Text;
            int goodnum = int.Parse(GoodsNum);
            string CustomerPNumber= textBox4.Text;
            double a = 1.00;
            changeOrder = new OrderDetails(OrderNum, CustomerName, Goodsname, goodnum, a, CustomerPNumber);
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
