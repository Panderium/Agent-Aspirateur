using System;
using System.Collections.Generic;

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

        public Coordonnees move(EnumIA.Action ea)
        {
            switch (ea)
            {
                case EnumIA.Action.gauche:
                    return new Coordonnees(this.X - 1, this.Y);
                case EnumIA.Action.droite:
                    return new Coordonnees(this.X + 1, this.Y);
                case EnumIA.Action.bas:
                    return new Coordonnees(this.X, this.Y + 1);
                case EnumIA.Action.haut:
                    return new Coordonnees(this.X, this.Y - 1);
                default:
                    return this;
            } 
        }

        public bool Equals(Coordonnees c)
        {
            return (c.X == X && c.Y == Y);
        }
        
        public int distance(Coordonnees a)
        {
            return Math.Abs(a.X - this.X)+ Math.Abs(a.Y - this.Y);
           
        }

        public List<Coordonnees> remove(List<Coordonnees> l)
        {
            List<Coordonnees> newlist = new List<Coordonnees>();
            foreach (Coordonnees c in l)
            {
                if (!c.Equals(this))
                {
                    newlist.Add(c);
                }
            }

            return newlist;
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
