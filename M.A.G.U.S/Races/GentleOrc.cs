using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class GentleOrc : Race
{
    public override short Strength => 2;

    public override short Stamina => 1;

    public override short Health => 2;

    public override short Beauty => -3;

    public override short Intelligence => -1;

    public override short Astral => -3;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(45),
        new UndergroundMasters(12),
        new BetterSniffing(5)
    ];

    public override string Name => "Gentle orc";
}
