using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public sealed class ManaReservoir(int maxMana, int regenPerRound) : SpecialQualification
{
    public int MaxMana { get; } = maxMana;

    public int RegenPerRound { get; } = regenPerRound;

    public override string Name => "Mana Reservoir";
}