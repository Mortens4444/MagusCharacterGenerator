using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Scientific;

public class AntisWalking(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public AntisWalking() : this(QualificationLevel.Base) { }

    public override int QpToBaseQualification => 15;

    public override int QpToMasterQualification => 45;

    public override string Name => "Antis walking";
}
