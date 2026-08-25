using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SomethingInTheWineCellarDoran : Quest
{
    public override string Name => "Something in the Wine Cellar";

    public override string Description => "A Doran wine merchant has heard chittering and small footsteps beneath his cellar floor for a week, and now an entire rack of aged bottles has turned up smashed with tiny, gnawed footprints all around.";

    public override string Objective => "Clear out whatever has infested the wine merchant's cellar in Doran.";

    public override City City => City.Doran;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override string? TargetCreatureName => "Kobold";
}
