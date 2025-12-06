using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class Wrestling(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1)
	: Qualification(qualificationLevel, level)
{
    public override int QpToBaseQualification => 8;

    public override int QpToMasterQualification => 15;
}
