using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Scientific;

public class RunicMagic(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IScientificQualification
{
    public override string Name => "Runic magic";

    public override int QpToBaseQualification => 18;

    public override int QpToMasterQualification => 45;

    public RunicMagic() : this(QualificationLevel.Base) { }
}
