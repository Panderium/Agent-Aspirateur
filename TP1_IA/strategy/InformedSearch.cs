using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using TP1_IA.model;

namespace TP1_IA.strategy
{
    public class InformedSearch : SearchStrategy
    {
        //Add method to build tree
        private List<EnumIA.Action> search(Node node)
        {
            List<Node> closedList = new List<Node>();
            List<Node> openList = new List<Node>();
            openList.Add(node);
            
            while (openList.Any())
            {
                var curNode = selectNode(openList);
                openList.Remove(curNode);
                closedList.Add(node);
                if (Desire.desireReach(curNode) || curNode.Actions.Count > 10)
                {
                    return curNode.Actions;
                }

                foreach (var nNode in curNode.nextNode())
                {
                    
                    if (!openList.Contains(nNode))
                    {
                        openList.Add(nNode);
                    }
                    else if (nNode.Heuristic < curNode.Heuristic)
                    {    
                        curNode = nNode;
                    }
                }
            }

            return null;
        }


        public List<EnumIA.Action> execute(Node node, int depth)
        {
            return search(node);
        }

        private Node selectNode(List<Node> list)
        {
            var curNode = list.ElementAt(0);

            for (int i = 1; i < list.Count; i++)
            {
                if (curNode.Heuristic > list.ElementAt(i).Heuristic)
                {
                    curNode = list.ElementAt(i);
                }
            }

            return curNode;
        }
    }
}