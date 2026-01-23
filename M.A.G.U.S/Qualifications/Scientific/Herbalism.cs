using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class Herbalism(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 35;

    public Herbalism() : this(QualificationLevel.Base) { }
}
