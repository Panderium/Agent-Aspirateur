﻿using System;
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
        private Effecteurs _effecteur;
        private Dictionary<String, int> _valeur;

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
            _effecteur = new Effecteurs();
            _valeur = new Dictionary<string, int>();
            _valeur.Add("deplacement", -1);
            _valeur.Add("poussiere", 10);
            _valeur.Add("bijou", 15);
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
                if (distance > this.distance(this._coordonnees, c))
                {
                    distance = this.distance(this._coordonnees, c);
                    plusProche = c;
                }
            }
            return plusProche;
        }

        public void fillIntention(Coordonnees c, Enum.Action type)
        {
            while(distance(_coordonnees, c) > 0){
                if (c.X > this._coordonnees.X)
                    _intentions.empile(Enum.Action.droite);
                else
                {
                    if (c.X < this._coordonnees.X)
                        _intentions.empile(Enum.Action.gauche);
                }

                if (c.Y > this._coordonnees.Y)
                    _intentions.empile(Enum.Action.haut);
                else
                {
                    if (c.Y < this._coordonnees.Y)
                        _intentions.empile(Enum.Action.bas);
                }
                if(c.X.Equals(this._coordonnees.X) && c.Y.Equals(this._coordonnees.Y))
                {
                    _intentions.empile(type);
                }
            }
        }

        public Enum.Action move()
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
            Enum.Action objectifType;
            if (-(distance(_coordonnees, lePlusProche(_connaissances.Bijoux))) + _valeur["bijou"] <
                    -(distance(_coordonnees, lePlusProche(_connaissances.Poussieres))) + _valeur["poussiere"])
            {
                objectifCoordonnee = lePlusProche(_connaissances.Bijoux);
                objectifType = Enum.Action.recuperer;
            }
            else
            {
                objectifCoordonnee = lePlusProche(_connaissances.Poussieres);
                objectifType = Enum.Action.aspirer;
            }

            fillIntention(objectifCoordonnee, objectifType);

            // move vers ce mouvement.
            while(_intentions.size() != 0)
            {
                Enum.Action action = move();
                _effecteur.act(action, _environnement, _coordonnees);
            }

        }
        }
}