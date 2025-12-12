using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using Newtonsoft.Json;

namespace M.A.G.U.S.Qualifications.Scientific;

public class AncientTongueLore : WeaponQualification, ICanHaveMany
{
    public AntientLanguage? Language { get; set; }

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
