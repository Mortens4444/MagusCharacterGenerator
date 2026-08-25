using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MerchantSabotageEvervis : Quest
{
    public override string Name => "Bad Blood, Worse Business";

    public override string Description => "Two merchant houses in Evervis have been at each other's throats for a generation, and one now suspects the other of bribing their warehouse staff to spoil shipments from the inside.";

    public override string Objective => "Find proof of who's sabotaging the merchant house's shipments.";

    public override City City => City.Evervis;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 45;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? SearchLocation => City.Evervis;
}
