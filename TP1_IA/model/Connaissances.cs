using System.Collections.Generic;

namespace TP1_IA.model
{
    public class Connaissances
    {
        private EnumIA.Chambre[,] chambres;
        private Coordonnees posAgent;
        private int _score;

        public Connaissances(EnumIA.Chambre[,] chambres, Coordonnees posAgent, int score)
        {
            this.chambres = chambres;
            this.posAgent = posAgent;
            this._score = score;
        }

        public List<Connaissances> getNext()
        {
            List<Connaissances> connaissanceses = new List<Connaissances>();

            foreach (EnumIA.Action action in actionsAvailable())
            {
                switch (action)
                {
                    case EnumIA.Action.bas:
                        connaissanceses.Add(new Connaissances(chambres, new Coordonnees(posAgent.X, posAgent.Y + 1),
                            _score - 1));
                        break;
                    case EnumIA.Action.haut:
                        connaissanceses.Add(new Connaissances(chambres, new Coordonnees(posAgent.X, posAgent.Y - 1),
                            _score - 1));
                        break;
                    case EnumIA.Action.droite:
                        connaissanceses.Add(new Connaissances(chambres, new Coordonnees(posAgent.X + 1, posAgent.Y),
                            _score - 1));
                        break;
                    case EnumIA.Action.gauche:
                        connaissanceses.Add(new Connaissances(chambres, new Coordonnees(posAgent.X - 1, posAgent.Y),
                            _score - 1));
                        break;
                    case EnumIA.Action.aspirer:
                        connaissanceses.Add(new Connaissances(chambres, posAgent,
                            _score + 10));
                        break;
                    case EnumIA.Action.recuperer:
                        connaissanceses.Add(new Connaissances(chambres, posAgent,
                            _score + 30));
                        break;
                }
            }

            return connaissanceses;
        }

        private List<EnumIA.Action> actionsAvailable()
        {
            List<EnumIA.Action> action = new List<EnumIA.Action>();
            if (chambres[posAgent.X, posAgent.Y] == EnumIA.Chambre.poussiere)
            {
                action.Add(EnumIA.Action.aspirer);
            }

            if (chambres[posAgent.X, posAgent.Y] == EnumIA.Chambre.poussiereEtBijou ||
                chambres[posAgent.X, posAgent.Y] == EnumIA.Chambre.bijou)
            {
                action.Add(EnumIA.Action.recuperer);
            }

            if (posAgent.Y != 9)
            {
                action.Add(EnumIA.Action.bas);
            }

            if (posAgent.X != 0)
            {
                action.Add(EnumIA.Action.gauche);
            }

            if (posAgent.Y != 0)
            {
                action.Add(EnumIA.Action.haut);
            }

            if (posAgent.Y != 9)
            {
                action.Add(EnumIA.Action.droite);
            }

            return action;
        }

        public int Score
        {
            get => _score;
            set => _score = value;
        }
    }
}