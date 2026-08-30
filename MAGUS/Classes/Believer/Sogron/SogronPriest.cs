using MAGUS.Enums;
using MAGUS.GameSystem.Languages;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Scientific;

namespace MAGUS.Classes.Believer.Sogron;

/// <summary>
/// The priest a Tűzvarázsló becomes upon choosing Sogron Útja at level 5 (Második Törvénykönyv,
/// "A tűzvarázslók három Útja", p.34-36) - see Character.ApplyFireMageSpecialization, which
/// switches Character.BaseClass to an instance of this class while keeping the character's
/// already-learned Fire Mage qualifications and adding Priest's base ones on top.
/// </summary>
public class SogronPriest : Priest
{
    public SogronPriest() : base() { }

    public SogronPriest(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    public override QualificationList FutureQualifications
    {
        get
        {
            var result = base.FutureQualifications;
            result.AddRange(
            [
                new ReligionLore(QualificationLevel.Master, 5),
                new HistoryLore(QualificationLevel.Master, 5),
                new SingingAndMakingMusic(level: 5),
                new AncientTongueLore(AntientLanguage.Kyr, level: 5),
                new LegendLore(level: 5),
                new HumanInsight(level: 5),
                new LegendLore(QualificationLevel.Master, 6),
                new AncientTongueLore(AntientLanguage.Kyr, QualificationLevel.Master, 7),
                new HumanInsight(QualificationLevel.Master, 8)
            ]);
            return BuildQualifications(result);
        }
    }

    public override string Name => "Priest of Sogron";

    public override Deity Deity { get; set; } = Deity.Sogron;
}
