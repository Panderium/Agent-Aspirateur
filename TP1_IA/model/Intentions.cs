using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_IA.model
{
    // liste des mouvements et des actions à effectuer pour atteindre le prochain but
    class Intentions
    {
        private Stack<Enum.Action> _intentions = new Stack<Enum.Action>();

        public void empile(Enum.Action ea)
        {
            _intentions.Push(ea);
        }
        public Enum.Action depile()
        {
            return _intentions.Pop();
        }
        public void vider()
        {
            _intentions.Clear();
        }
        public int size()
        {
            return _intentions.Count();
        }
    }
}
