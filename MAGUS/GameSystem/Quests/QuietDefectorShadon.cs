using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class QuietDefectorShadon : Quest
{
    public override string Name => "The Quiet Defector";

    public override string Description => "A soldier from across the border has slipped through Shadon's line with information the garrison commander wants delivered in person to the right ears in Pyarron - and staying put is more dangerous for him than the road.";

    public override string Objective => "Escort the defector safely to Pyarron.";

    public override City City => City.Shadon;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 60;

    public override int MinLevel => 2;

    public override int MaxLevel => 5;

    public override City? EscortDestination => City.Pyarron;
}
