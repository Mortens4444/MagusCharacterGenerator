using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Scientific;

namespace M.A.G.U.S.Classes.Believer.Ranagol;

public class KrannishRanagolPriest : Priest
{
    public KrannishRanagolPriest() : base() { }

    public KrannishRanagolPriest(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    public override QualificationList FutureQualifications
    {
        get
        {
            var result = base.FutureQualifications;
            result.AddRange(
            [
                new Spellcasting(level: 3),
                new AncientTongueLore(AntientLanguage.Aquir, level: 5),
                new Spellcasting(QualificationLevel.Master, 6),
                new AncientTongueLore(AntientLanguage.Aquir, QualificationLevel.Master, 11)
            ]);
            return BuildQualifications(result);
        }
    }

    public override string Name => "Priest of Ranagol (Krannish)";

    public override Deity Deity { get; set; } = Deity.Ranagol;
}
