using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class InflictingPain(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Inflicting pain";

    public override int QpToBaseQualification => 9;

    public override int QpToMasterQualification => 20;

    public InflictingPain() : this(QualificationLevel.Base) { }
}
