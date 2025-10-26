using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/feh%C3%A9r-ork-r65/
/// </summary>
public class WhiteOrc : Race
{
    public override sbyte Strength => 3;

    public override sbyte Stamina => 1;

    public override sbyte Dexterity => 1;

    public override sbyte Speed => 1;

    public override sbyte Health => 2;

    public override sbyte Beauty => -2;

    public override sbyte Willpower => -2;

    public override sbyte Astral => -3;

    public override List<PercentQualification> PercentQualifications =>
    [
        new TrapDetection(40)
    ];

    public override QualificationList Qualifications =>
    [
        new TrackingConcealment()
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(100),
        new UndergroundMasters(1),
        new KeenSmell(12),
        new KeenHearing(2.5),
        new DragonSkin()
    ];

    public override string Name => "White orc";
}
