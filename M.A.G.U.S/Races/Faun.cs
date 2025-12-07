using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/faun-h%C3%BCll%C5%91-r63/
/// </summary>
public class Faun : Race
{
    public override int Quickness => 1;

    public override int Dexterity => 1;

    public override int Beauty => -2;

    public override int Health => 1;

    public override int Willpower => -1;

    public override int Astral => -2;

    public override int Stamina => 2;

    public override int Intelligence => 1;

    public override Alignment? Alignment => Enums.Alignment.ChaosLife;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new CanOnlyLearnPyarronPsi()
    ];
}
