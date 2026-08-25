using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RoadTaxersLavandron : Quest
{
    public override string Name => "Uninvited Toll";

    public override string Description => "A gang has set up camp along the approach to Lavandron, stopping travelers and demanding coin under threat of the blade - and the local watch is too thin to spare anyone to deal with it.";

    public override string Objective => "Clear the road gang threatening travelers near Lavandron.";

    public override City City => City.Lavandron;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override bool TargetIsGeneratedBandit => true;
}
