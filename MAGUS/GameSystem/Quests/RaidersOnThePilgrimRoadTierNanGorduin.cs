using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RaidersOnThePilgrimRoadTierNanGorduin : Quest
{
    public override string Name => "Blood on the Pilgrim Road";

    public override string Description => "Pilgrims bound for Darton's temple at TierNanGorduin have twice been turned back by raiders camped along the desert approach - the order's own guards are stretched too thin to clear them.";

    public override string Objective => "Deal with the raiders threatening the pilgrim road to TierNanGorduin.";

    public override City City => City.TierNanGorduin;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 65;

    public override int MinLevel => 3;

    public override int MaxLevel => 5;

    public override string? TargetCreatureName => "MutantOrc";
}
