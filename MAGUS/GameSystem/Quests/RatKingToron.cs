using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RatKingToron : Quest
{
    public override string Name => "The One Beneath the Cellars";

    public override string Description => "The rats cleared from that tavern cellar were only the outer edge of something bigger nesting under Toron's market district - something the ratcatchers refuse to go near a second time.";

    public override string Objective => "Find and kill whatever is commanding the rats beneath Toron.";

    public override City City => City.Toron;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 60;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override string? TargetCreatureName => "RatBaron";
}
