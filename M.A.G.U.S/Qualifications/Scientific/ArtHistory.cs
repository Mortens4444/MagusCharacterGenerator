using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class ArtHistory(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override string Name => "Art history";

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 25;

    public ArtHistory() : this(QualificationLevel.Base) { }
}
