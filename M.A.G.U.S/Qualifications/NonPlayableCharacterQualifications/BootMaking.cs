using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.NonPlayableCharacterQualifications;

public class BootMaking : Qualification
{
    public BootMaking(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
        : base(qualificationLevel, level)
    {
    }

    public override string Name => "Boot making";
}
