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
            actions = new List<EnumIA.Action>();
        }

        public Node(Coordonnees posAgent, List<Coordonnees> jewels, List<Coordonnees> dust, List<EnumIA.Action> actions,
            int score, int heuristique, Node father, List<Node> children)
        {
            this.posAgent = posAgent;
            this.jewels = jewels;
            this.dust = dust;
            this.actions = actions;
            this.score = score;
            this.father = father;
            this.children = children;
            if(actions == null)
                actions = new List<EnumIA.Action>();
        }

        private List<EnumIA.Action> actionsAvailable()
        {
            List<EnumIA.Action> action = new List<EnumIA.Action>();
            foreach (Coordonnees c in Jewels)
            {
                if (c.Equals(posAgent))
                {
                    action.Add(EnumIA.Action.recuperer);
                }
            }

            foreach (Coordonnees c in Dust)
            {
                if (c.Equals(posAgent))
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

        public List<Node> nextNode()
        {
            List<Node> listNode = new List<Node>();

            foreach (EnumIA.Action action in actionsAvailable())
            {
                switch (action)
                {
                    case EnumIA.Action.bas:
                        List<EnumIA.Action> tempBas = new List<EnumIA.Action>();
                        tempBas.AddRange(this.actions);
                        tempBas.Add(EnumIA.Action.bas);
                        listNode.Add(new Node(posAgent.move(EnumIA.Action.bas), Jewels, Dust,
                           tempBas, score - 1, 0, this, null));
                        break;
                    case EnumIA.Action.haut:
                        List<EnumIA.Action> tempHaut = new List<EnumIA.Action>();
                        tempHaut.AddRange(this.actions);
                        tempHaut.Add(EnumIA.Action.haut);
                        listNode.Add(new Node(posAgent.move(EnumIA.Action.haut), Jewels, Dust,
                           tempHaut, score - 1, 0, this, null));
                        break;
                    case EnumIA.Action.droite:
                        List<EnumIA.Action> tempDroite = new List<EnumIA.Action>();
                        tempDroite.AddRange(this.actions);
                        tempDroite.Add(EnumIA.Action.droite);
                        listNode.Add(new Node(posAgent.move(EnumIA.Action.droite), Jewels, Dust,
                           tempDroite, score - 1, 0, this, null));
                        
                        break;
                    case EnumIA.Action.gauche:
                        List<EnumIA.Action> tempGauche = new List<EnumIA.Action>();
                        tempGauche.AddRange(this.actions);
                        tempGauche.Add(EnumIA.Action.gauche);
                        listNode.Add(new Node(posAgent.move(EnumIA.Action.gauche), Jewels, Dust,
                           tempGauche, score - 1, 0, this, null));
                        break;
                    case EnumIA.Action.aspirer:
                        Dust.Remove(posAgent);
                        List<EnumIA.Action> tempAspirer = new List<EnumIA.Action>();
                        tempAspirer.AddRange(this.actions);
                        tempAspirer.Add(EnumIA.Action.aspirer);
                        listNode.Add(new Node(posAgent, Jewels, posAgent.remove(Dust),
                           tempAspirer, score + 10, 0, this, null));
                        break;
                    case EnumIA.Action.recuperer:
                        Jewels.Remove(posAgent);
                        List<EnumIA.Action> tempRecuperer = new List<EnumIA.Action>();
                        tempRecuperer.AddRange(this.actions);
                        tempRecuperer.Add(EnumIA.Action.recuperer);
                        listNode.Add(new Node(posAgent, posAgent.remove(Jewels), Dust,
                           tempRecuperer, score + 30, 0, this, null));
                        break;
                }
            }

            return listNode;
        }

        public void addChild(Node node)
        {
            children.Add(node);
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
            return !children.Equals(null);
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