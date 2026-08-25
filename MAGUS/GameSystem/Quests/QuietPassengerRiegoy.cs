using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class QuietPassengerRiegoy : Quest
{
    public override string Name => "A Quiet Passenger";

    public override string Description => "A Riegoy shipping agent needs an associate moved inland to Erigow without drawing attention - no manifest, no name given, just coin enough to make clear it matters.";

    public override string Objective => "Escort the agent's associate safely to Erigow.";

    public override City City => City.Riegoy;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? EscortDestination => City.Erigow;
}
