using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_IA
{
    public partial class Form1 : Form
{
    Graphics g = null;
    public Form1()
    {
        InitializeComponent();
        g = Graphics.FromHwnd(Handle);

    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Brush b = new SolidBrush(Color.Black);

        Pen pen = new Pen(b, 20.5f);


        for ( int i=0;i<10 ;i++)
        {
            g.DrawLine(pen, new Point(0, i*Height/10), new Point(this.Width, 0));
            
        }
    }


}
}
