using MAGUS.Enums;
using MAGUS.Qualifications;

namespace MAGUS.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/dahr-r51/
/// </summary>
public class Dahr : Race
{
    public override int Strength => -2;

    public override int Stamina => 1;

    public override int Quickness => 2;

    public override int Health => -2;

    public override Alignment? Alignment => Enums.Alignment.OrderLife;

    public override SpecialQualificationList SpecialQualifications =>
    [
        // Villámmágia
    ];
}
