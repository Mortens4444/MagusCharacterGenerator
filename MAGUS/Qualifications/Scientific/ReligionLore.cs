using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Scientific;

public class ReligionLore(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IScientificQualification
{
    public override string Name => "Religion lore";

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 25;

    public ReligionLore() : this(QualificationLevel.Base) { }
}
