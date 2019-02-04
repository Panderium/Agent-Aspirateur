using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_IA.model
{
    class Agent
    {
        private Coordonnees coordonnees;
        private Environnement environnement;
        private int score;
        private Connaissances connaissances;
        private Desire desire;
        private Intentions intentions;
        private Capteurs capteurs;

        public Agent() : this(new Coordonnees(0,0), new Environnement()) { }

        public Agent(Coordonnees c, Environnement e)
        {
            coordonnees = c;
            environnement = e;
            score = 0;
            connaissances = new Connaissances();
            desire = new Desire();
            intentions = new Intentions();
            capteurs = new Capteurs();
        }

        public int distance(Coordonnees a, Coordonnees b)
        {
            int distance = 0;
            distance += Math.Abs(a.getX() - b.getX());
            distance += Math.Abs(a.getY() - b.getY());
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
