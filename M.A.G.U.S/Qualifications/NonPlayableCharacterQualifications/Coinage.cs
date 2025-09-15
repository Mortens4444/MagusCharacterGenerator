using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.NonPlayableCharacterQualifications;

public class Coinage : Qualification
{
    public Coinage(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
        : base(qualificationLevel, level)
    {
    }
}
