using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class Khal : Race
{
    public override sbyte Strength => 3;

    public override sbyte Speed => 2;

    public override sbyte Dexterity => 1;

    public override sbyte Stamina => 2;

    public override sbyte Health => 3;

    public override sbyte Willpower => -1;

    public override sbyte Astral => -5;

    public override QualificationList Qualifications =>
    [
        new ForestSurvival(),
        new HuntingAndFishing(),
        new WeatherDivination(),
        new Swimming(),
        new Running(QualificationLevel.Master),
        new Demonology()
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new KeenSight(2),
        new KeenHearing(2),
        new KeenSmell(5)
    ];
}
