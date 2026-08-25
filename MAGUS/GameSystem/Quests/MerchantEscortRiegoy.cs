using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MerchantEscortRiegoy : Quest
{
    public override string Name => "Cargo of Some Importance";

    public override string Description => "A Riegoy merchant needs a particular chest delivered to a buyer in Toron in person, no couriers, no questions - and enough coin changes hands up front to make clear the cargo is worth more than its weight.";

    public override string Objective => "Escort the merchant's cargo safely to Toron.";

    public override City City => City.Riegoy;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? EscortDestination => City.Toron;
}
