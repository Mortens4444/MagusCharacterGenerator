using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class Khal : Race
{
    public override short Strength => 3;

    public override short Speed => 2;

    public override short Dexterity => 1;

    public override short Stamina => 2;

    public override short Health => 3;

    public override short WillPower => -1;

    public override short Astral => -5;

    public override QualificationList Qualifications =>
    [
        new Forestry(),
        new FishingAndHunting(),
        new WeatherForecast(),
        new Swimming(),
        new Running(QualificationLevel.Master),
        new Demonology()
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new BetterSeeing(2),
        new BetterHearing(2),
        new BetterSniffing(5)
    ];
}
