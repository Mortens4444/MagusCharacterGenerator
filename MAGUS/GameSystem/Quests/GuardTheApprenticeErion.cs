using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class GuardTheApprenticeErion : Quest
{
    public override string Name => "Guard the Apprentice";

    public override string Description => "An alchemist in Erion needs a nervous apprentice escorted through a delivery run, and specifically asked for someone who can actually keep the boy alive if it goes wrong - he's more useful breathing than as a lesson learned.";

    public override string Objective => "Keep the apprentice alive if the delivery run turns dangerous.";

    public override City City => City.Erion;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 45;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override bool HasProtectAlly => true;

    public override string AllyDescription => "the alchemist's apprentice";
}
