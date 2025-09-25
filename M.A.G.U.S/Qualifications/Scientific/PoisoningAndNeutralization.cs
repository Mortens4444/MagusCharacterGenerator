using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class PoisoningAndNeutralization(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Poisoning and neutralization";

    public override byte QpToBaseQualification => 15;

    public override byte QpToMasterQualification => 60;
}
