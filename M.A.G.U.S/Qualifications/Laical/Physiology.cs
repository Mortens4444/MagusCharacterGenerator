using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class Physiology(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IScientificQualification
{
    public override int QpToBaseQualification => 8;

    public override int QpToMasterQualification => 25;

    public Physiology() : this(QualificationLevel.Base) { }
}
