using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-az-%C3%BAt-szerint-r21/
/// </summary>
public class Kyr : Race
{
    public override int Strength => -2;

    public override int Beauty => 1;

    public override int Intelligence => -2;

    public override int Willpower => 1;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Ultravision(5),
        new ExtraPsiPointOnLevelUp(1),
        new ExtraManaPointOnLevelUp(1)
    ];

    public override QualificationList Qualifications =>
    [
        new AncientTongueLore(AntientLanguage.Kyr, QualificationLevel.Master),
        new Etiquette(QualificationLevel.Master)
    ];

    public override string GenerateCharacterName()
    {
        var start = new[]
        {
            "Ael", "Lir", "Ser", "Nae", "Rhe", "Myr", "Aen", "Hir"
        };

        var middle = new[]
        {
            "ia", "ae", "el", "an", "ir", "ys", "ari"
        };

        var end = new[]
        {
            "el", "ion", "ir", "ar", "iel", "oras", "yss"
        };

        return GenerateCharacterName(start, middle, end);
    }
}
