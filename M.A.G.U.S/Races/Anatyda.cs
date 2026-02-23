using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class Anatyda : Race
{
    public override int Strength => -1;

    public override int Stamina => -1;

    public override int Beauty => 3;

    public override int Astral => 3;

    public override Alignment? Alignment => Enums.Alignment.Chaos;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Ultravision(20),
        new ShapeShifter(),
        new CharmAura(30),
        new AstralInfluence()
    ];

    public override string GenerateCharacterName()
    {
        var start = new[]
        {
            "Ela", "Mira", "Lya", "Vira", "Tara", "Sela", "Nira", "Alya"
        };

        var middle = new[]
        {
            "ra", "la", "na", "mi", "vi", "el", "is", "ar"
        };

        var end = new[]
        {
            "na", "ra", "lia", "sha", "elle", "ina", "ara"
        };

        return GenerateCharacterName(start, middle, end);
    }
}
