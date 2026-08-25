using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class VenomInTheBloodAlidax : Quest
{
    public override string Name => "Venom in the Blood";

    public override string Description => "A caravan guard was bitten by something venomous on the road into Alidax, and the local healer has run out of antivenin - what she needs now is someone who can actually mend the wound before the poison finishes the job.";

    public override string Objective => "Treat the guard's wound using healing magic or medical skill.";

    public override City City => City.Alidax;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override bool RequiresHealing => true;
}
