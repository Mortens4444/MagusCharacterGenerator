using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.NonPlayableCharacterQualifications;

public class RopeBeating : Qualification
{
    public RopeBeating(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
        : base(qualificationLevel, level)
    {
    }

    public override string Name => "Rope beating";
}
