using System;
using System.Collections.Generic;
using TP1_IA.model;

namespace TP1_IA.strategy
{
    public class UninformedSearch : SearchStrategy
    {
        private Node search(Node node, int depth)
        {
            if (!Desire.desireReach(node) && depth != 0)
            {
                foreach (Node nextNode in node.nextNode())
                {
                    search(nextNode, depth - 1);
                }
            }

            return node;
        }

        public void execute(Node node, int depth)
        {
            search(node, depth).;
        }
    }
}