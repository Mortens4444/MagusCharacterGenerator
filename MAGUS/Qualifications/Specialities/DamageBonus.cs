using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class DamageBonus : SpecialQualification
{
    public int Bonus { get; init; }

    public override string Name => "Damage Bonus";

    public DamageBonus(int bonus)
    {
        Bonus = bonus;
    }

    public override string ToString()
    {
        return $" ({Bonus})";
    }
}
