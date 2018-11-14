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
    public partial class AddOrder : Form
    {
        OrderDetails newO = null;
  
        public AddOrder()
        {
            InitializeComponent();
        }
        public OrderDetails GetOrderI()
        {
            return newO;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string GoodsName = textBox1.Text;
            string s2 = textBox2.Text;
            int GoodsNumber = int.Parse(s2);
            string s3 = textBox3.Text;
            double GoodsPrice = double.Parse(s3);
            string CustomerName = textBox4.Text;
            string s4 = textBox5.Text;
            string s5 = textBox6.Text;
            newO= new OrderDetails(s4, CustomerName, GoodsName, GoodsNumber, GoodsPrice,s5);

            this.Close();
 
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
