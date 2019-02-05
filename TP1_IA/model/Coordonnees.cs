using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_IA.model
{
    public class Coordonnees
    {
        private int _x;
        private int _y;

        public Coordonnees(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordonnees move( Enum.Action a)
        {
            switch (a)
            {
                case Enum.Action.bas:
                    Y--;
                    break;
                case Enum.Action.haut:
                    Y++;
                    break;
                case Enum.Action.gauche:
                    X--;
                    break;
                case Enum.Action.droite:
                    X++;
                    break;
            }

            return this;
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}
