using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TP1_IA.strategy;

namespace TP1_IA.model
{
    class Agent
    {
        private Coordonnees _coordonnees;
        private Belief _belief;
        private int _score;
        private Intentions _intentions;
        private Capteurs _capteurs;
        private Effecteurs _effecteur;
        private SearchStrategy _strategy;
        public static Agent instance = null;

        public Agent() : this(new Coordonnees(0, 0), new InformedSearch())
        {
        }

        public Agent(Coordonnees c, SearchStrategy strategy)
        {
            _coordonnees = c;
            _score = 0;
            _intentions = new Intentions();
            _capteurs = new Capteurs();
            _effecteur = new Effecteurs();
            _strategy = strategy;
            _belief = new Belief();
        }

        public void setStategy(SearchStrategy strategy)
        {
            _strategy = strategy;
        }

        
        public EnumIA.Action move()
        {
            return _intentions.depile();
        }

        private void updateState()
        {
            _belief.updateBeliefs(_capteurs.Dust, _capteurs.Jewels);
        }
        private void chooseAction()
        {
            List<EnumIA.Action> actions = _strategy.execute(new Node(Coordonnees, Belief.Jewels, Belief.Dust, Score), 5);
            foreach (EnumIA.Action action in actions)
            {
                _intentions.empile(action);
            }
        }
        private void justDoIt()
        {
            int nbIter = 5;
            for (int i = 0; i < nbIter; i++)
            {   
                if (_intentions.size() != 0)
                _effecteur.act(_intentions.depile(), _coordonnees);
                Program.updateUI();
                Thread.Sleep(200);
            }
            _intentions.vider();
        }
        public void run()
        {    
            while (true)
            {
                Capteurs.observeEnvironment();
                
                updateState();
                if ( !_belief.Dust.Any() && !_belief.Jewels.Any()) continue;
                chooseAction();
                Console.WriteLine("Intentions: "+ Intentions.ToString());

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
       public Belief Belief
       {
           get => _belief;
           set => _belief = value;
       }

       public int Score
       {
           get => _score;
           set => _score = value;
       }


       public Intentions Intentions
       {
           get => _intentions;
           set => _intentions = value;
       }

       public Capteurs Capteurs
       {
           get => _capteurs;
           set => _capteurs = value;
       }

       public Effecteurs Effecteur
       {
           get => _effecteur;
           set => _effecteur = value;
       }

       public SearchStrategy Strategy
       {
           get => _strategy;
           set => _strategy = value;
       }
    }
}