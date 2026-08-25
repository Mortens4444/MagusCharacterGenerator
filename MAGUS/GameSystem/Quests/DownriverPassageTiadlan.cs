using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class DownriverPassageTiadlan : Quest
{
    public override string Name => "Downriver, Quietly";

    public override string Description => "A trader's daughter needs to reach Riegoy without her family's rivals hearing about it first, and Tiadlan's river current makes the trip fast - if whoever escorts her can keep her that way.";

    public override string Objective => "Escort the trader's daughter safely downriver to Riegoy.";

    public override City City => City.Tiadlan;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? EscortDestination => City.Riegoy;
}
