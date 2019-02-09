using System.Collections.Generic;
using System.Linq;

namespace TP1_IA.model
{
    // liste des mouvements et des actions à effectuer pour atteindre le prochain but
    class Intentions
    {
        private Stack<EnumIA.Action> _intentions = new Stack<EnumIA.Action>();

        public void empile(EnumIA.Action ea)
        {
            _intentions.Push(ea);
        }
        public EnumIA.Action depile()
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
