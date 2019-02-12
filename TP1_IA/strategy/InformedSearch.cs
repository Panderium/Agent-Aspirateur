using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TP1_IA.model;

namespace TP1_IA.strategy
{
    public class InformedSearch : SearchStrategy

    {
        private int weight = 10;

        //Add method to build tree


        public List<EnumIA.Action> execute(Node node, int depth)
        {
            throw new NotImplementedException();
        }

        public int heuristique(Coordonnees posAgent, List<Coordonnees> dusts, List<Coordonnees> jewels)
        {
            int onDustOrJewels = 0;
            int distance = 0;
            foreach (Coordonnees c in dusts)
            {
                if (c.distance(posAgent) == 0)
                    onDustOrJewels++;
                else distance += c.distance(posAgent);
            }

            foreach (Coordonnees c in jewels)
            {
                if (c.distance(posAgent) == 0)
                    onDustOrJewels++;
                else distance += c.distance(posAgent);
            }

            return weight * (jewels.Count + dusts.Count) + distance - weight * onDustOrJewels;
        }
    }
}