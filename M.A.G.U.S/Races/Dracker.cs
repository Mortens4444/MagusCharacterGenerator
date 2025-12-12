using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Languages;
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
    public override int Strength => 1;

    public override int Stamina => 1;

    public override int Quickness => 1;

    public override int Health => -1;

    public override Alignment? Alignment => Enums.Alignment.ChaosDeath;

    public override QualificationList Qualifications =>
    [
        new AnimalTraining(),
        new ForestSurvival(),
        new LanguageLore(Language.Pyarronian, 4),
        new LanguageLore(Language.Shadonian, 3),
        new LanguageLore(Language.Toronian, 3),
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new KeenSight(1.5),
		// Mágiaellenállás * 2,
		new Ultravision(25),
        new ResistanceToWaterMagic(-6)
    ];
}
