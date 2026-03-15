using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public sealed class Mantisfolk : Race
{
    public override int Strength => 4;

    public override int Stamina => 5;

    public override int Beauty => -6;

    public override int Astral => 2;

    public override Alignment? Alignment => Enums.Alignment.Order;

    public override SpecialQualificationList SpecialQualifications
    {
        get
        {
            var result = base.SpecialQualifications;

            result.AddRange(
            [
                new Ultravision(180),
                new CompoundEyes360Vision(),
                new FourArmedCombat(),
                new MantisJump(4, 2), // 4m előre, 2m fel
                new InsectoidGrapple(),
                new ChitinExoskeleton(3),
                new AdvancedAstralResistance(),
                new AdvancedMentalResistance()
            ]);

            return result;
        }
    }

    public override string Name => "Mantisfolk (Aun)";

    public override string GenerateCharacterName()
    {
        var start = new[] { "Za", "Kha", "Tza", "Rha", "Sza", "Qua" };
        var middle = new[] { "ra", "zi", "ka", "tha", "xil" };
        var end = new[] { "un", "eth", "qar", "zel", "ith" };

        return GenerateCharacterName(start, middle, end);
    }
}