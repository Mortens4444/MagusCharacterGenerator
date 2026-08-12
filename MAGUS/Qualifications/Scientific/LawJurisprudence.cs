using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Scientific;

public class LawJurisprudence(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public LawJurisprudence() : this(QualificationLevel.Base) { }

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 30;

    public override string Name => "Law / Jurisprudence";
}
