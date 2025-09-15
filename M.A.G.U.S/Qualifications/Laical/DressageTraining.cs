using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class DressageTraining : Qualification
{
    public DressageTraining(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
        : base(qualificationLevel, level)
    {
    }

    public override string Name => "Dressage training";
}
