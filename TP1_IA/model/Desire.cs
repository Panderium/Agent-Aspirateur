using System.Collections.Generic;
using System.Linq;
using TP1_IA.strategy;

namespace TP1_IA.model
{
    static class Desire
    {
        public static bool desireReach(Node node)
        {
            //return (node.Actions.Contains(EnumIA.Action.aspirer) || node.Actions.Contains(EnumIA.Action.recuperer));
            return !(node.Dust.Any() || node.Jewels.Any());
        }


        public static List<EnumIA.Action> selectBetterNode(List<Node> l)
        {
            int min = 10000;
            List<EnumIA.Action> aMax = new List<EnumIA.Action>();
            foreach (Node n  in l)
            {
                int nbAction = n.Dust.Count + n.Jewels.Count;
                if (nbAction < min)
                {
                    min = nbAction;
                    aMax = n.Actions;
                }
            }

            return aMax;
        }
    }
}