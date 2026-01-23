using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class Sculptury(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override int QpToBaseQualification => 3;

    public override int QpToMasterQualification => 18;

    public Sculptury() : this(QualificationLevel.Base) { }
}
