using MAGUS.Enums;

namespace MAGUS.Bestiary.Elementals;

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
