using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Underworld;

public class Forgery : Qualification
{
    public Forgery(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1)
        : base(qualificationLevel, level)
    {
    }

    public override int QpToBaseQualification => 11;

    public override int QpToMasterQualification => 24;

    public Forgery() : this(QualificationLevel.Base) { }
}
