using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Scientific;

public class MagicLore(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IScientificQualification
{
    public override string Name => "Magic lore";

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 25;

    public MagicLore() : this(QualificationLevel.Base) { }
}
