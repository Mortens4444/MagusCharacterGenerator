using MAGUS.GameSystem.Languages;
using MAGUS.GameSystem.Qualifications;
using Newtonsoft.Json;

namespace MAGUS.Qualifications.Scientific;

public class AncientTongueLore : Qualification, ICanHaveMany, IScientificQualification
{
    public override string Key => $"{GetType().Name}:{Language?.GetType().Name ?? Guid.NewGuid().ToString()}";

    public AntientLanguage? Language { get; set; }

    public override bool NeedsSelection => !Language.HasValue;

    [JsonConstructor]
    public AncientTongueLore() { }

    public AncientTongueLore(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1)
            : base(qualificationLevel, level)
    {
    }

    public AncientTongueLore(AntientLanguage language, QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1)
        : base(qualificationLevel, level)
    {
        Language = language;
    }

    public override string Name => "Ancient tongue lore";
    
    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 60;

    public override string ToString()
    {
        if (!Language.HasValue)
        {
            return Name;
        }
        return $"{Name} - {Language}";
    }
}
