using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Battle;

public class ShieldUsing(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
    : Qualification(qualificationLevel, level)
{
    public override string Name => "Shield using";
}
