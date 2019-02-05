using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_IA.model
{
    class Environnement
    {
        private Enum.Chambre[ , ] chambres = new Enum.Chambre[10,10];
        private static Environnement instance=null;


        void Environment()
        {
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                    chambres[x, y] = Enum.Chambre.vide;
        }

        public void generateStuff()
        {
            Random rnd = new Random();
            int X = rnd.Next(0, 10); // creates a number between 0 and 9
            int Y = rnd.Next(0, 10);
            int typeStuff = rnd.Next(0, 10);

            if (typeStuff < 2)
            {
                if (chambres[X, Y] == Enum.Chambre.poussiere)
                    chambres[X, Y] = Enum.Chambre.poussiereEtBijou;

                if (chambres[X, Y] == Enum.Chambre.vide)
                    chambres[X, Y] = Enum.Chambre.bijou;
                
            }
            else
            {
                if (chambres[X, Y] == Enum.Chambre.bijou)
                    chambres[X, Y] = Enum.Chambre.poussiereEtBijou;

                if (chambres[X, Y] == Enum.Chambre.vide)
                    chambres[X, Y] = Enum.Chambre.poussiere;
            }

        }

        public Enum.Chambre getRoom(Coordonnees c)
        {
            return chambres[c.X, c.Y];
        }

        public void setRoom(Coordonnees c, Enum.Chambre ec)
        {
            chambres[c.X, c.Y] = ec;
        }

        public void cleaningRoom(Coordonnees c)
        {
            chambres[c.X, c.Y] = Enum.Chambre.vide;
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
