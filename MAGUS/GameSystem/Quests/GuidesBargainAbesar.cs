using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class GuidesBargainAbesar : Quest
{
    public override string Name => "The Guide's Bargain";

    public override string Description => "A desert guide in Abesar has agreed to lead a nervous merchant's family across the dunes to Alidax, but refuses to go without someone able to fight walking alongside the wagon.";

    public override string Objective => "Escort the guide and the merchant's family safely to Alidax.";

    public override City City => City.Abesar;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 45;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? EscortDestination => City.Alidax;
}
