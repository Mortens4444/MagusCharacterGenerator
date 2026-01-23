using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Underworld;

public class EscapeBonds(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Escape bonds";

    public override int QpToBaseQualification => 8;

    public override int QpToMasterQualification => 16;

    public EscapeBonds() : this(QualificationLevel.Base) { }
}
