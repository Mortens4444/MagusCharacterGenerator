using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class Orc : Race
{
    public override int Strength => 3;

    public override int Stamina => 3;

    public override int Health => 2;

    public override int Beauty => -3;

    public override int Intelligence => -3;

    public override int Willpower => 2;

    public override int Astral => -4;

    public override Alignment? Alignment => Enums.Alignment.ChaosDeath;

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
