using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Scientific;

public class GemstoneMagic(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IScientificQualification
{
    public override string Name => "Gemstone magic";

    public override int QpToBaseQualification => 0;

    public override int QpToMasterQualification => 52;

    public GemstoneMagic() : this(QualificationLevel.Base) { }
}
