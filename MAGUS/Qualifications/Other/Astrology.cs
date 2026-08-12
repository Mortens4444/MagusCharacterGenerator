using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Other;

public class Astrology(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public Astrology() : this(QualificationLevel.Base) { }

    public override int QpToBaseQualification => 2;

    public override int QpToMasterQualification => 15;
}
