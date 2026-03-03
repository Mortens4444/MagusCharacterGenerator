using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public sealed class ManaRegeneration(int maxMana, int regenerationPerRound) : SpecialQualification
{
    public int MaxMana { get; } = maxMana;

    public int RegenerationPerRound { get; } = regenerationPerRound;

    public override string Name => "Mana Regeneration";

    public override string ToString()
    {
        return $" ({RegenerationPerRound})";
    }
}