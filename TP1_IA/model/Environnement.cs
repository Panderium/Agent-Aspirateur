using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_IA.model
{
    class Environnement
    {
        private Enum.EnumChambre[ , ] chambres = new Enum.EnumChambre[10,10];

        void Environment()
        {
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                    chambres[x, y] = Enum.EnumChambre.vide;
        }

        public void generateStuff()
        {
            Random rnd = new Random();
            int X = rnd.Next(0, 10); // creates a number between 0 and 9
            int Y = rnd.Next(0, 10);
            int typeStuff = rnd.Next(0, 10);

            if (typeStuff < 2)
            {
                if (chambres[X, Y] == Enum.EnumChambre.poussiere)
                    chambres[X, Y] = Enum.EnumChambre.poussiereEtBijou;

                if (chambres[X, Y] == Enum.EnumChambre.vide)
                    chambres[X, Y] = Enum.EnumChambre.bijou;
                
            }
            else
            {
                if (chambres[X, Y] == Enum.EnumChambre.bijou)
                    chambres[X, Y] = Enum.EnumChambre.poussiereEtBijou;

                if (chambres[X, Y] == Enum.EnumChambre.vide)
                    chambres[X, Y] = Enum.EnumChambre.poussiere;
            }

        }

        public Enum.EnumChambre getRoom(Coordonnees c)
        {
            return chambres[c.X, c.Y];
        }

        public void setRoom(Coordonnees c, Enum.EnumChambre ec)
        {
            chambres[c.X, c.Y] = ec;
        }

        public void cleaningRoom(Coordonnees c)
        {
            chambres[c.X, c.Y] = Enum.EnumChambre.vide;
        }
    }
}
