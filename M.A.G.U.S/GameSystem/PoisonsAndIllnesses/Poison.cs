using M.A.G.U.S.Enums;
using M.A.G.U.S.Things;
using M.A.G.U.S.Utils;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public abstract class Poison : Thing
{
    public abstract PoisonDuration PoisonDuration { get; }

    public abstract PoisonOnsetTime PoisonOnsetTime { get; }

    public abstract PoisonType PoisonType { get; }

    public virtual IReadOnlyList<PoisonEffect> PoisonEffects => Laboratory.GetPoisonEffects(PoisonType);

    public virtual int Level => 1;
}
