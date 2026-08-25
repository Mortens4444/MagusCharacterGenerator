using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class BlackSharkBayRiegoy : Quest
{
    public override string Name => "Blood in the Water";

    public override string Description => "Riegoy's pearl divers have refused to go back into the bay since one of them came up missing an oar and most of a boat, and the harbor's fish stocks have been thinning just as fast.";

    public override string Objective => "Deal with the predator hunting Riegoy Bay.";

    public override City City => City.Riegoy;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 5;

    public override string? TargetCreatureName => "BlackShark";
}
