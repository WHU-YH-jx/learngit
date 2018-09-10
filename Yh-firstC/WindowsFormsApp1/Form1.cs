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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        public void init()
        {
            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(button1);
            this.Controls.Add(label1);

            button1.Click += new System.EventHandler(this.button1_Click);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = textBox1.Text;
            string s2 = textBox2.Text;
            double m = double.Parse(s1);
            double n = double.Parse(s2);
            double mul = m*n;
            label1.Text = "两个数的乘积是：" + mul;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {
      
        }

    }
}
