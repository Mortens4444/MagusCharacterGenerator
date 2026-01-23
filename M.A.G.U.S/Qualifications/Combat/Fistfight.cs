using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class Fistfight(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override int QpToBaseQualification => 3;

    public override int QpToMasterQualification => 15;

    public Fistfight() : this(QualificationLevel.Base) { }
}
