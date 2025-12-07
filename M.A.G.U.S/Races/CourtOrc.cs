using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class CourtOrc : Race
{
    public override int Strength => 2;

    public override int Stamina => 1;

    public override int Health => 2;

    public override int Beauty => -3;

    public override int Intelligence => -1;

    public override int Astral => -3;

    public override Alignment? Alignment => Enums.Alignment.OrderDeath;

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
