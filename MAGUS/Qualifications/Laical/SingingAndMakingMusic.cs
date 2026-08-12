using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class SingingAndMakingMusic(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override string Name => "Singing/music making";

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 30;

    public SingingAndMakingMusic() : this(QualificationLevel.Base) { }
}
