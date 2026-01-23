using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class MagicLore(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Magic lore";

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 25;

    public MagicLore() : this(QualificationLevel.Base) { }
}
