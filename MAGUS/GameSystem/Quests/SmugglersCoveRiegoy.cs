using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SmugglersCoveRiegoy : Quest
{
    public override string Name => "Hidden Coves";

    public override string Description => "The customs officer for Riegoy Bay knows smugglers are using the coves along its coast to dodge his tariffs entirely - he just can't prove it, or find them before they slip away again.";

    public override string Objective => "Locate the smugglers' hidden cove and gather proof.";

    public override City City => City.Riegoy;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 60;

    public override int MinLevel => 2;

    public override int MaxLevel => 5;

    public override City? SearchLocation => City.Riegoy;
}
