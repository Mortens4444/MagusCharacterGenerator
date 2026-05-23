using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class Mechanics(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IScientificQualification
{
    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 35;

    public Mechanics() : this(QualificationLevel.Base) { }
}
