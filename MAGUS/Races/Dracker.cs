using MAGUS.Enums;
using MAGUS.GameSystem.Languages;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Scientific;
using MAGUS.Qualifications.Specialities;

namespace MAGUS.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/dracker-r52/
/// </summary>
public class Dracker : Race
{
    public override int Strength => 1;

    public override int Stamina => 1;

    public override int Quickness => 1;

    public override int Health => -1;

    public override Alignment? Alignment => Enums.Alignment.Order;

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
