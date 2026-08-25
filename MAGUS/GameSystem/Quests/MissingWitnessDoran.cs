using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MissingWitnessDoran : Quest
{
    public override string Name => "The Missing Witness";

    public override string Description => "The one witness to a contract dispute worth a small fortune has stopped answering his door in Doran, and the magistrate's clerk fears he's simply been paid to disappear before the hearing.";

    public override string Objective => "Search Doran for the missing witness.";

    public override City City => City.Doran;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Doran;
}
