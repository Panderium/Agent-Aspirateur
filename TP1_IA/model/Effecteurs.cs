using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_IA.model
{
    class Effecteurs
    {

        public void act(Enum.Action ea, Environnement e, Coordonnees c)
        {
            if (ea.Equals(Enum.Action.aspirer))
            {
                aspire(e, c);
            }
            if (ea.Equals(Enum.Action.recuperer))
            {
                ramasse(e, c);
            }
            else
            {
                bouger(ea, c);
            }
        }

        private void aspire(Environnement e, Coordonnees c)
        {
            Enum.Chambre ec = e.getRoom(c);
            if (ec.Equals(Enum.Chambre.poussiere))
            {
                e.setRoom(c, Enum.Chambre.vide);
                // OK + gestion du score
            }
            if(ec.Equals(Enum.Chambre.poussiereEtBijou) || ec.Equals(Enum.Chambre.bijou))
            {
                e.setRoom(c, Enum.Chambre.vide);
                // KO + gestion du score
            }
            else
            {
            }     
        }
        private void ramasse(Environnement e, Coordonnees c)
        {
            Enum.Chambre ec = e.getRoom(c);
            if (ec.Equals(Enum.Chambre.poussiereEtBijou) || ec.Equals(Enum.Chambre.bijou))
            {
                e.setRoom(c, Enum.Chambre.vide);
                // OK
            }
            if (ec.Equals(Enum.Chambre.poussiere))
            {
                e.setRoom(c, Enum.Chambre.vide);
                // KO
            }
            else
            {
                //RIEN
            }

        }
        private Coordonnees bouger(Enum.Action ea, Coordonnees actualCoord)
        {
            switch (ea)
            {
                case Enum.Action.gauche:
                    return new Coordonnees(actualCoord.X - 1, actualCoord.Y);
                case Enum.Action.droite:
                    return new Coordonnees(actualCoord.X + 1, actualCoord.Y);
                case Enum.Action.bas:
                    return new Coordonnees(actualCoord.X, actualCoord.Y + 1);
                case Enum.Action.haut:
                    return new Coordonnees(actualCoord.X, actualCoord.Y - 1);
                default:
                    return actualCoord;
            } 
        }
    }
}
