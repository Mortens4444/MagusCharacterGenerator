using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class Sculptury(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override int QpToBaseQualification => 8;

    public override int QpToMasterQualification => 30;

    public Sculptury() : this(QualificationLevel.Base) { }
}
