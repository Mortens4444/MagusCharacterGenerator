using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class StolenRelicPyarron : Quest
{
    public override string Name => "The Empty Reliquary";

    public override string Description => "A minor shrine in Pyarron has discovered its silver reliquary empty overnight, the lock untouched. The priests suspect the thief had help from within.";

    public override string Objective => "Recover the stolen reliquary and find out who took it.";

    public override City City => City.Pyarron;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? SearchLocation => City.Pyarron;
}
