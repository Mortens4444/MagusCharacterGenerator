using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B6nyve-r62/
/// </summary>
public class Draquon : Race
{
    public override int Strength => 2;

    public override int Stamina => 1;

    public override int Health => 1;

    public override int Beauty => -1;

    public override int Astral => -2;

    public override List<PercentQualification> PercentQualifications =>
    [
        new Climbing((DiceThrow._1D6() + 4) * 10),
        new Falling((DiceThrow._1D3() + 3) * 10),
        new Hiding((DiceThrow._1D5() + 2) * 10),
    ];

    public override QualificationList Qualifications =>
    [
        new Demonology(),
        new WeaponBreaking(QualificationLevel.Master),
    ];

    public override SpecialQualificationList SpecialQualifications =>
        [
            new Flight(),
        new KeenSight(1.5),
        new Ultravision(50),
        new CantLearnPsi(),
        new ExtraMagicResistanceOnLevelUp(5),
        new Telepathy(),
		//new LockPicking(-30)
		//new PickPocketing(-30)
		new NotTolerateStrongLight(12, -20)
    ];
}
