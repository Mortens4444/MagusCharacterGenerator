using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class NorthboundPassageEnosuke : Quest
{
    public override string Name => "Passage North";

    public override string Description => "A trading house factor needs to reach Gorvik before the season's contracts are renegotiated without her, and none of the island's own ships will risk the northern crossing this late in the year.";

    public override string Objective => "Escort the factor safely to Gorvik.";

    public override City City => City.Enosuke;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 60;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? EscortDestination => City.Gorvik;
}
