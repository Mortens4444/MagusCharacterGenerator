using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class DockPackErigow : Quest
{
    public override string Name => "Pack on the Docks";

    public override string Description => "A pack of half-feral dogs has claimed the loading docks after dark, and the night crews loading Erigow's warehouses refuse to work until someone clears them out.";

    public override string Objective => "Drive off or kill the dog pack on Erigow's docks.";

    public override City City => City.Erigow;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 45;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override string? TargetCreatureName => "WildDog";
}
