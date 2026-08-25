using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class VenomInThePalmsAlidax : Quest
{
    public override string Name => "Venom in the Palms";

    public override string Description => "A cluster of unusually large, unusually bold serpents has taken over the palm grove that shades Alidax's main well, and nobody drawing water wants to risk a bite to find out how bad it really is.";

    public override string Objective => "Clear the serpents out of Alidax's palm grove.";

    public override City City => City.Alidax;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override string? TargetCreatureName => "Coronella";
}
