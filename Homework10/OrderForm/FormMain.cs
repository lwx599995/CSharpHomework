using ordertest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OrderForm
{
    public partial class FormMain : Form
    {
        OrderService orderService;
        BindingSource fieldsBS = new BindingSource();
        public FormMain()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            //var med = new odsEntities();

  
            Customer customer1 = new Customer(1, "张三",15270390336);
            Customer customer2 = new Customer(2, "李四",13634097159);

            Goods apple = new Goods(3, "apple", 5.6);
            Goods egg = new Goods(2, "egg", 4.9);
            Goods milk = new Goods(1, "milk", 69.9);

            OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, egg, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

            Order order1 = new Order(20181111111, customer1);
            Order order2 = new Order(20181114001, customer2);
            Order order3 = new Order(20181022666, customer2);

            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order1.AddDetails(orderDetails3);
            order2.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails3);

            orderService = new OrderService();
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);

        }

        public static bool OdIdIsRight(string StrSource)
        {
            return Regex.IsMatch(StrSource, @"^((((1[6-9]|[2-9]\d)\d{2})(0?[13578]|1[02])(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))([0-9]{3})$");
        }
        public static bool TelIsRight(string StrSource)
        {
            //电信手机
            string dx = @"^1[3578][01379]\d{8}$";
            Regex dR = new Regex(dx);
            //联通手机
            string lt = @"^1[34578][01256]\d{8}$";
            Regex lR = new Regex(lt);           
            //移动手机
            string yd = @"^134[012345678][01256]\d{7}|1[34578][0123456789]\d{8}$";
            Regex yR = new Regex(yd);

            if (dR.IsMatch(StrSource) || lR.IsMatch(StrSource) || yR.IsMatch(StrSource))
                return true;
            else
                return false;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormEdit form2 = new FormEdit(new Order());
            form2.ShowDialog();
            Order newOrder = form2.getResult();
            if (!OdIdIsRight(newOrder.Id.ToString()))
                MessageBox.Show("订单ID不符合要求，请重新确认", "ERROR1");
            if (OdIdIsRight(newOrder.Id.ToString())&&!TelIsRight(newOrder.Customer.TelNumber.ToString()))
                MessageBox.Show("客户电话有误，请重新确认", "ERROR2");
            if (newOrder!=null && OdIdIsRight(newOrder.Id.ToString()) && 
                TelIsRight(newOrder.Customer.TelNumber.ToString()))
            {
                orderService.AddOrder(newOrder);
                orderBindingSource.DataSource = orderService.QueryAllOrders();
            }
           
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            FormEdit form2 = new FormEdit((Order)orderBindingSource.Current);
            form2.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Order o=(Order)orderBindingSource.Current;
            if (o != null)
            {
                orderService.RemoveOrder(o.Id);
                orderBindingSource.DataSource=orderService.QueryAllOrders();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = saveFileDialog1.FileName;
                orderService.Export(fileName);
            }
           
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = openFileDialog1.FileName;
                orderService.Import(fileName);
                orderBindingSource.DataSource = orderService.QueryAllOrders();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (cbField.SelectedIndex)
            {
                case 0:
                    orderBindingSource.DataSource =
                        orderService.QueryAllOrders();
                    break;
                case 1:
                    ulong id = 0;
                    ulong.TryParse(txtValue.Text, out id);
                    orderBindingSource.DataSource = orderService.GetById(id);
                    break;
                case 2:
                    orderBindingSource.DataSource =
                            orderService.QueryByCustomerName(txtValue.Text);
                    break;
                case 3:
                    orderBindingSource.DataSource =
                            orderService.QueryByGoodsName(txtValue.Text);
                    break;
                case 4:
                    double price = 0;
                    double.TryParse(txtValue.Text, out price);
                    orderBindingSource.DataSource =
                           orderService.QueryByPrice(price);
                    break;
            }

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void outhtmlbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog2.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = saveFileDialog2.FileName;
                orderService.Export2html(fileName);
            }
        }
         
    }
}
