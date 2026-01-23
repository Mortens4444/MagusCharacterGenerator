using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class CloseCombat(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Close combat";

    public override int QpToBaseQualification => 3;

    public override int QpToMasterQualification => 10;

    public CloseCombat() : this(QualificationLevel.Base) { }
}
