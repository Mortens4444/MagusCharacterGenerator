using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class Amund : Race
{
    public override int Strength => 1;

    public override int Stamina => 1;

    public override int Beauty => 3;

    public override int Astral => -1;

    public override Alignment? Alignment => Enums.Alignment.ChaosDeath;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new CantLearnPsi(),
        new ExtraMagicResistanceOnLevelUp(4),
        new MagicalResistanceRegeneration()
    ];

    public override string GenerateCharacterName()
    {
        var start = new[]
        {
            "Kar", "Tah", "Bar", "Han", "Zar", "Dar", "Har", "Tash"
        };

        var middle = new[]
        {
            "ak", "ar", "ta", "ra", "ad", "ha"
        };

        var end = new[]
        {
            "an", "ar", "ash", "ad", "han", "tar"
        };

        return GenerateCharacterName(start, middle, end);
    }
}
