using TP1_IA.model;

namespace TP1_IA.strategy
{
    public interface SearchStrategy
    {
        EnumIA.Action execute(Node node, int depth);
    }
}