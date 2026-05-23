using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class Embalming(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public Embalming() : this(QualificationLevel.Base) { }

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 10;
}
