using System.Collections.Generic;

namespace TP1_IA.model
{
    public abstract class Contenu
    {
        private List<Coordonnees> _bijoux;
        private List<Coordonnees> _poussieres;

        public List<Coordonnees> Bijoux
        {
            get { return _bijoux; }
            set { _bijoux = value; }
        }

        public List<Coordonnees> Poussieres
        {
            get { return _poussieres; }
            set { _poussieres = value; }
        }
    }
}
