using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class BeforeTheTideRiegoy : Quest
{
    public override string Name => "Before the Tide Turns";

    public override string Description => "A fisherman's boy went out onto the mudflats at low tide chasing shellfish and hasn't come back - the tide turns in a few hours, and the flats vanish completely underwater when it does.";

    public override string Objective => "Find the boy on the mudflats before the tide comes back in.";

    public override City City => City.Riegoy;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override City? SearchLocation => City.Riegoy;

    public override double? TimeLimitHours => 6;
}
