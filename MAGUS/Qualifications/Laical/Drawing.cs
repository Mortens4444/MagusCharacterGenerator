using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class Drawing(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 25;

    public Drawing() : this(QualificationLevel.Base) { }
}
