using MAGUS.Enums;
using MAGUS.GameSystem.Languages;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Scientific;

namespace MAGUS.Classes.Believer.Domvik;

public class DomvikPaladin : Paladin
{
    public DomvikPaladin() : base() { }

    public DomvikPaladin(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(
            [
                new AncientTongueLore(AntientLanguage.LinguaDomini),
                new Healing(),
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
                new AncientTongueLore(AntientLanguage.LinguaDomini, QualificationLevel.Master, 4),
            ]);
            return BuildQualifications(result);
        }
    }

    public override string Name => "Paladin of Domvik";

    public override Deity Deity { get; set; } = Deity.Domvik;
}
