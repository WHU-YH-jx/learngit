using HomeWork7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace WindowsFormsApp1
{
    public partial class FormMain : Form
    {
        OrderService Oporder;
        BindingSource fieldsBS = new BindingSource();
        public FormMain()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {

            OrderDetails FirstOrder = new OrderDetails("2018/11/13/001", "JX1", "一点点", 1, 1.5, "125-2111-3142");         //初始化订单
            OrderDetails SecondOrder = new OrderDetails("2018/11/13/002", "JX2", "两点点", 2, 2.5, "134-5211-3142");
            OrderDetails ThirdOrder = new OrderDetails("2018/11/13/003", "JX3", "三点点", 3, 3.5, "125-5211-3142");
            OrderDetails FourthOrder = new OrderDetails("2018/11/13/004", "JX4", "四点点", 4, 4.5, "521-5211-3142");
            Oporder = new OrderService();

            Oporder.AddOrder(FirstOrder);
            Oporder.AddOrder(SecondOrder);
            Oporder.AddOrder(ThirdOrder);
            Oporder.AddOrder(FourthOrder);
            
        }
        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void AddOrder()
        {
            AddOrder addform = new AddOrder();
            addform.ShowDialog();
            OrderDetails newOdetail = addform.GetOrderI();
            if (newOdetail != null)
            {
                Oporder.OrderList.Add(newOdetail);
                OporderbindingSource1.DataSource = Oporder;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AddOrder();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }
        private void ChangeOrder()
        {
            ChangeOrder changeform = new ChangeOrder();
            changeform.ShowDialog();
            OrderDetails newOdetail = changeform.GetOrderI();
            for (int i = 0; i < Oporder.OrderList.Count; i++)
            {
                if (newOdetail != null && newOdetail.OrderNumber == Oporder.OrderList[i].OrderNumber)
                {
                    Oporder.OrderList[i] = newOdetail;
                    OporderbindingSource1.DataSource = Oporder;
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ChangeOrder();
        }
        private void LookForOrder()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    OporderbindingSource1.DataSource = Oporder;
                    break;
                case 1:
                    OrderDetailbindingSource1.DataSource = Oporder.LookForOrderI(textBox2.Text);
                    break;
                case 2:
                    OrderDetailbindingSource1.DataSource = Oporder.LookForOrderS(textBox2.Text);
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LookForOrder();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public ArrayList JudgePNumber()          //验证客户手机号是否正确
        {
            ArrayList Array = new ArrayList();
            Regex rx = new Regex("[0-9]{3}-[0-9]{4}-[0-9]{4}");
            for (int i=0;i<Oporder.OrderList.Count;i++)
            {
                bool ok = rx.IsMatch(Oporder.OrderList[i].CustomerPNumber);
                if(ok==false)
                {
                    int j = i + 1;
                    Array.Add(j);
                }
            }
            return Array;
        }
        public ArrayList JudgeOrderNumber()           //验证订单号是否正确
        {
            ArrayList Array = new ArrayList();
            Regex rx = new Regex("[0-9]{4}/[0-9]{2}/[0-9]{2}/[0-9]{3}");
            for (int i = 0; i < Oporder.OrderList.Count; i++)
            {
                bool ok = rx.IsMatch(Oporder.OrderList[i].OrderNumber);
                if (ok == false)
                {
                    int j = i + 1;
                    Array.Add(j); 
                }
            }
            return Array;
        }
        public void ExportHTML()                      //输出成html文件
        {
            Oporder.Export("a.xml", Oporder.OrderList);
            XslCompiledTransform trans = new XslCompiledTransform();
            trans.Load(@"C:\Users\10929\learngit\HomeWork7\HomeWork7\bin\Debug\new 1.xstl");
            trans.Transform(@"C:\Users\10929\learngit\HomeWork7\HomeWork7\bin\Debug\a.xml", @"C:\Users\10929\learngit\HomeWork7\HomeWork7\bin\Debug\out.html");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ArrayList h1 = JudgePNumber();
            ArrayList h2 = JudgeOrderNumber();
     
            if(h1!=null)
            {
                textBox1.Visible = true;
                for (int i = 0; i < h1.Count; i++)
                {
                   
                    textBox1.Text += "第" + h1[i] + "个订单的手机号出现了问题！！！！" + "\n";
                }
                if (h2 != null)
                {
                    for (int j = 0; j < h2.Count; j++)
                    {
                        textBox1.Text += "第" + h2[j] + "个订单的订单号出现了问题！！！！";
                    }
                }
            }
            else if(h2!=null)
            {
                textBox1.Visible = true;
                for (int j = 0; j < h2.Count; j++)
                {
                    textBox1.Text += "第" + h2[j] + "个订单的订单号出现了问题！！！！";
                }
            }
            else
            {
                textBox1.Visible = true;
                textBox1.Text ="所有订单的订单号及手机号均正确！！！";
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExportHTML();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            string delete = textBox3.Text;
            Oporder.DeleteOrderI(delete);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
