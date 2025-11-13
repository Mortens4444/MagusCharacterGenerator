using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/f%C3%A9lork-goblin-r67/
/// </summary>
public class Goblin : Race
{
    public override sbyte Strength => -2;

    public override sbyte Dexterity => 3;

    public override sbyte Quickness => 3;

    public override sbyte Beauty => -4;

    public override sbyte Willpower => -1;

    public override sbyte Astral => -2;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(10),
        new UndergroundMasters(5)
    ];
}
