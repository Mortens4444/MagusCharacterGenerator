using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-az-%C3%BAt-szerint-r21/
/// </summary>
public class Kyr : Race
{
    public override short Strength => -2;

    public override short Beauty => 1;

    public override short Intelligence => -2;

    public override short WillPower => 1;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(50),
        new UndergroundMasters(2),
        new BetterSniffing(8)
    ];

    public override QualificationList Qualifications =>
    [
        new AntientLanguageKnowledge(AntientLanguage.Kyr),
        new Etiquette()
    ];
}
