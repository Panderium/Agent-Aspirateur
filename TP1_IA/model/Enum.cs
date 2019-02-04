using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_IA.model
{
    class Enum
    {
        public enum EnumAction
        {
            haut, bas, droite, gauche, aspirer, recuperer, aspirerEtRecuperer,
        };
        public enum EnumChambre
        {
            vide, poussiere, bijou, poussiereEtBijou,
        };
    }
}
