using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B6nyve-r62/
/// </summary>
public abstract class HalfGiant : Race
{
    public override short Strength => 3;

    public override short Stamina => 2;

    public override short Health => 3;

    public override short Beauty => -1;

    public override short Intelligence => -1;

    public override short Speed => -1;

    public override short Astral => -3;

    public override QualificationList Qualifications =>
    [
        new Running(),
        new HuntingAndFishing(QualificationLevel.Master)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new DoubledPainToleranceBase(),
        new AdditionalLifePoints(3),
    ];

    public override string Name => "Half-giant";
}
