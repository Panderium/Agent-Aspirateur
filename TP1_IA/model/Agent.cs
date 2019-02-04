using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_IA.model
{
    class Agent
    {
        private Coordonnees _coordonnees;
        private Environnement _environnement;
        private int _score;
        private Connaissances _connaissances;
        private Desire _desire;
        private Intentions _intentions;
        private Capteurs _capteurs;

        public Agent() : this(new Coordonnees(0,0), new Environnement()) { }

        public Agent(Coordonnees c, Environnement e)
        {
            _coordonnees = c;
            _environnement = e;
            _score = 0;
            _connaissances = new Connaissances();
            _desire = new Desire();
            _intentions = new Intentions();
            _capteurs = new Capteurs();
        }

        public int distance(Coordonnees a, Coordonnees b)
        {
            int distance = 0;
            distance += Math.Abs(a.X - b.X);
            distance += Math.Abs(a.Y - b.Y);
            return distance;
        }

        public void moveAndActToOptimum()
        {
            // chaque mouvement du robot lui fait perdre 1 point
            // les Bijoux et les Poussieres rapportent pas le même nombre de points
            // cherche le bijoux le plus proche et la poussière la plus proche, regarde celui qui raporte le plus de points en incluant les déplacements
            // donne les mouvements et l'actions à faire grâce aux énums sous forme de pile dans Intention.
        }
    }
}
