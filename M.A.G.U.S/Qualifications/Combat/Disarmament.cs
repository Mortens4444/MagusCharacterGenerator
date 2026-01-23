using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class Disarmament(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override int QpToBaseQualification => 7;

    public override int QpToMasterQualification => 18;

    public Disarmament() : this(QualificationLevel.Base) { }
}
