using System;

namespace TP1_IA.model
{
    class Environnement
    {
        private EnumIA.Chambre[ , ] chambres = new EnumIA.Chambre[10,10];
        private int score = 0;
        public int sRamasse = 30;
        public int sAspire = 10;
        public int sAspireBijoux = -50;
        
        Random rnd = new Random();

        public EnumIA.Chambre[,] Chambres
        {
            get => chambres;
            set => chambres = value;
        }

        private static Environnement instance=null;


        void Environment()
        {
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                    chambres[x, y] = EnumIA.Chambre.vide;

        }

        public void generateStuff()
        {
            while (true)
            {

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

                Program.updateUI();
                System.Threading.Thread.Sleep(1000);
                
            }
        }
        
        public void aspire( Coordonnees c)
        {
            EnumIA.Chambre ec = getRoom(c);
            switch (ec)
            {
                case EnumIA.Chambre.poussiere:
                    score += sAspire;
                    break;
                case EnumIA.Chambre.poussiereEtBijou:
                    score += sAspire;
                    score += sAspireBijoux;
                    break;
                case EnumIA.Chambre.bijou:
                    score += sAspireBijoux;
                    break;
            }
            setRoom(c, EnumIA.Chambre.vide);
            
        }
        public void ramasse( Coordonnees c)
        {
            EnumIA.Chambre ec = getRoom(c);
            switch (ec)
            {
                case EnumIA.Chambre.poussiere:
                    score -= 1;
                    break;
                case EnumIA.Chambre.poussiereEtBijou:
                    score += sRamasse;
                    setRoom(c, EnumIA.Chambre.poussiere);
                    break;
                case EnumIA.Chambre.bijou:
                    score += sRamasse;
                    setRoom(c, EnumIA.Chambre.vide);
                    break;
            }
            
        }
        public void move()
        {
            score -= 1;
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
