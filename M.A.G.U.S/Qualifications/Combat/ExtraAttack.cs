using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class ExtraAttack(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Extra attack";

    public override int QpToBaseQualification => 7 ; // 0

    public override int QpToMasterQualification => 15; // 8

    public ExtraAttack() : this(QualificationLevel.Base) { }
}
