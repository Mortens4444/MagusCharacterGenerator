using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public sealed class ShiKris : Aquirian
{
    public override int Strength => -1;

    public override int Stamina => 0;

    public override int Intelligence => 2;

    public override int Beauty => -2;

    public override int Astral => 1;

    public override Alignment? Alignment => Enums.Alignment.ChaosDeath;

    public override string Name => "Shi-kris";

    public override SpecialQualificationList SpecialQualifications
    {
        get
        {
            var result = base.SpecialQualifications;

            result.AddRange(
            [
                new AquirianPowerWords(),
                new ShapeShifter(),
                new MemoryAssimilation(15, 6),
                new Ultravision(30),
                new PoisonImmunity()
            ]);

            return result;
        }
    }

    public override string GenerateCharacterName()
    {
        var start = new[] { "Shi", "Kri", "Zhi", "Ssa", "Vri" };
        var middle = new[] { "i", "ri", "iss", "kr", "zh" };
        var end = new[] { "is", "ris", "ss", "kri", "zh" };

        return GenerateCharacterName(start, middle, end);
    }
}