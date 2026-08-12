using MAGUS.Enums;
using MAGUS.GameSystem.Languages;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Scientific;

namespace MAGUS.Classes.Believer.GodsOfPyarron;

public class KradPaladin : Paladin
{
    public KradPaladin() : base() { }

    public KradPaladin(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(
            [
                new LanguageLore(Language.Erven, 3),
                new LanguageLore(Language.Toronian, 3),
                new LanguageLore(Language.Doranian, 3),
                new LanguageLore(Language.Godoran, 3),
                new Herbalism(),
                new LegendLore(),
                new HistoryLore(),
                new ForestSurvival(),
                new Cartography(),
                new Swimming()
            ]);
            return BuildQualifications(result);
        }
    }

    public override QualificationList FutureQualifications
    {
        get
        {
            var result = base.FutureQualifications;
            result.AddRange(
            [
                new LegendLore(QualificationLevel.Master, 5),
                new HistoryLore(QualificationLevel.Master, 5),
            ]);
            return BuildQualifications(result);
        }
    }

    public override string Name => "Paladin of Krad";

    public override Deity Deity { get; set; } = Deity.Krad;
}
