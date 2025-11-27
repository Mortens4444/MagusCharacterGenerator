using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class CourtOrc : Race
{
    public override sbyte Strength => 2;

    public override sbyte Stamina => 1;

    public override sbyte Health => 2;

    public override sbyte Beauty => -3;

    public override sbyte Intelligence => -1;

    public override sbyte Astral => -3;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(45),
        new UndergroundMasters(12),
        new KeenSmell(5)
    ];

    public override string GenerateCharacterName()
    {
        var consonants = new[] { 'k', 'g', 'r', 'h', 's' };
        var vowels = new[] { 'a', 'o', 'u' };
        return GenerateCharacterName(consonants, vowels);
    }

    public override string Name => "Court orc";
}
