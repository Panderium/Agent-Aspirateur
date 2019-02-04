using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_IA.model
{
    abstract class Contenu
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
