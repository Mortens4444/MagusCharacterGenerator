using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class Sailing(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override int QpToBaseQualification => 15;

    public override int QpToMasterQualification => 40;

    public Sailing() : this(QualificationLevel.Base) { }
}
