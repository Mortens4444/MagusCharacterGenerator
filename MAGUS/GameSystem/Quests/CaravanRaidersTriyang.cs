using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class CaravanRaidersTriyang : Quest
{
    public override string Name => "The Approach to Triyang";

    public override string Description => "Two caravans bound for Triyang have been hit in as many weeks, stripped of anything valuable and left stranded - merchants are refusing to risk a third trip without an escort willing to fight.";

    public override string Objective => "Find and deal with the raiders preying on caravans near Triyang.";

    public override City City => City.Triyang;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 45;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
