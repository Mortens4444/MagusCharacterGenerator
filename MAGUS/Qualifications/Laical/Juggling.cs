using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class Juggling(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override int QpToBaseQualification => 3;

    public override int QpToMasterQualification => 10;

    public Juggling() : this(QualificationLevel.Base) { }
}
