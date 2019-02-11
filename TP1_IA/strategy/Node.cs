using System;
using System.Collections.Generic;
using TP1_IA.model;

namespace TP1_IA.strategy
{
    public class Node
    {
        private Coordonnees posAgent;
        private List<Coordonnees> jewels;
        private List<Coordonnees> dust;
        private List<EnumIA.Action> actions;
        private int score;
        private Node father;
        private List<Node> children;

        public Node(Coordonnees posAgent, List<Coordonnees> jewels, List<Coordonnees> dust, int score)
        {
            this.posAgent = posAgent;
            this.jewels = jewels;
            this.dust = dust;
            this.score = score;
            children = new List<Node>();
        }

        public Node(Coordonnees posAgent, List<Coordonnees> jewels, List<Coordonnees> dust, List<EnumIA.Action> actions, int score, int heuristique, Node father, List<Node> children)
        {
            this.posAgent = posAgent;
            this.jewels = jewels;
            this.dust = dust;
            this.actions = actions;
            this.score = score;
            this.father = father;
            this.children = children;
        }
        private List<EnumIA.Action> actionsAvailable()
        {
            List<EnumIA.Action> action = new List<EnumIA.Action>();
            foreach (Coordonnees c in Jewels)
            {
                if (posAgent.Equals(posAgent))
                {
                    action.Add(EnumIA.Action.recuperer);
                }
            }
            foreach (Coordonnees c in Dust)
            {
                if (posAgent.Equals(posAgent))
                {
                    action.Add(EnumIA.Action.aspirer);
                }
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
        
        public List<Node> getNext()
        {
            List<Node> listenode = new List<Node>();

            foreach (EnumIA.Action action in actionsAvailable())
            {
                switch (action)
                {
                    case EnumIA.Action.bas:
                        listenode.Add(new Node(new Coordonnees(posAgent.X, posAgent.Y + 1),Jewels,Dust,
                            score - 1));
                        break;
                    case EnumIA.Action.haut:
                        listenode.Add(new Node(new Coordonnees(posAgent.X, posAgent.Y - 1),Jewels,Dust,
                            score - 1));
                        break;
                    case EnumIA.Action.droite:
                        listenode.Add(new Node(new Coordonnees(posAgent.X + 1, posAgent.Y),Jewels,Dust,
                            score - 1));
                        break;
                    case EnumIA.Action.gauche:
                        listenode.Add(new Node(new Coordonnees(posAgent.X - 1, posAgent.Y),Jewels,Dust,
                            score - 1));
                        break;
                    case EnumIA.Action.aspirer:
                        listenode.Add(new Node(posAgent,Jewels,posAgent.remove(Dust),
                            score + 10));
                        break;
                    case EnumIA.Action.recuperer:
                        Jewels.Remove(posAgent);
                        listenode.Add(new Node(posAgent,posAgent.remove(Jewels),Dust,
                            score + 30));
                        break;
                }
            }

            return listenode;
        }

        public void addChild(Node node)
        {
            children.Add(node);
        }

        public List<Node> nextNode()
        {
            return new List<Node>();
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

        public List<EnumIA.Action> Actions
        {
            get => actions;
            set => actions = value;
        }

        public Coordonnees Coordonnees
        {
            get => Coordonnees;
            set => Coordonnees = value;
        }

        public Boolean hasChild()
        {
            if (children.Equals(null))
                return false;
            return true;
        }

        public Node getChild(int index)
        {
            return children[index];
        }

        public Node getFather()
        {
            return father;
        }

        public int getScore()
        {
            return score;
        }


    }
    
}