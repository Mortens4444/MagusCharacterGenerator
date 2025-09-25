using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Underworld;

public class TavernBrawling(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Tavern brawling";

    public override byte QpToBaseQualification => 3;

    public override byte QpToMasterQualification => 15;
}
