using MAGUS.Enums;
using MAGUS.GameSystem.FightMode;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Percentages;
using MAGUS.Qualifications.Scientific;
using MAGUS.Qualifications.Specialities;
using MAGUS.Things.Weapons.RangedWeapons;

namespace MAGUS.Races;

public sealed class Nardael : Race, IUseRangedWeapons
{
    public override int Strength => -2;

    public override int Quickness => 1;

    public override int Dexterity => 1;

    public override int Stamina => -1;

    public override int Beauty => 1;

    public override Alignment? Alignment => Enums.Alignment.Life;

    public override QualificationList Qualifications =>
    [
        new ForestSurvival(QualificationLevel.Master),
        new Herbalism(QualificationLevel.Master),
        new WeaponUse(QualificationLevel.Master) { Weapon = new ElvenBow() }
    ];

    public override PercentQualificationList PercentQualifications =>
    [
        new Climbing(100),
        new Sneaking(95)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new KeenHearing(2),
        new KeenSight(2),
        new Infravision(30),
        new ResistanceToNecromancy(-5),
        new GoodArcher(20)
    ];

    public override string GenerateCharacterName()
    {
        var start = new[]
        {
            "Nar", "Thaer", "Syl", "Leth", "Vael", "Eryn"
        };

        var middle = new[]
        {
            "dae", "rae", "thel", "ryn", "lian", "vara"
        };

        var end = new[]
        {
            "el", "iel", "ael", "ion", "wyn"
        };

        return GenerateCharacterName(start, middle, end);
    }
}