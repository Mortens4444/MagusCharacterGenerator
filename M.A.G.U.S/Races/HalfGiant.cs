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
    public override sbyte Strength => 3;

    public override sbyte Stamina => 2;

    public override sbyte Health => 3;

    public override sbyte Beauty => -1;

    public override sbyte Intelligence => -1;

    public override sbyte Quickness => -1;

    public override sbyte Astral => -3;

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
