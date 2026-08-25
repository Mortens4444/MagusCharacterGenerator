using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SabotagedSilkEnosuke : Quest
{
    public override string Name => "Ruined Cargo";

    public override string Description => "A silk merchant in Enosuke found her entire season's shipment slashed to ribbons in a locked warehouse, and suspects a rival house paid for the sabotage.";

    public override string Objective => "Find proof of who sabotaged the silk shipment.";

    public override City City => City.Enosuke;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 40;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Enosuke;
}
