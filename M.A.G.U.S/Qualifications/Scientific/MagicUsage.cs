using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class MagicUsage(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IScientificQualification
{
    public override string Name => "Magic usage";

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 25;

    public MagicUsage() : this(QualificationLevel.Base) { }
}
