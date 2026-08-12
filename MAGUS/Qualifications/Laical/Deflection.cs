using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class Deflection(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override string Name => "Deflection / evasive talk";

    public override int QpToBaseQualification => 3;

    public override int QpToMasterQualification => 9;

    public Deflection() : this(QualificationLevel.Base) { }
}
