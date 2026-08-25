using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MissingHeirloomDoran : Quest
{
    public override string Name => "The Missing Locket";

    public override string Description => "A Doran merchant's late mother's locket went missing sometime during the funeral reception, and she's quietly offering coin to whoever finds it before it turns up on a pawnbroker's shelf.";

    public override string Objective => "Search Doran for the missing locket.";

    public override City City => City.Doran;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Doran;
}
