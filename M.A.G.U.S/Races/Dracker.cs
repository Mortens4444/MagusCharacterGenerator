using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/dracker-r52/
/// </summary>
public class Dracker : Race
{
    public override short Strength => 1;

    public override short Stamina => 1;

    public override short Speed => 1;

    public override short Health => -1;

    public override QualificationList Qualifications =>
    [
        new AnimalTraining(),
        new Forestry(),
        new LanguageLore(4),
        new LanguageLore(3),
        new LanguageLore(3),
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new KeenSight(1.5),
		// Mágiaellenállás * 2,
		new Ultravision(25),
        new ResistanceToWaterMagic(-6)
    ];
}
