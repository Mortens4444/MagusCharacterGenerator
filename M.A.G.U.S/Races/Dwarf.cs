using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class Dwarf : Race
{
    public override short Strength => 1;

    public override short Stamina => 1;

    public override short Health => 1;

    public override short Beauty => -2;

    public override short Intelligence => -1;

    public override short Astral => -1;

    public override List<PercentQualification> PercentQualifications =>
    [
        new TrapDetect(35),
        new SecretDoorSearching(30)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(30),
        new PerfectTimeDetection(),
        new UndergroundMasters(2),
        new GoodBuildingAgeGuess()
    ];
}
