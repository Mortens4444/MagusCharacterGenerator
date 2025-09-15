using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/faun-h%C3%BCll%C5%91-r63/
/// </summary>
public class Reptile : Race
{
    public override short Strength => 1;

    public override short Speed => 2;

    public override short Dexterity => 2;

    public override short Stamina => -1;

    public override short Beauty => -3;

    public override short WillPower => -1;

    public override short Intelligence => -1;

    public override short Astral => -2;

    public override List<PercentQualification> PercentQualifications =>
    [
        new Climbing(40),
        new Jumping(30),
        new Falling(20)
    ];

    public override QualificationList Qualifications =>
    [
        new Running(),
		//new Akkrobatika(),
		//new Célzás(),
	];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(50),
        new BetterSniffing(2)
		//Savas nyál naponta 2x (Té: +20, Sebzés: k6)
		// InvisibleFrom3rdLevelIfSorcerer
		// AlakváltásFrom7thLevelIfSorcerer
	];
}
