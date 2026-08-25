using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class AssayerEscortOrdan : Quest
{
    public override string Name => "Weighing the Claim";

    public override string Description => "An independent assayer has agreed to certify a disputed ore claim above Ordan, but only if she's escorted safely to Toron afterward to file the paperwork before anyone can pressure her into changing it.";

    public override string Objective => "Escort the assayer safely to Toron.";

    public override City City => City.Ordan;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? EscortDestination => City.Toron;
}
