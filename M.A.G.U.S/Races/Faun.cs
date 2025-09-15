using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/faun-h%C3%BCll%C5%91-r63/
/// </summary>
public class Faun : Race
{
    public override short Speed => 1;

    public override short Dexterity => 1;

    public override short Beauty => -2;

    public override short Health => 1;

    public override short WillPower => -1;

    public override short Astral => -2;

    public override short Stamina => 2;

    public override short Intelligence => 1;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new CanLearnOnlyPyarronPsi()
    ];
}
