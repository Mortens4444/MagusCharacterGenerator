using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class LocalKnowledge(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override string Name => "Local knowledge";

    public override int QpToBaseQualification => 1;

    public override int QpToMasterQualification => 8;

    public LocalKnowledge() : this(QualificationLevel.Base) { }
}
