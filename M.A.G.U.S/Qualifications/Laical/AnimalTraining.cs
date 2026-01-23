using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class AnimalTraining(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Animal training";

    public override int QpToBaseQualification => 8;

    public override int QpToMasterQualification => 20;

    public AnimalTraining() : this(QualificationLevel.Base) { }
}
