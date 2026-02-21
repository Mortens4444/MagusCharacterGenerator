using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class MutantOrc : Race
{
    public override int Strength => 4;

    public override int Stamina => 4;

    public override int Health => 3;

    public override int Beauty => -5;

    public override int Intelligence => -2;

    public override int Willpower => 3;

    public override int Astral => -5;

    public override Alignment? Alignment => Enums.Alignment.ChaosDeath;

    public override string Name => "Mutant orc";

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Flight(),
        new Infravision(30),
        new NaturalArmor(3),
        new PoisonImmunity(),
        new UndergroundMasters(2),
        new KeenSmell(10)
    ];

    public override string GenerateCharacterName()
    {
        var consonants = new[] { 'k', 'g', 'r', 'h', 's', 'z', 'v' };
        var vowels = new[] { 'a', 'o', 'u' };
        return GenerateCharacterName(consonants, vowels);
    }
}
