using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_IA.model
{
    class Coordonnees
    {
        private int x;
        private int y;

        public Coordonnees(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
    }
}
