using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class Orc : Race
{
    public override short Strength => 3;

    public override short Stamina => 3;

    public override short Health => 2;

    public override short Beauty => -3;

    public override short Intelligence => -3;

    public override short WillPower => 2;

    public override short Astral => -4;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(50),
        new UndergroundMasters(2),
        new BetterSniffing(8)
    ];
}
