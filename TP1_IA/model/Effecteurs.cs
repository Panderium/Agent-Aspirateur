using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_IA.model
{
    class Effecteurs
    {

        public void act(Enum.EnumAction ea, Environnement e, Coordonnees c)
        {
            if (ea.Equals(Enum.EnumAction.aspirer))
            {
                aspire(e, c);
            }
            if (ea.Equals(Enum.EnumAction.recuperer))
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
            Enum.EnumChambre ec = e.getRoom(c);
            if (ec.Equals(Enum.EnumChambre.poussiere))
            {
                e.setRoom(c, Enum.EnumChambre.vide);
                // OK + gestion du score
            }
            if(ec.Equals(Enum.EnumChambre.poussiereEtBijou) || ec.Equals(Enum.EnumChambre.bijou))
            {
                e.setRoom(c, Enum.EnumChambre.vide);
                // KO + gestion du score
            }
            else
            {
            }     
        }
        private void ramasse(Environnement e, Coordonnees c)
        {
            Enum.EnumChambre ec = e.getRoom(c);
            if (ec.Equals(Enum.EnumChambre.poussiereEtBijou) || ec.Equals(Enum.EnumChambre.bijou))
            {
                e.setRoom(c, Enum.EnumChambre.vide);
                // OK
            }
            if (ec.Equals(Enum.EnumChambre.poussiere))
            {
                e.setRoom(c, Enum.EnumChambre.vide);
                // KO
            }
            else
            {
                //RIEN
            }

        }
        private Coordonnees bouger(Enum.EnumAction ea, Coordonnees actualCoord)
        {
            switch (ea)
            {
                case Enum.EnumAction.gauche:
                    return new Coordonnees(actualCoord.X - 1, actualCoord.Y);
                case Enum.EnumAction.droite:
                    return new Coordonnees(actualCoord.X + 1, actualCoord.Y);
                case Enum.EnumAction.bas:
                    return new Coordonnees(actualCoord.X, actualCoord.Y + 1);
                case Enum.EnumAction.haut:
                    return new Coordonnees(actualCoord.X, actualCoord.Y - 1);
                default:
                    return actualCoord;
            } 
        }
    }
}
