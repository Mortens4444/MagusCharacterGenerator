using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public sealed class SaQuad : Aquirian
{
    public override int Strength => 2;

    public override int Stamina => 3;

    public override int Intelligence => 3;

    public override int Beauty => -5;

    public override int Astral => 3;

    public override Alignment? Alignment => Enums.Alignment.ChaosLife;

    public override SpecialQualificationList SpecialQualifications
    {
        get
        {
            var result = base.SpecialQualifications;
            result.AddRange(
            [
                new AquirianPowerWords(),
                new Ultravision(120),
                new ExternalExoskeleton(),
                new SaQuadPhysicalResistance(),
                new PriestSpellcasting(10, 18),
                new WarlockCurseCasting(),
                new ChaosLifeCorruption()
            ]);
            return result;
        }
    }

    public override string Name => "Sa-quad";

    public override string GenerateCharacterName()
    {
        var start = new[] { "Sa", "Qua", "Zha", "Thra", "Ka", "Va" };
        var middle = new[] { "o", "a", "u", "ra", "qa" };
        var end = new[] { "quad", "th", "xar", "metha", "zor" };

        return GenerateCharacterName(start, middle, end);
    }
}