using System;
using System.Collections.Generic;
using System.Linq;
using TP1_IA.model;

namespace TP1_IA.strategy
{
    public class UninformedSearch : SearchStrategy
    {
        private List<Node> search(Node curNode, int depth)
        {
            Queue<Node> file = new Queue<Node>();
            List<Node> visitedNode = new List<Node>();
            file.Enqueue(curNode);


            while (depth > 0 || Desire.desireReach(curNode))
            {
                curNode = file.Dequeue();
                if (!visitedNode.Contains(curNode))
                {
                    visitedNode.Add(curNode);
                    foreach (Node nextNode in curNode.nextNode())
                    {
                        file.Enqueue(nextNode);
                        depth--;
                    }
                }
            }

            return file.ToList();
        }

        public List<EnumIA.Action> execute(Node node, int depth)
        {
            var result = search(node, depth);
            var rand = new Random();
            return result.ElementAt(rand.Next(1, result.Count) - 1).Actions;
        }
    }
}