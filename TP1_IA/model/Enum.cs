using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_IA.model
{
    public class Enum
    {
        public enum Action
        {
            haut, bas, droite, gauche, aspirer, recuperer,
        };
        public enum Chambre
        {
            vide, poussiere, bijou, poussiereEtBijou,
        };
    }
}
