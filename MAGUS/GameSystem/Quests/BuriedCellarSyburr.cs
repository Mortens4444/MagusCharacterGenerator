using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class BuriedCellarSyburr : Quest
{
    public override string Name => "The Sealed Cellar";

    public override string Description => "Renovation work on an old Syburr townhouse uncovered a bricked-up cellar entrance nobody on record knew existed - the owner would rather know what's down there before he finishes the renovation.";

    public override string Objective => "Search the sealed cellar beneath the townhouse in Syburr.";

    public override City City => City.Syburr;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Syburr;
}
