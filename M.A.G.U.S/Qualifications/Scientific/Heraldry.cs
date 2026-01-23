using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class Heraldry(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 15;

    public Heraldry() : this(QualificationLevel.Base) { }
}
