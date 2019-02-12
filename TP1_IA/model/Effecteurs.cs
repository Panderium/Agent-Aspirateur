using System;

namespace TP1_IA.model
{
    class Effecteurs
    {

        public Coordonnees act(EnumIA.Action ea, Environnement e, Coordonnees c)
        {
            if (ea.Equals(EnumIA.Action.aspirer))
            {
                aspire(e, c);
                return c;
            }
            if (ea.Equals(EnumIA.Action.recuperer))
            {
                ramasse(e, c);
                return c;
            }
            else
            {
                return bouger(ea, c);
            }
        }

        private void aspire(Environnement e, Coordonnees c)
        {
            EnumIA.Chambre ec = e.getRoom(c);
            if (ec.Equals(EnumIA.Chambre.poussiere))
            {
                e.setRoom(c, EnumIA.Chambre.vide);
                // OK + gestion du score
            }
            if(ec.Equals(EnumIA.Chambre.poussiereEtBijou) || ec.Equals(EnumIA.Chambre.bijou))
            {
                e.setRoom(c, EnumIA.Chambre.vide);
                // KO + gestion du score
            }
        }
        private void ramasse(Environnement e, Coordonnees c)
        {
            EnumIA.Chambre ec = e.getRoom(c);
            if (ec.Equals(EnumIA.Chambre.poussiereEtBijou) || ec.Equals(EnumIA.Chambre.bijou))
            {
                e.setRoom(c, EnumIA.Chambre.vide);
                // OK
            }
            if (ec.Equals(EnumIA.Chambre.poussiere))
            {
                e.setRoom(c, EnumIA.Chambre.vide);
                // KO
            }
        }
        private Coordonnees bouger(EnumIA.Action ea, Coordonnees actualCoord)
        {
            switch (ea)
            {
                case EnumIA.Action.gauche:
                    return new Coordonnees(actualCoord.X - 1, actualCoord.Y);
                case EnumIA.Action.droite:
                    return new Coordonnees(actualCoord.X + 1, actualCoord.Y);
                case EnumIA.Action.bas:
                    return new Coordonnees(actualCoord.X, actualCoord.Y + 1);
                case EnumIA.Action.haut:
                    return new Coordonnees(actualCoord.X, actualCoord.Y - 1);
                default:
                    return actualCoord;
            } 
        }
    }
}
