using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class CloseQuartersCombat(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Close-quarters combat";

    public override int QpToBaseQualification => 4;

    public override int QpToMasterQualification => 12;

    public CloseQuartersCombat() : this(QualificationLevel.Base) { }
}
