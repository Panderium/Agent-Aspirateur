using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP1_IA.model;
using Enum = TP1_IA.model.Enum;

namespace TP1_IA
{
    public partial class Form1 : Form
    {
        Graphics g = null;
        int numOfCells = 10;
        int cellSize = 50;


        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromHwnd(Handle);

        }

        public void updateUI()
        {
            this.Invalidate();
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Brush b = new SolidBrush(Color.White);

            Pen p = new Pen(b, 5f);


            for (int x = 0; x <= numOfCells; ++x)
            {
                g.DrawLine(p, 0, x * cellSize, numOfCells * cellSize, x * cellSize);

                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }

            //Coordonnees posAgent = Agent.Instance.Coordonnees;
            Coordonnees posAgent = new Coordonnees(5,5);
            Brush b2 = new SolidBrush(Color.Gold);
            g.FillRectangle(b2,posAgent.X * cellSize, posAgent.Y*cellSize, cellSize,cellSize );
            Environnement env = Environnement.Instance;
                
            drawInCell(p,env.Chambres );
        }

        private void drawInCell(Pen p, Enum.Chambre[,] chambre)

        {
            String s = "i";
            Font f = new Font(FontFamily.GenericMonospace, 20);

            for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)

            {
                s = "";
                switch (chambre[i, j])
                {
                    case Enum.Chambre.poussiere:
                        s = "P";
                        break;
                    case Enum.Chambre.bijou:
                        s = "B";
                        break;
                    case Enum.Chambre.poussiereEtBijou:
                        s = "PB";
                        break;
                    
                }

                g.DrawString(s, f, Brushes.White, i * cellSize + cellSize / 6, j * cellSize + cellSize / 6);
            }
        }
    }
}