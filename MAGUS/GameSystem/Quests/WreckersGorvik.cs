using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class WreckersGorvik : Quest
{
    public override string Name => "False Lights";

    public override string Description => "A second ship has run aground on Gorvik's rocks this season, and the harbormaster is now certain the wrecks aren't accidents - someone's been luring ships in with false signal fires and picking the wreckage clean.";

    public override string Objective => "Find and stop whoever is wrecking ships along Gorvik's coast.";

    public override City City => City.Gorvik;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 60;

    public override int MinLevel => 2;

    public override int MaxLevel => 5;

    public override bool TargetIsGeneratedBandit => true;
}
