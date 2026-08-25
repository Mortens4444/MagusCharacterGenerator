using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class FieldTripTalasea : Quest
{
    public override string Name => "Closer to the Source";

    public override string Description => "A professor of old magic wants to study Talasea's awakening ruins in person rather than from secondhand reports, against the strong advice of everyone who's actually been there.";

    public override string Objective => "Escort the professor safely to Talasea.";

    public override City City => City.Erion;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? EscortDestination => City.Talasea;
}
