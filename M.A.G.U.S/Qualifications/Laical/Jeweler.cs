using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class Jeweler(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public Jeweler() : this(QualificationLevel.Base) { }

    public override int QpToBaseQualification => 8;

    public override int QpToMasterQualification => 30;
}
