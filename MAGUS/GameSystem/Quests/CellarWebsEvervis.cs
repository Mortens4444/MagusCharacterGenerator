using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class CellarWebsEvervis : Quest
{
    public override string Name => "Webs in the Stockroom";

    public override string Description => "A warehouse foreman in Evervis has lost an entire stockroom to something that's webbed the shelves floor to ceiling, and nobody's willing to go back in for the inventory still trapped inside.";

    public override string Objective => "Clear out whatever has infested the Evervis warehouse.";

    public override City City => City.Evervis;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 45;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override string? TargetCreatureName => "Spider";
}
