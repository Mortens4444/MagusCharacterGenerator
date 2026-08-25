using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class ScholarEscortTalasea : Quest
{
    public override string Name => "Getting the Records Out";

    public override string Description => "The scholar studying Talasea's awakening magic wants her notes - and herself - safely off site and back to the college archives in Erion before whatever she's found finishes waking up.";

    public override string Objective => "Escort the scholar and her notes safely to Erion.";

    public override City City => City.Talasea;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? EscortDestination => City.Erion;
}
