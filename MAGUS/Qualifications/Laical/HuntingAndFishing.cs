using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class HuntingAndFishing(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override string Name => "Hunting/fishing";

    public override int QpToBaseQualification => 8;

    public override int QpToMasterQualification => 15;

    public HuntingAndFishing() : this(QualificationLevel.Base) { }
}
