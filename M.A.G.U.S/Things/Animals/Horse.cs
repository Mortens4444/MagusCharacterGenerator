using M.A.G.U.S.Enums;
using M.A.G.U.S.Services;

namespace M.A.G.U.S.Things.Animals;

public abstract class Horse : Thing
{
    protected Horse(ThrowType qualityRollMode = ThrowType._2D10)
    {
        QualityResult = HorseQualityResult.RollHorseQuality(qualityRollMode);
    }

    public HorseQualityResult QualityResult { get; }
}