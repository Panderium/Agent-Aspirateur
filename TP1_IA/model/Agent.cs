using System;
using System.Collections.Generic;
using TP1_IA.strategy;

namespace TP1_IA.model
{
    class Agent
    {
        private Coordonnees _coordonnees;

        public Coordonnees Coordonnees
        {
            get => _coordonnees;
            set => _coordonnees = value;
        }

        private Environnement _environnement;
        private int _score;
        private Desire _desire;
        private Intentions _intentions;
        private Capteurs _capteurs;
        private Effecteurs _effecteur;
        private Dictionary<String, int> _valeur;
        private SearchStrategy _strategy;
        public static Agent instance = null;

        public Agent() : this(new Coordonnees(0,0), new Environnement(), new InformedSearch()) { }

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
        }
        
        private void changeStrategy(SearchStrategy strategy)
        {
            _strategy = strategy;
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
            while(distance(_coordonnees, c) > 0){
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
                if(c.X.Equals(_coordonnees.X) && c.Y.Equals(_coordonnees.Y))
                {
                    _intentions.empile(type);
                }
            }
        }

        public EnumIA.Action move()
        {
            return _intentions.depile();
        }

        public void moveAndActToOptimum()
        {
            
            // chaque mouvement du robot lui fait perdre 1 point
            // les Bijoux et les Poussieres rapportent pas le même nombre de points
            // cherche le bijoux le plus proche et la poussière la plus proche, regarde celui qui raporte le plus de points en incluant les déplacements
            // donne les mouvements et l'actions à faire grâce aux énums sous forme de pile dans Intention.

            // quel mouvement est le plus rentable
            Coordonnees objectifCoordonnee = null;
            EnumIA.Action objectifType;
            if (-(distance(_coordonnees, lePlusProche(_connaissances.Bijoux))) + _valeur["bijou"] <
                -(distance(_coordonnees, lePlusProche(_connaissances.Poussieres))) + _valeur["poussiere"])
            {
                objectifCoordonnee = lePlusProche(_connaissances.Bijoux);
                objectifType = EnumIA.Action.recuperer;
            }
            else
            {
                objectifCoordonnee = lePlusProche(_connaissances.Poussieres);
                objectifType = EnumIA.Action.aspirer;
            }

            fillIntention(objectifCoordonnee, objectifType);

            // move vers ce mouvement.
            while(_intentions.size() != 0)
            {
                EnumIA.Action action = move();
                _effecteur.act(action, _environnement, _coordonnees);
            }

        }
        public static Agent Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new Agent();
                }
                return instance;
            }
        }
    }
}