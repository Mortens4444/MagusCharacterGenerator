using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class Etiquette(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override int QpToBaseQualification => 8;

    public override int QpToMasterQualification => 15;

    public Etiquette() : this(QualificationLevel.Base) { }
}
