using System.Collections.Generic;
using System.Linq;
using TP1_IA.strategy;

namespace TP1_IA.model
{
    static class Desire
    {
        public static bool desireReach(Node node)
        {
            return !(node.Dust.Any() || node.Jewels.Any());
        }
    }
}