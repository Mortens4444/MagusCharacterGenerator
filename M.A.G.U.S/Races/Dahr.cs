using M.A.G.U.S.Qualifications;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/dahr-r51/
/// </summary>
public class Dahr : Race
{
    public override short Strength => -2;

    public override short Stamina => 1;

    public override short Speed => 2;

    public override short Health => -2;

    public override SpecialQualificationList SpecialQualifications =>
    [
        // Villámmágia
    ];
}
