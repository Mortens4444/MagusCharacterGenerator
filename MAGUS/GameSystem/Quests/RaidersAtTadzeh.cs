using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RaidersAtTadzeh : Quest
{
    public override string Name => "Uninvited Guests";

    public override string Description => "A rough crew has been raiding storehouses on the edge of Tadzeh under cover of night, and the local watch is stretched too thin to catch them in the act.";

    public override string Objective => "Track down and deal with the raiders troubling Tadzeh.";

    public override City City => City.Tadzeh;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
