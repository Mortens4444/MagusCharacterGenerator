using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Underworld;

public class TavernBrawling(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Tavern brawling";

    public override int QpToBaseQualification => 3;

    public override int QpToMasterQualification => 15;

    public TavernBrawling() : this(QualificationLevel.Base) { }
}
