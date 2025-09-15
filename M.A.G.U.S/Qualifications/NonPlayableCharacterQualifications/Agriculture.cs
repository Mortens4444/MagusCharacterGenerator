using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.NonPlayableCharacterQualifications;

public class Agriculture : Qualification
{
    public Agriculture(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
        : base(qualificationLevel, level)
    {
    }
}
