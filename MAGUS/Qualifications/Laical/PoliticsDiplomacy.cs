using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class PoliticsDiplomacy(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public PoliticsDiplomacy() : this(QualificationLevel.Base) { }

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 25;

    public override string Name => "Politics / Diplomacy";
}
