using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class AnimalTraining(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Animal training";

    public override byte QpToBaseQualification => 8;

    public override byte QpToMasterQualification => 20;
}
