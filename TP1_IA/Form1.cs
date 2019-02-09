using System;
using System.Drawing;
using System.Windows.Forms;
using TP1_IA.model;

namespace TP1_IA
{
    public partial class Form1 : Form
{
    Graphics g;
    int numOfCells = 10;
    int cellSize = 50;
    
    
    
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

        Brush b = new SolidBrush(Color.White);

        Pen p = new Pen(b, 5f);

        
        for (int y = 0; y <= numOfCells; ++y)
        {
            g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
        }

        for (int x = 0; x <= numOfCells; ++x)
        {
            g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
        }
    }

    private void drawInCell(Pen p, EnumIA.Chambre chambre)
    {
        
    }


}
}
