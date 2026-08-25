using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class EnvoyEscortEnosuke : Quest
{
    public override string Name => "The Foreign Envoy";

    public override string Description => "A trade envoy newly arrived in Enosuke needs a bodyguard who won't cause an incident - someone unaffiliated with any of the island's trading houses, all of which have their own reasons to want her gone before she can carry her deal to the mainland port at Riegoy.";

    public override string Objective => "Escort the envoy safely to Riegoy.";

    public override City City => City.Enosuke;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? EscortDestination => City.Riegoy;
}
