using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Other;

public class Blacksmith(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public Blacksmith() : this(QualificationLevel.Base) { }

    public override int QpToBaseQualification => 2;

    public override int QpToMasterQualification => 15;
}
