using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RaidersAtTheGateGarhudda : Quest
{
    public override string Name => "Trouble at the Gate";

    public override string Description => "A loose band of raiders has been probing Garhudda's outer wall after dark, testing the watch and making off with whatever's left unguarded.";

    public override string Objective => "Drive off the raiders testing Garhudda's defenses.";

    public override City City => City.Garhudda;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
