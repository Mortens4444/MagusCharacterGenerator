using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Other;

public class Pottery(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public Pottery() : this(QualificationLevel.Base) { }

    public override int QpToBaseQualification => 2;

    public override int QpToMasterQualification => 15;
}
