using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

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
