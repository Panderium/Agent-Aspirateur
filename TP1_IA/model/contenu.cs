using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_IA.model
{
    abstract class Contenu
    {
        private List<Coordonnees> bijoux;
        private List<Coordonnees> poussieres;

        public List<Coordonnees> getBijoux()
        {
            return bijoux;
        }
        public void setBijoux(List<Coordonnees> bijoux)
        {
            this.bijoux = bijoux;
        }
        public List<Coordonnees> getPoussieres()
        {
            return poussieres;
        }
        public void setPoussiere(List<Coordonnees> poussieres)
        {
            this.poussieres = poussieres;
        }
    }
}
