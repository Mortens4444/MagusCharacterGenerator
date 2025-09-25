using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Underworld;

public class EscapeBonds : Qualification
{
    public EscapeBonds(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
        : base(qualificationLevel, level)
    {
    }

    public override string Name => "Escape bonds";

    public override byte QpToBaseQualification => 8;

    public override byte QpToMasterQualification => 16;
}
