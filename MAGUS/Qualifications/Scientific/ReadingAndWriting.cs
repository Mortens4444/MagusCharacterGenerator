using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Scientific;

public class ReadingAndWriting(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IScientificQualification
{
    public override string Name => "Reading/writing";

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 25;

    public ReadingAndWriting() : this(QualificationLevel.Base) { }
}
