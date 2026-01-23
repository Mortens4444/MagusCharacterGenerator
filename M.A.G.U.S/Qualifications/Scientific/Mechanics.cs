using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class Mechanics(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override int QpToBaseQualification => 8;

    public override int QpToMasterQualification => 25;

    public Mechanics() : this(QualificationLevel.Base) { }
}
