using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public sealed class CwyvehKah : Race
{
    public override int Strength => 4;

    public override int Quickness => 2;

    public override int Dexterity => 2;

    public override int Stamina => 2;

    public override int Intelligence => 1;

    public override int Beauty => -4;

    public override int Astral => 1;

    public override Alignment? Alignment => Enums.Alignment.Chaos;

    public override SpecialQualificationList SpecialQualifications
    {
        get
        {
            var result = base.SpecialQualifications;
            result.AddRange(
            [
                new Ultravision(100),
                new ExternalExoskeleton(),
                new GoodArcher(40)
                //new NaturalWeaponClaws(2, 6),
                //new PoisonResistance(50),
                //new EnhancedReflexes(),
            ]);
            return result;
        }
    }

    public override string Name => "Cwyveh-Kah";

    public override string GenerateCharacterName()
    {
        var start = new[] { "Cwy", "Kah", "Vreh", "Zaq", "Thy", "Qor" };
        var middle = new[] { "e", "ae", "y", "veh", "ra" };
        var end = new[] { "kah", "veth", "zhar", "qeth", "rax" };

        return GenerateCharacterName(start, middle, end);
    }
}