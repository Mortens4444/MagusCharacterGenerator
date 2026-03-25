using M.A.G.U.S.Enums;

namespace M.A.G.U.S.Bestiary.Elementals;

public abstract class ElementalLord : Elemental
{
    protected ElementalLord()
    {
        Occurrence = Occurrence.Summoned;
        Alignment = Alignment.Order;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        AttacksPerRound = 1;

        MinIntelligence = null;
        MaxIntelligence = null;
        Intelligence = Enums.Intelligence.Outstanding;
    }
}
