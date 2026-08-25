using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class TheLostPilgrimsTokenTierNanGorduin : Quest
{
    public override string Name => "The Lost Pilgrim's Token";

    public override string Description => "An elderly pilgrim lost the carved token proving decades of service to Darton's order somewhere on the temple grounds at TierNanGorduin, and without it she won't be allowed to stand before the judges.";

    public override string Objective => "Search the temple grounds at TierNanGorduin for the pilgrim's lost token.";

    public override City City => City.TierNanGorduin;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.TierNanGorduin;
}
