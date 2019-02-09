using System;
using System.Collections;
using TP1_IA.model;

namespace TP1_IA.strategy
{
    public class Arbre
    {
        private int _maxDepth;
        private Connaissances _connaissances;
        private Node _root;

        public Arbre(int maxDepth, Connaissances connaissances)
        {
            _maxDepth = maxDepth;
            _connaissances = connaissances;
            _root = new Node(connaissances);

            build(_root, 0);
        }

        public Node build(Node node, int curDepth)
        {
            if (curDepth <= MaxDepth)
            {
                foreach (Connaissances c in node.getNext())
                {
                    Node child = new Node(c);
                    node.addChild(build(child, curDepth + 1));
                }
            }
            return node;
        }

        public int MaxDepth
        {
            get => _maxDepth;
            set => _maxDepth = value;
        }

        public Connaissances Connaissances
        {
            get => _connaissances;
            set => _connaissances = value;
        }
    }
}