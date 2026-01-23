using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Underworld;

public class CardSharping(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Card sharping";

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 20;

    public CardSharping() : this(QualificationLevel.Base) { }
}
