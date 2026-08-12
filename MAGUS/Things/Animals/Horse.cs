using MAGUS.Enums;
using MAGUS.Services;

namespace MAGUS.Things.Animals;

public abstract class Horse : Thing
{
    protected Horse(ThrowType qualityRollMode = ThrowType._2D10)
    {
        QualityResult = HorseQualityResult.RollHorseQuality(qualityRollMode);
    }

    public HorseQualityResult QualityResult { get; }
}