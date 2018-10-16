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

        private Graphics graphics;                     //创建图形
        
        bool Random=false;                             //判断是否随机

        int color=0;                                   //设置画笔颜色

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();

            if(Random)
            {
                Random n = new Random();
                color = n.Next(0, 5);           //随机生成颜色

                Random x0 = new Random();       //随机生成位置
                double x01=x0.Next(150, 300);
                Random y0 = new Random();
                double y01= y0.Next(200, 400);

                //位置比
                Random k = new Random();
                double k1=k.Next(0, 2);

                //角度
                Random r = new Random();
                int perr = r.Next(20, 50);
                double jiaodu1 = perr * Math.PI / 180;

                Random f = new Random();
                int pern = f.Next(20, 50);
                double jiaodu2 = pern * Math.PI / 180;

                //长度
                Random z = new Random();
                int thz = z.Next(1, 11);

                Random j = new Random();
                int j1 = j.Next(1, 11);
                double long1 = thz / 10.00;        //随机生成线条的长度
                double long2 = j1 / 10.00;       
                

                //字体的粗细
                Random love = new Random();
                float loveyou = love.Next(1,5);

                drawCayleyTree(10, x01, y01, 100, -Math.PI / 2, k1,  long1, long2, jiaodu1, jiaodu2, loveyou);
           
            }
            else
            {
                string s1 = textBox2.Text;
                string s2 = textBox3.Text;
                string s3 = textBox1.Text;
                string s4 = textBox4.Text;
                string s5 = textBox5.Text;

                double locak = double.Parse(s5);  //位置系数
                double a = double.Parse(s1);      //角度1
                double b = double.Parse(s2);      //角度2
                double c = double.Parse(s3);      //长度1
                double d = double.Parse(s4);      //长度2

                double th1 = a * Math.PI / 180;   //换算成度数
                double th2 = b * Math.PI / 180;

                string s6 = textBox6.Text;        //字体粗细程度
                float wide = float.Parse(s6);

                drawCayleyTree(10, 200, 310, 100, -Math.PI / 2, locak, c, d, th1, th2, wide);

            }
        }

        void drawCayleyTree(int n,double x0,double y0,double leng,double th,double k,double per1,double per2,double th1,double th2,float bold)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + leng * k * Math.Cos(th);
            drawLine(x0, y0, x1, y1,bold);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1,k,per1,per2,th1,th2,bold);
            drawCayleyTree(n - 1, x2, y1, per2 * leng, th - th2,k,per1,per2,th1,th2,bold);
        }

        void drawLine(double x0,double y0,double x1,double y1,float bold)
        {
            switch (color)
            {
                case 0:
                    Pen p1 = new Pen(Color.GreenYellow, bold);
                    graphics.DrawLine(p1, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 1:
                    Pen p2 = new Pen(Color.Red, bold);
                    graphics.DrawLine(p2, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 2:
                    Pen p3 = new Pen(Color.Yellow, bold);
                    graphics.DrawLine(p3, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 3:
                    Pen p4 = new Pen(Color.Blue, bold);
                    graphics.DrawLine(p4, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 4:
                    Pen p5 = new Pen(Color.Gray, bold);
                    graphics.DrawLine(p5, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            color = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            color = 2;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            color = 3;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            color = 4;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Random = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
