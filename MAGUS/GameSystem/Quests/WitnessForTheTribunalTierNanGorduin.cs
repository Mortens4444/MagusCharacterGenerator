using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class WitnessForTheTribunalTierNanGorduin : Quest
{
    public override string Name => "Testimony Worth Killing For";

    public override string Description => "A merchant's clerk saw enough at TierNanGorduin to break open a smuggling case in Abesar, and both the judges and the smugglers know it - she needs to reach Abesar alive to testify.";

    public override string Objective => "Escort the witness safely to Abesar.";

    public override City City => City.TierNanGorduin;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 60;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? EscortDestination => City.Abesar;
}
