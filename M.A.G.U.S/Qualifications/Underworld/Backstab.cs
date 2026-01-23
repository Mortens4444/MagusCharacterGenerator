using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Underworld;

public class Backstab(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 25;

    public Backstab() : this(QualificationLevel.Base) { }
}
