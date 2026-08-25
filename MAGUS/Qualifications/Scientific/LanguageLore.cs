using MAGUS.GameSystem.Languages;
using MAGUS.GameSystem.Qualifications;
using Newtonsoft.Json;

namespace MAGUS.Qualifications.Scientific;

public class LanguageLore : Qualification, ICanHaveMany, IScientificQualification
{
    public override string Key => $"{GetType().Name}:{Language?.GetType().Name ?? Guid.NewGuid().ToString()}";

    public Language? Language { get; set; }

    public int LanguageLevel { get; set; }

    public override bool NeedsSelection => Language == null;

    [JsonConstructor]
    public LanguageLore() { }

    public LanguageLore(int languageLevel, int level = 1)
            : base(languageLevel > 5 ? QualificationLevel.Master : QualificationLevel.Base, level)
    {
        LanguageLevel = languageLevel;
    }

    public LanguageLore(Language language, int languageLevel, int level = 1)
        : base(languageLevel > 5 ? QualificationLevel.Master : QualificationLevel.Base, level)
    {
        Language = language;
        LanguageLevel = languageLevel;
    }

    public override string Name => "Language lore";

    public override int QpToBaseQualification => 1;

    public override int? QpToMaxBaseQualification => 5;

    public override int QpToMasterQualification => 20;

    public override string ToString()
    {
        if (!Language.HasValue)
        {
            return Name;
        }
        return $"{Name} - {Language}";
    }
}
