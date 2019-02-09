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

        public Coordonnees move( EnumIA.Action a)
        {
            switch (a)
            {
                case EnumIA.Action.bas:
                    Y--;
                    break;
                case EnumIA.Action.haut:
                    Y++;
                    break;
                case EnumIA.Action.gauche:
                    X--;
                    break;
                case EnumIA.Action.droite:
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
