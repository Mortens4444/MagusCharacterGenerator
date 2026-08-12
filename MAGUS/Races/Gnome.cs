using MAGUS.Enums;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Scientific;
using MAGUS.Qualifications.Specialities;

namespace MAGUS.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B3dexe-r61/
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B6nyve-r62/
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/gn%C3%B3m-r69/
/// </summary>
public class Gnome : Race
{
    public override int Strength => -1;

    public override int Dexterity => 1;

    public override int Intelligence => 1;

    public override Alignment? Alignment => Enums.Alignment.Order;

    public override QualificationList Qualifications =>
    [
        new Cartography(),
        new Craft(Profession.Goldsmith)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(25)
    ];

    public override string GenerateCharacterName()
    {
        var start = new[]
        {
            "Pip", "Fen", "Tib", "Vok", "Kli", "Ned", "Fli", "Tek"
        };

        var middle = new[]
        {
            "li", "ti", "ke", "fi", "ne", "re"
        };

        var end = new[]
        {
            "in", "ek", "en", "ik", "et", "inor"
        };

        return GenerateCharacterName(start, middle, end);
    }
}
