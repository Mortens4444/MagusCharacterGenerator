using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class EscapedBeastErion : Quest
{
    public override string Name => "Loose in the Streets";

    public override string Description => "A private collector in Erion kept something dangerous in a cage behind his house - and it isn't there anymore. He's offering coin to whoever brings it back, dead or caged.";

    public override string Objective => "Track down the collector's escaped beast before it hurts someone.";

    public override City City => City.Erion;

    public override Money MoneyReward => new(0, 9, 0);

    public override ulong ExperienceReward => 90;

    public override int MinLevel => 4;

    public override int MaxLevel => 6;

    public override string? TargetCreatureName => "Wolf";
}
