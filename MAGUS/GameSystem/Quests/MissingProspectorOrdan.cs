using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MissingProspectorOrdan : Quest
{
    public override string Name => "Gone to Ground";

    public override string Description => "A prospector who swore she'd found a rich vein in the hills above Ordan never came back down. Her family in the valley strip below is asking anyone willing to look.";

    public override string Objective => "Find the missing prospector, or what became of her.";

    public override City City => City.Ordan;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 40;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Ordan;
}
