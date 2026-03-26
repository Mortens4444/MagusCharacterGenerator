using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public sealed class Eleidin : Race
{
    public override int Strength => -2;

    public override int Stamina => 1;

    public override int Intelligence => 5;

    public override int Beauty => -4;

    public override int Astral => 2;

    public override Alignment? Alignment => Enums.Alignment.Order;

    public override SpecialQualificationList SpecialQualifications
    {
        get
        {
            var result = base.SpecialQualifications;
            result.AddRange(
            [
                new BetterResistanceToFire(10),
                new BetterResistanceToCold(10),
                new FireMagic(),
                new LavaMagic(),
                new SurvivalWithoutFood(7),
                new SurvivalWithoutSleep(3)
            ]);
            return result;
        }
    }

    public override string Name => "Eleidin";

    public override string GenerateCharacterName()
    {
        var start = new[] { "El", "Ir", "Tha", "Zar", "Vel", "Kor" };
        var middle = new[] { "ei", "a", "u", "io", "ae" };
        var end = new[] { "din", "th", "mar", "ion", "zar" };

        return GenerateCharacterName(start, middle, end);
    }
}