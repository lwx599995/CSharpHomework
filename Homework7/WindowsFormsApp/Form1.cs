using ordertest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
 
        OrderService os = new OrderService();
        public string Explain { get; set; }
        public Form1()
        {
            InitializeComponent();
            //初始化订单服务系统
            //客户信息（名字）
            string customer1 = "Customer1";
            string customer2 = "Customer2";
            //商品信息（商品编号、名称、单价）
            Goods milk = new Goods("food_milk_800", "Milk", 69.9);
            Goods eggs = new Goods("food_egg_520", "eggs", 4.9);
            Goods apple = new Goods("food_apple_360", "apple", 5.6);
            //订单明细（交易编号、商品种类、交易数额）
            OrderDetail orderDetails1 = new OrderDetail("Mon100", apple, 1780);
            OrderDetail orderDetails2 = new OrderDetail("Wed030", eggs, 20);
            OrderDetail orderDetails3 = new OrderDetail("Fri008", milk, 1);
            //订单信息（订单号、客户名称）
            Order order1 = new Order("a1", customer1);
            Order order2 = new Order("b1", customer2);
            Order order3 = new Order("c1", customer2);
            //为每笔订单添加信息
            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order1.AddDetails(orderDetails3);
            order2.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails3);
            //将所有订单添加至订单管理器中
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);

            /*   Order []ods = { order1, order2, order3};
                bindingSource1.DataSource = ods;
                */
            Explain = "操作了很久，还是没有学会怎样将订单的信息和订单详情一起添加到" +
                "DataGridView当中去。\r\n\r\n然后不得不用继续用Form的TextBox来实现功能展示了" +
                "。\r\n\r\n希望能在下次课堂上能够听到老师讲解，再进一步学习。" +
                "\r\n\r\n然后就是功能的实现还有缺陷" +
                "\r\n\r\n添加订单还不能实现增加明细，只能添加ID和客户姓名" +
                "\r\n\r\n修改订单目前只能修改客户的姓名" +
                "\r\n\r\n（因为要在新建的Form窗口上添加这么多控件，并且代码要自己写太复杂了，我还不太掌握）" +
                "\r\n\r\n希望能等老师答疑之后再做改进。";


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox5.DataBindings.Add("Text", this, "Explain");
        }
        private void button1_Click(object sender, EventArgs e)
        {
           string s = "GetAllOrders\r\n";
            List<Order> orders = os.QueryAllOrders();
            foreach (Order od in orders)
                s += od.ToString()+ "\r\n";
            textBox5.Text = s;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string s = $"GetOrdersByCustomerName:'{textBox1.Text}'\r\n";
            List<Order>  orders = os.QueryByCustomerName(textBox1.Text);
            foreach (Order od in orders)
                s += od.ToString() + "\r\n";
            if (orders.Count == 0)
                s += "notFound";
            textBox5.Text = s;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = $"GetOrdersByGoodsName:'{textBox2.Text}'\r\n";
            List<Order> orders = os.QueryByGoodsName(textBox2.Text);
            foreach (Order od in orders)
                s += od.ToString() + "\r\n";
            if (orders.Count ==0 )
                s += "notFound";
            textBox5.Text = s;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = $"GetById:'{textBox3.Text}'\r\n";
            Order od = os.GetById(textBox3.Text);
                s += od.ToString() + "\r\n";
            textBox5.Text = s;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string s = $"QueryByTotalPrice:'{textBox4.Text}'(>={textBox4.Text})\r\n";
                List<Order> orders = os.QueryByTotalPrice(double.Parse(textBox4.Text));
                foreach (Order od in orders)
                    s += od.ToString() + "\r\n";
                if (orders.Count == 0)
                    s += "notFound";
                textBox5.Text = s;
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button b = new Button();
            Form f = new Form();
            System.Windows.Forms.Label l = new System.Windows.Forms.Label();
            TextBox t = new TextBox();
            l.Text = "请输入要删除的订单号";
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Dock = DockStyle.Top;
            l.BackColor = SystemColors.ActiveCaption;
            l.ForeColor = SystemColors.ControlLight;
            t.Dock = DockStyle.Top;
            b.Dock = DockStyle.Fill;
            b.Text = "确定!并在初始窗口展示结果";
        
            b.TextAlign = ContentAlignment.MiddleCenter;
            b.DialogResult = DialogResult.Cancel;
            f.Controls.Add(l);
            f.Controls.Add(t);
            f.Controls.Add(b);
            f.ShowDialog();

            if (f.DialogResult == DialogResult.Cancel)
            {

                string s = "AfterRemove\r\n";
                os.RemoveOrder(t.Text);
                List<Order> orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    s += od.ToString() + "\r\n";
                if (orders.Count == 0)
                    s += "notFound";
                textBox5.Text = s;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button b = new Button();
            Form f = new Form();
            System.Windows.Forms.Label l = new System.Windows.Forms.Label();
            TextBox t = new TextBox();
            TextBox t1 = new TextBox();
            l.Text = "请按顺序输入要添加的订单号和客户名单";

            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Dock = DockStyle.Top;
            l.BackColor = SystemColors.ActiveCaption;
            l.ForeColor = SystemColors.ControlLight;
            t.Dock = DockStyle.Top;
            t1.Dock = DockStyle.Top;
            string customer = t.Text;

            b.Dock = DockStyle.Fill;
            b.Text = "确定!并在初始窗口展示结果";

            b.TextAlign = ContentAlignment.MiddleCenter;
            b.DialogResult = DialogResult.Cancel;
            f.Controls.Add(l);
            f.Controls.Add(t);
            f.Controls.Add(t1);
            f.Controls.Add(b);
            f.ShowDialog();

            if (f.DialogResult == DialogResult.Cancel)
            {
                Order _od = new Order(t1.Text, t.Text);
                string s = "AfterAdd\r\n";
                os.AddOrder(_od);
                List<Order> orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    s += od.ToString() + "\r\n";
                if (orders.Count == 0)
                    s += "notFound";
                textBox5.Text = s;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button b = new Button();
            Form f = new Form();
            System.Windows.Forms.Label l = new System.Windows.Forms.Label();
            TextBox t = new TextBox();
            TextBox t1 = new TextBox();
            l.Text = "请按顺序输入要修改的订单号和新的客户名字";

            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Dock = DockStyle.Top;
            l.BackColor = SystemColors.ActiveCaption;
            l.ForeColor = SystemColors.ControlLight;
            t.Dock = DockStyle.Top;
            t1.Dock = DockStyle.Top;
            string customer = t.Text;

            b.Dock = DockStyle.Fill;
            b.Text = "确定!并在初始窗口展示结果";

            b.TextAlign = ContentAlignment.MiddleCenter;
            b.DialogResult = DialogResult.Cancel;
            f.Controls.Add(l);
            f.Controls.Add(t);
            f.Controls.Add(t1);
            f.Controls.Add(b);
            f.ShowDialog();

            if (f.DialogResult == DialogResult.Cancel)
            {
                Order aim = os.GetById(t1.Text);
                aim.Customer = t.Text;
                string s = "AfterModify\r\n";
                List<Order> orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    s += od.ToString() + "\r\n";
                if (orders.Count == 0)
                    s += "notFound";
                textBox5.Text = s;
            }
        }
    }
    
}
