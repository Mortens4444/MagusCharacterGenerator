using MAGUS.Enums;
using MAGUS.GameSystem.Languages;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Scientific;
using MAGUS.Qualifications.Specialities;

namespace MAGUS.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-az-%C3%BAt-szerint-r21/
/// </summary>
public class Kyr : Race
{
    public override int Strength => -2;

    public override int Beauty => 1;

    public override int Intelligence => -2;

    public override int Willpower => 1;

    public override Alignment? Alignment => Enums.Alignment.Order;

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
