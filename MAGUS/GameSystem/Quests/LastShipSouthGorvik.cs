using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class LastShipSouthGorvik : Quest
{
    public override string Name => "Before the Ice Closes";

    public override string Description => "A trader in Gorvik needs to reach Toron before the northern passes ice over for the season, and the roads this late in the year aren't safe for a merchant traveling alone.";

    public override string Objective => "Escort the trader safely to Toron before the passes close.";

    public override City City => City.Gorvik;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? EscortDestination => City.Toron;
}
