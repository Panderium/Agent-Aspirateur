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
        private Stack<Enum.EnumAction> _intentions = new Stack<Enum.EnumAction>();

        public void empile(Enum.EnumAction ea)
        {
            _intentions.Push(ea);
        }
        public Enum.EnumAction depile()
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
