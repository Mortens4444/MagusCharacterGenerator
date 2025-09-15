using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.GameSystem.Qualifications;
using Newtonsoft.Json;

namespace M.A.G.U.S.Qualifications.Scientific;

public class AntientLanguageKnowledge : Qualification, ICanHaveMany
{
    public AntientLanguage Language { get; set; }

    [JsonConstructor]
    public AntientLanguageKnowledge() { }

    public AntientLanguageKnowledge(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
            : base(qualificationLevel, level)
    {
    }

    public AntientLanguageKnowledge(AntientLanguage language, QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
        : base(qualificationLevel, level)
    {
        Language = language;
    }

    public override string Name => "Antient language knowledge";
}
