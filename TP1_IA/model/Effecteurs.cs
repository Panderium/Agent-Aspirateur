using System;

namespace TP1_IA.model
{
    class Effecteurs
    {
        private Environnement env = Environnement.Instance;
        private Agent ag = null;
        public void act(EnumIA.Action ea, Coordonnees c)
        {
            if (ag == null)
            {
                ag = Agent.Instance;
            }
            if (ea == EnumIA.Action.aspirer)
            {
                env.aspire(c);
            }
            if (ea == EnumIA.Action.recuperer)
            {
                env.ramasse(c);
            }
            else
            {
                ag.Coordonnees = c.move(ea);
                env.move();
            }
        }

        
        
    }
}
