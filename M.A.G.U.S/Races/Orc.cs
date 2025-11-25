using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;
using Mtf.Extensions.Services;
using System.Text;

namespace M.A.G.U.S.Races;

public class Orc : Race
{
    public override sbyte Strength => 3;

    public override sbyte Stamina => 3;

    public override sbyte Health => 2;

    public override sbyte Beauty => -3;

    public override sbyte Intelligence => -3;

    public override sbyte Willpower => 2;

    public override sbyte Astral => -4;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(50),
        new UndergroundMasters(2),
        new KeenSmell(8)
    ];

    public override string GenerateCharacterName()
    {
        var consonants = new[] { 'k', 'g', 'r', 'h', 's' };
        var vowels = new[] { 'a', 'o', 'u' };
        return GenerateCharacterName(consonants, vowels);
    }
}
