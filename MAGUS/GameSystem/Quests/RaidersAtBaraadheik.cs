using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RaidersAtBaraadheik : Quest
{
    public override string Name => "Raiders at Baraadheik";

    public override string Description => "A loose band of raiders has been circling Baraadheik for days, testing the edges of the settlement for a way in after dark.";

    public override string Objective => "Drive off the raiders threatening Baraadheik.";

    public override City City => City.Baraadheik;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
