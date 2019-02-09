using System;
using System.Collections.Generic;
using TP1_IA.model;

namespace TP1_IA.strategy
{
    public class Node
    {
        private Connaissances _root;
        private List<Node> _children;

        public Node(Connaissances node)
        {
            _root = node;
        }

        public void addChild(Node node)
        {
            _children.Add(node);
        }

        public List<Connaissances> getNext()
        {
            return _root.getNext();
        }
    }
    
}