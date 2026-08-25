using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class NightHowlGorvik : Quest
{
    public override string Name => "What Howls at the Docks";

    public override string Description => "Something has been heard - and once, briefly, seen - stalking Gorvik's harbor district on clear nights, and the one dockhand who got a good look at it hasn't said a coherent word since.";

    public override string Objective => "Track down and deal with whatever is stalking Gorvik's docks at night.";

    public override City City => City.Gorvik;

    public override Money MoneyReward => new(0, 8, 0);

    public override ulong ExperienceReward => 75;

    public override int MinLevel => 3;

    public override int MaxLevel => 5;

    public override string? TargetCreatureName => "Werewolf";
}
