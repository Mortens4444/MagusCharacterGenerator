using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

/// <summary>Ó-Pyarron is the old, largely-ruined former capital - distinct from the current capital, City.Pyarron - so this leans into decline and old remnants rather than a normal bustling-town quest.</summary>
public sealed class ScavengersInTheRuinsOPyarron : Quest
{
    public override string Name => "Squatters in the Old Capital";

    public override string Description => "A gang of scavengers has taken up residence in a collapsed wing of Ó-Pyarron's old palace district, stripping what little the centuries left behind and threatening anyone who wanders too close.";

    public override string Objective => "Clear the scavengers out of the ruined palace district in Ó-Pyarron.";

    public override City City => City.OPyarron;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
