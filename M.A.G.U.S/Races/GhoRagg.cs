using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public sealed class GhoRagg : Aquirian
{
    public override int Strength => 2;

    public override int Stamina => 2;

    public override int Dexterity => 0;

    public override int Intelligence => -1;

    public override int Beauty => -3;

    public override int Astral => 0;

    public override Alignment? Alignment => Enums.Alignment.ChaosDeath;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(120),
        new AquirianPowerWords(),
        new CantLearnPsi(),
    ];

    public override string Name => "Gho-Ragg";

    public override string GenerateCharacterName()
    {
        var start = new[]
        {
            "Ghor", "Ragg", "Khar", "Zor", "Drak", "Varg", "Thar"
        };

        var middle = new[]
        {
            "ra", "go", "ga", "zor", "vak", "dar"
        };

        var end = new[]
        {
            "g", "gg", "rk", "th", "n"
        };

        return GenerateCharacterName(start, middle, end);
    }
}