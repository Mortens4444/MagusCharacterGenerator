using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public sealed class Zagnol : Race
{
    public override int Strength => 4;

    public override int Stamina => 3;

    public override int Beauty => -6;

    public override Alignment? Alignment => Enums.Alignment.ChaosDeath;

    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;

            result.AddRange(
            [
                new LanguageLore(3) { Language = Language.Orc },
                new LanguageLore(3) { Language = Language.Goblin },
                new LanguageLore(3) { Language = Language.Zagnol },
            ]);

            return result;
        }
    }

    public override SpecialQualificationList SpecialQualifications
    {
        get
        {
            var result = base.SpecialQualifications;

            result.AddRange(
            [
                new DamageBonus(3),
                new Ultravision(120)
            ]);

            return result;
        }
    }

    public override string Name => "Zagnol";

    public override string GenerateCharacterName()
    {
        var start = new[] { "Zag", "Gor", "Thok", "Rag", "Vak", "Dro" };
        var middle = new[] { "na", "ro", "ga", "ul", "za" };
        var end = new[] { "nol", "gor", "th", "mak", "zug" };

        return GenerateCharacterName(start, middle, end);
    }
}