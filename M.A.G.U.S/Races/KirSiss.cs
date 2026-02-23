using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public sealed class KirSiss : Aquirian
{
    public override int Strength => -2;

    public override int Stamina => -2;

    public override int Dexterity => 0;

    public override int Intelligence => 2;

    public override int Beauty => -6;

    public override int Astral => 2;

    public override Alignment? Alignment => Enums.Alignment.ChaosDeath;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Blind(),
        new AstralSight(30),
        new MentalSight(30),
        new MadnessSong(55, 5)
    ];

    public override string Name => "Kir-siss";

    public override string GenerateCharacterName()
    {
        var start = new[]
        {
            "Siss", "Kir", "Iss", "Zhir", "Ssra", "Thiss"
        };

        var middle = new[]
        {
            "i", "si", "ri", "zi", "ss"
        };

        var end = new[]
        {
            "ss", "s", "iss", "zir", "sh"
        };

        return GenerateCharacterName(start, middle, end);
    }
}