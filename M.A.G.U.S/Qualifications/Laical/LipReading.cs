using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class LipReading(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Lip reading";

    public override int QpToBaseQualification => 7;

    public override int QpToMasterQualification => 10;

    public LipReading() : this(QualificationLevel.Base) { }
}
