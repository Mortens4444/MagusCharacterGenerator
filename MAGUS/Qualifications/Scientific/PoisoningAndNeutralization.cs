using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Scientific;

public class PoisoningAndNeutralization(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IScientificQualification
{
    public override string Name => "Poisoning/neutralization";

    public override int QpToBaseQualification => 15;

    public override int QpToMasterQualification => 60;

    public PoisoningAndNeutralization() : this(QualificationLevel.Base) { }
}
