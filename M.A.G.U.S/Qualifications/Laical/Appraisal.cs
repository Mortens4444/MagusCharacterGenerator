using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class Appraisal(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 11;

    public Appraisal() : this(QualificationLevel.Base) { }
}
