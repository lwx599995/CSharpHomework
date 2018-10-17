using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(10, 260, 380, 120, -Math.PI / 2);
        }
        private Graphics graphics;
        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            double th1 = (double.Parse(this.textBox2.Text)) * Math.PI / 180;  
            double th2 = (double.Parse(this.textBox4.Text)) * Math.PI / 180;  
            double per1 = double.Parse(this.textBox5.Text);
            double per2 = double.Parse(this.textBox6.Text);
            if (n == 0) return;
            double k = double.Parse(this.textBox1.Text); 
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + leng * k * Math.Cos(th);
            double y2 = y0 + leng * k * Math.Sin(th);

            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2);
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            double x = double.Parse(this.textBox3.Text);
            int n = int.Parse(this.textBox7.Text);
            Pen pen0 = new Pen(Color.Red, (float)x);
            Pen pen1 = new Pen(Color.Green, (float)x);
            Pen pen2 = new Pen(Color.Blue, (float)x);
            switch (n){
                case 0:
                    graphics.DrawLine(pen0, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 1:
                    graphics.DrawLine(pen1, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 2:
                    graphics.DrawLine(pen2, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
            }
        }


    }
}
