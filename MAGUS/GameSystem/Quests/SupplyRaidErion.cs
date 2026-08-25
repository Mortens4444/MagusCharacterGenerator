using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SupplyRaidErion : Quest
{
    public override string Name => "The College Shipment";

    public override string Description => "A wagon carrying instruments and rare reagents bound for Erion's college never arrived, and the drivers who did make it back have nothing coherent to say about who stopped them.";

    public override string Objective => "Recover the college's stolen supply shipment.";

    public override City City => City.Erion;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
