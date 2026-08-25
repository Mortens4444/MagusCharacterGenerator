using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class AuditorsEscortToron : Quest
{
    public override string Name => "Numbers That Need Checking";

    public override string Description => "A guild auditor in Toron needs to reach Ordan's mining claims office before a suspicious set of books gets 'lost' in a convenient accident, and she's not confident she'll make the trip alone.";

    public override string Objective => "Escort the auditor safely to Ordan.";

    public override City City => City.Toron;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? EscortDestination => City.Ordan;
}
