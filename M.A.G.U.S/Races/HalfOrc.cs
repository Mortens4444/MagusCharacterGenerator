using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/f%C3%A9lork-goblin-r67/
/// </summary>
public class HalfOrc : Race
{
    public override sbyte Strength => 2;

    public override sbyte Stamina => 2;

    public override sbyte Health => 1;

    public override sbyte Beauty => -3;

    public override sbyte Intelligence => -2;

    public override sbyte Willpower => -1;

    public override sbyte Astral => -2;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(10),
        new UndergroundMasters(10),
        new KeenSmell(3)
    ];

    public override string Name => "Half-orc";
}
