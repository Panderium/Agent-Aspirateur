using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP1_IA.model
{
    // liste des mouvements et des actions à effectuer pour atteindre le prochain but
    class Intentions
    {
        private Queue<EnumIA.Action> _intentions = new Queue<EnumIA.Action>();

        public void empile(EnumIA.Action ea)
        {
            _intentions.Enqueue(ea);
        }
        public EnumIA.Action depile()
        {
            return _intentions.Dequeue();
        }
        public void vider()
        {
            _intentions.Clear();
        }
        public int size()
        {
            return _intentions.Count;
        }

        public override String ToString()
        {    StringBuilder s = new StringBuilder();
            foreach (EnumIA.Action a in _intentions.ToArray())
            {
                s.Append(a);
            }

            return s.ToString();

        }
    }
}
