using System.Collections.Generic;
using TP1_IA.model;

namespace TP1_IA.strategy
{
    public interface SearchStrategy
    {
        List<EnumIA.Action> execute(Node node, int depth);
    }
}