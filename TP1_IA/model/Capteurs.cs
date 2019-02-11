using System.Collections.Generic;

namespace TP1_IA.model
{
    class Capteurs
    {
        private List<Coordonnees> jewels;
        private List<Coordonnees> dust;
        private Environnement env;

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

        public void observeEnvironment()
        {
            for (int i = 0; i < env.Chambres.Length; i++)
            {
                for (int j = 0; j < env.Chambres.Length; j++)
                {
                    switch (env.Chambres[i, j])
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