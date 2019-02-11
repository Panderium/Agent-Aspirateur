using System;
using System.Collections.Generic;
using System.Linq;
using TP1_IA.strategy;

namespace TP1_IA.model
{
    class Agent
    {
        private Coordonnees _coordonnees;
        private Environnement _environnement;
        private Belief _belief;
        private int _score;
        private Desire _desire;
        private Intentions _intentions;
        private Capteurs _capteurs;
        private Effecteurs _effecteur;
        private Dictionary<String, int> _valeur;
        private SearchStrategy _strategy;
        public static Agent instance = null;

        public Agent() : this(new Coordonnees(0, 0), new Environnement(), new InformedSearch())
        {
        }

        public Agent(Coordonnees c, Environnement e, SearchStrategy strategy)
        {
            _coordonnees = c;
            _score = 0;
            _desire = new Desire();
            _intentions = new Intentions();
            _capteurs = new Capteurs();
            _effecteur = new Effecteurs();
            _valeur = new Dictionary<string, int>();
            _valeur.Add("deplacement", -1);
            _valeur.Add("poussiere", 10);
            _valeur.Add("bijou", 15);
            _strategy = strategy;
            _belief = new Belief();
        }

        private void setStategy(SearchStrategy strategy)
        {
            _strategy = strapritegy;
        }

        public int distance(Coordonnees a, Coordonnees b)
        {
            int distance = 0;
            distance += Math.Abs(a.X - b.X);
            distance += Math.Abs(a.Y - b.Y);
            return distance;
        }

        public Coordonnees lePlusProche(List<Coordonnees> liste)
        {
            int distance = 10000; // infini
            Coordonnees plusProche = null;
            foreach (Coordonnees c in liste)
            {
                if (distance > this.distance(_coordonnees, c))
                {
                    distance = this.distance(_coordonnees, c);
                    plusProche = c;
                }
            }

            return plusProche;
        }

        public void fillIntention(Coordonnees c, EnumIA.Action type)
        {
            while (distance(_coordonnees, c) > 0)
            {
                if (c.X > _coordonnees.X)
                    _intentions.empile(EnumIA.Action.droite);
                else
                {
                    if (c.X < _coordonnees.X)
                        _intentions.empile(EnumIA.Action.gauche);
                }

                if (c.Y > _coordonnees.Y)
                    _intentions.empile(EnumIA.Action.haut);
                else
                {
                    if (c.Y < _coordonnees.Y)
                        _intentions.empile(EnumIA.Action.bas);
                }

                if (c.X.Equals(_coordonnees.X) && c.Y.Equals(_coordonnees.Y))
                {
                    _intentions.empile(type);
                }
            }
        }

        public EnumIA.Action move()
        {
            return _intentions.depile();
        }
        private void observeEnvironment()
        {
            _capteurs.observeEnvironment(_environnement);
        }
        private void updateState()
        {
            _belief.updateBeliefs(_capteurs.Dust, _capteurs.Jewels);
        }
        private void chooseAction()
        {
            List<EnumIA.Action> actions = _strategy.execute();
            foreach (EnumIA.Action action in actions)
            {
                _intentions.empile(action);
            }
        }
        private void justDoIt()
        {
            
        }
        public void run()
        {
            while (true)
            {
                observeEnvironment();
                updateState();
                if (_belief.Dust.Any() && _belief.Jewels.Any()) continue;
                chooseAction();
                justDoIt();
            }
        }
        public static Agent Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Agent();
                }

                return instance;
            }
        }
       public Coordonnees Coordonnees
        {
            get => _coordonnees;
            set => _coordonnees = value;
        }
    }
}