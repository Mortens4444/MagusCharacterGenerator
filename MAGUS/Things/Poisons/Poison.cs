using MAGUS.Enums;
using MAGUS.Things;
using MAGUS.Utils;

namespace MAGUS.Things.Poisons;

public abstract class Poison : Thing
{
    public abstract PoisonDuration PoisonDuration { get; }

    public abstract PoisonOnsetTime PoisonOnsetTime { get; }

    public abstract PoisonType PoisonType { get; }

    public virtual IReadOnlyList<PoisonEffect> PoisonEffects => Laboratory.GetPoisonEffects(PoisonType);

    public virtual int Level => 1;
}
