using System.Collections.Generic;

namespace TP1_IA.model
{
    public class Belief
    {
        private List<Coordonnees> _jewels; //liste des pieces qui contiennent des bijoux (dans la connaissance de l'agent)
        private List<Coordonnees> _dust; //liste des pieces qui contiennent de la poussi�re (dans la connaissance de l'agent)
	
        public Belief() {
            _jewels = new List<Coordonnees>();
            _dust = new List<Coordonnees>(); 
        }

        public void updateBeliefs(List<Coordonnees> dust, List<Coordonnees> jewels) {
            _dust = dust;
            _jewels = jewels;
        }

        public List<Coordonnees> Jewels
        {
            get => _jewels;
            set => _jewels = value;
        }

        public List<Coordonnees> Dust
        {
            get => _dust;
            set => _dust = value;
        }
    }
}