using System;
using System.Collections;
using System.Windows.Forms;
using TP1_IA.model;
using Enum = TP1_IA.model.Enum;

namespace TP1_IA.strategy
{
    public class Arbre
    {
        private static int _max_dept=8;
        private Arbre _parent = null;
        private ArrayList _enfant = new ArrayList();
        private int _profondeur = 0;
        private int _score = 0;
        private Coordonnees _position = null;

        public Arbre build(Coordonnees pos,Connaissances c, Arbre n)
        {
            
            if (n.Profondeur > _max_dept)
            {
                return n;
            }
            n.Position = pos;
            foreach (Enum.Action a in actionsAvailable(pos))
            {   
                Arbre enf = new Arbre();
                enf.Parent = n;
                enf.Profondeur = n.Profondeur + 1;
                n.Enfant.Add(build(pos.move(a),c,enf));
            }
            

        }
        
        public ArrayList actionsAvailable(Coordonnees pos)
        {    ArrayList action = new ArrayList();
            action.Add(Enum.Action.aspirer);
            action.Add(Enum.Action.recuperer);
            if (pos.X != 0)
            {
                action.Add(Enum.Action.bas);
            }
            if (pos.Y != 0)
            {
                action.Add(Enum.Action.gauche);
            }
            if (pos.X != 9)
            {
                action.Add(Enum.Action.haut);
            }
            if (pos.Y != 9)
            {
                action.Add(Enum.Action.droite);
            }

            return action;
        }
        
        public Arbre Parent
        {
            get => _parent;
            set => _parent = value;
        }

        public ArrayList Enfant
        {
            get => _enfant;
            set => _enfant = value;
        }

        public int Profondeur
        {
            get => _profondeur;
            set => _profondeur = value;
        }

        public int Score
        {
            get => _score;
            set => _score = value;
        }

        public Coordonnees Position
        {
            get => _position;
            set => _position = value;
        }

    }
    
    
}