using System;

namespace TP1_IA.model
{
    class Environnement
    {
        private EnumIA.Chambre[ , ] chambres = new EnumIA.Chambre[10,10];
        private static Environnement instance;


        void Environment()
        {
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                    chambres[x, y] = EnumIA.Chambre.vide;
        }

        public void generateStuff()
        {
            Random rnd = new Random();
            int X = rnd.Next(0, 10); // creates a number between 0 and 9
            int Y = rnd.Next(0, 10);
            int typeStuff = rnd.Next(0, 10);

            if (typeStuff < 2)
            {
                if (chambres[X, Y] == EnumIA.Chambre.poussiere)
                    chambres[X, Y] = EnumIA.Chambre.poussiereEtBijou;

                if (chambres[X, Y] == EnumIA.Chambre.vide)
                    chambres[X, Y] = EnumIA.Chambre.bijou;
                
            }
            else
            {
                if (chambres[X, Y] == EnumIA.Chambre.bijou)
                    chambres[X, Y] = EnumIA.Chambre.poussiereEtBijou;

                if (chambres[X, Y] == EnumIA.Chambre.vide)
                    chambres[X, Y] = EnumIA.Chambre.poussiere;
            }

        }

        public EnumIA.Chambre getRoom(Coordonnees c)
        {
            return chambres[c.X, c.Y];
        }

        public void setRoom(Coordonnees c, EnumIA.Chambre ec)
        {
            chambres[c.X, c.Y] = ec;
        }

        public void cleaningRoom(Coordonnees c)
        {
            chambres[c.X, c.Y] = EnumIA.Chambre.vide;
        }

        public static Environnement Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new Environnement();
                }
                return instance;
            }
        }
    }
}
