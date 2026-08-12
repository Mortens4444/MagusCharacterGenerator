using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class Onomatopoeia(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override int QpToBaseQualification => 3;

    public override int QpToMasterQualification => 16;

    public Onomatopoeia() : this(QualificationLevel.Base) { }
}
