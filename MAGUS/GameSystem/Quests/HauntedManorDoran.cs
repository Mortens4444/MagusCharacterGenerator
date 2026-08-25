using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class HauntedManorDoran : Quest
{
    public override string Name => "The Cold Room";

    public override string Description => "A merchant family in Doran has abandoned the east wing of their manor - lamps guttering for no reason, footsteps overhead when the room is empty - and want it dealt with quietly.";

    public override string Objective => "Find out what haunts the manor's east wing and put it to rest.";

    public override City City => City.Doran;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 70;

    public override int MinLevel => 3;

    public override int MaxLevel => 5;

    public override string? TargetCreatureName => "Shade";
}
