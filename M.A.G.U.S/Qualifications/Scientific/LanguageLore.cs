using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.GameSystem.Qualifications;
using Newtonsoft.Json;

namespace M.A.G.U.S.Qualifications.Scientific;

public class LanguageLore : Qualification, ICanHaveMany
{
    public Language Language { get; set; }

    [JsonConstructor]
    public LanguageLore() { }

    public LanguageLore(byte languageLevel, byte level = 1)
            : base(languageLevel > 5 ? QualificationLevel.Master : QualificationLevel.Base, level)
    {
    }

    public LanguageLore(Language language, byte languageLevel, byte level = 1)
        : base(languageLevel > 5 ? QualificationLevel.Master : QualificationLevel.Base, level)
    {
        Language = language;
    }

    public override string Name => "Language lore";

    public override byte QpToBaseQualification => 1;

    public override byte? QpToMaxBaseQualification => 5;

    public override byte QpToMasterQualification => 20;
}
