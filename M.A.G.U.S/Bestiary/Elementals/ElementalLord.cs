using M.A.G.U.S.Enums;

namespace M.A.G.U.S.Bestiary.Elementals;

public abstract class ElementalLord : Elemental
{
    protected ElementalLord()
    {
        Occurrence = Occurrence.Summoned;
        Alignment = Alignment.Order;

        AttacksPerRound = 1;

        MinIntelligence = null;
        MaxIntelligence = null;
        Intelligence = Enums.Intelligence.Outstanding;
    }
}
