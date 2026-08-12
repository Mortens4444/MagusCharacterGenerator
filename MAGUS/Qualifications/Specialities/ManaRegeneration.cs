using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

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