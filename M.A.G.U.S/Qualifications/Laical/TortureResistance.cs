using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class TortureResistance(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Torture resistance";

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 12;

    public TortureResistance() : this(QualificationLevel.Base) { }
}
