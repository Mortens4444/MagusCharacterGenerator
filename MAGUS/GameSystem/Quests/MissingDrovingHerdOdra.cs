using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MissingDrovingHerdOdra : Quest
{
    public override string Name => "Strays on the Drove Road";

    public override string Description => "A drover bringing stock into Odra lost half his herd in a night storm on the approach road, and he's offering what little he can spare to anyone who helps him find where the animals scattered.";

    public override string Objective => "Search the approach road to Odra for the scattered herd.";

    public override City City => City.Odra;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override City? SearchLocation => City.Odra;
}
