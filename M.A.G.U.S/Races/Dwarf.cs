using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class Dwarf : Race
{
    public override sbyte Strength => 1;

    public override sbyte Stamina => 1;

    public override sbyte Health => 1;

    public override sbyte Beauty => -2;

    public override sbyte Intelligence => -1;

    public override sbyte Astral => -1;

    public override List<PercentQualification> PercentQualifications =>
    [
        new TrapDetection(35),
        new SecretDoorSearch(30)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(30),
        new PerfectSenseOfTime(),
        new UndergroundMasters(2),
        new GoodBuildingAgeGuess()
    ];
}
