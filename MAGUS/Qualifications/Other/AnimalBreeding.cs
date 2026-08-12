using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Other;

public class AnimalBreeding(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Animal breeding";

    public AnimalBreeding() : this(QualificationLevel.Base) { }

    public override int QpToBaseQualification => 2;

    public override int QpToMasterQualification => 15;
}
