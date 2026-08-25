using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MislaidWaybillHaralk : Quest
{
    public override string Name => "The Mislaid Waybill";

    public override string Description => "A caravan master newly arrived in Haralk swears his waybill was in his coat pocket right up until it wasn't, and without it the customs house won't release his goods.";

    public override string Objective => "Search Haralk for the caravan master's missing waybill.";

    public override City City => City.Haralk;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Haralk;
}
