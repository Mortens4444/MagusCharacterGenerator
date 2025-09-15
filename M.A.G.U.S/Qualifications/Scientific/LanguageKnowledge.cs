using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.GameSystem.Qualifications;
using Mtf.Extensions;
using Newtonsoft.Json;

namespace M.A.G.U.S.Qualifications.Scientific;

public class LanguageKnowledge : Qualification, ICanHaveMany
{
    public Language Language { get; set; }

    [JsonConstructor]
    public LanguageKnowledge() { }

    public LanguageKnowledge(byte languageLevel, byte level = 1)
            : base(languageLevel > 5 ? QualificationLevel.Master : QualificationLevel.Base, level)
    {
    }

    public LanguageKnowledge(Language language, byte languageLevel, byte level = 1)
        : base(languageLevel > 5 ? QualificationLevel.Master : QualificationLevel.Base, level)
    {
        Language = language;
    }

    public override string Name => "Language knowledge";
}
