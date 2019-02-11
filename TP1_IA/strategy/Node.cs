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
        private int heuristique;
        private Node father;
        private List<Node> children;

        public Node(Coordonnees posAgent, List<Coordonnees> jewels, List<Coordonnees> dust, int score, int heuristique)
        {
            this.posAgent = posAgent;
            this.jewels = jewels;
            this.dust = dust;
            this.score = score;
            this.heuristique = heuristique;
            children = new List<Node>();
        }

        public Node(Coordonnees posAgent, List<Coordonnees> jewels, List<Coordonnees> dust, List<EnumIA.Action> actions, int score, int heuristique, Node father, List<Node> children)
        {
            this.posAgent = posAgent;
            this.jewels = jewels;
            this.dust = dust;
            this.actions = actions;
            this.score = score;
            this.heuristique = heuristique;
            this.father = father;
            this.children = children;
        }

        public void addChild(Node node)
        {
            children.Add(node);
        }

        public List<Node> nextNode()
        {
            
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
    }
    
}