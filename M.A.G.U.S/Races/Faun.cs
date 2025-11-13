using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/faun-h%C3%BCll%C5%91-r63/
/// </summary>
public class Faun : Race
{
    public override sbyte Quickness => 1;

    public override sbyte Dexterity => 1;

    public override sbyte Beauty => -2;

    public override sbyte Health => 1;

    public override sbyte Willpower => -1;

    public override sbyte Astral => -2;

    public override sbyte Stamina => 2;

    public override sbyte Intelligence => 1;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new CanOnlyLearnPyarronPsi()
    ];
}
