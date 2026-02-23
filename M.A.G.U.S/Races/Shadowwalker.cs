using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class Shadowwalker : Race
{
    public override int Strength => -1;

    public override int Quickness => 1;

    public override int Dexterity => 2;

    public override int Beauty => -2;

    public override int Intelligence => 2;

    public override int Willpower => 2;

    public override Alignment? Alignment => Enums.Alignment.ChaosDeath;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Ultravision(8),
        new ExtraPsiPointOnLevelUp(1),
        new ExtraManaPointOnLevelUp(1),
        //new MagicResistanceBonus(3),
        new PoisonImmunity()
    ];

    public override QualificationList Qualifications =>
    [
        new AncientTongueLore(AntientLanguage.Kyr, QualificationLevel.Master)
    ];

    public override string GenerateCharacterName()
    {
        var start = new[]
        {
            "Xaer", "Vael", "Zhyr", "Khae", "Rhyss", "Mael"
        };

        var middle = new[]
        {
            "ith", "aen", "or", "yrr", "aes", "uar"
        };

        var end = new[]
        {
            "is", "oth", "ael", "yr", "eth", "ion"
        };

        return GenerateCharacterName(start, middle, end);
    }
}
