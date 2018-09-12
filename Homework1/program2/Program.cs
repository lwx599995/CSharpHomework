using System;
using System.Windows.Forms;
using System.Drawing;
public class programtwo : Form
{
    TextBox TxtOne = new TextBox();
    TextBox TxtTwo = new TextBox();
    Button Btn = new Button();
    Label Lbl = new Label();

    //初始化界面
    public void init()
    {
        this.Controls.Add(TxtOne);
        this.Controls.Add(TxtTwo);
        this.Controls.Add(Btn);
        this.Controls.Add(Lbl);
        TxtOne.Dock = System.Windows.Forms.DockStyle.Top;
        TxtTwo.Dock = System.Windows.Forms.DockStyle.Top;
        Btn.Dock = System.Windows.Forms.DockStyle.Fill;
        Lbl.Dock = System.Windows.Forms.DockStyle.Bottom;
        Btn.Text = "求乘积";
        Lbl.Text = "显示结果";
        this.Size = new Size(500, 200);
        Btn.Click += new System.EventHandler(this.button1_click);
    }
    //点击后的事件
    public void button1_click(object sender, EventArgs e)
    {
        string s = "";
        s = TxtOne.Text;
        double a = Double.Parse(s);
        s = TxtTwo.Text;
        double b = Double.Parse(s);
        Lbl.Text = a + "*" + b + "=" + a * b;
    }
    static void Main(string[] args)
    {
        programtwo f = new programtwo();
        f.Text = "求两个数的乘积";
        f.init();
        Application.Run(f);
    }

}
