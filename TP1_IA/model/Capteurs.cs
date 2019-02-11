using System.Collections.Generic;

namespace TP1_IA.model
{
    class Capteurs
    {
        private List<Coordonnees> jewels;
        private List<Coordonnees> dust;

        public Capteurs()
        {
            jewels = new List<Coordonnees>();
            dust = new List<Coordonnees>();
        }

        public List<Coordonnees> Jewels
        {
            get => jewels;
            set => jewels = value;
        }

        public List<Coordonnees> Dust
        {
            get => dust;
            set => dust = value;
        }

        public void observeEnvironment(Environnement environnement)
        {
            for (int i = 0; i < environnement.Chambres.Length; i++)
            {
                for (int j = 0; j < environnement.Chambres.Length; j++)
                {
                    switch (environnement.Chambres[i, j])
                    {
                        case EnumIA.Chambre.bijou:
                            Jewels.Add(new Coordonnees(i, j));
                            break;
                        case EnumIA.Chambre.poussiere :
                            Dust.Add(new Coordonnees(i, j));
                            break;
                        case EnumIA.Chambre.poussiereEtBijou:
                            Jewels.Add(new Coordonnees(i, j));
                            Dust.Add(new Coordonnees(i, j));
                            break;
                    }
                }
            }
        }
    }
}