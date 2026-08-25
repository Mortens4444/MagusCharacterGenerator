using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class AwakenedGuardianTalasea : Quest
{
    public override string Name => "The Sentinel Wakes";

    public override string Description => "The same tremor that roused Talasea's old magic also stirred something built to guard it - a clay sentinel now patrolling the collapsed colonnade on legs that shouldn't still move.";

    public override string Objective => "Destroy or disable the awakened sentinel before it turns on the excavation crews.";

    public override City City => City.Talasea;

    public override Money MoneyReward => new(0, 9, 0);

    public override ulong ExperienceReward => 100;

    public override int MinLevel => 4;

    public override int MaxLevel => 6;

    public override string? TargetCreatureName => "ClayGolem";
}
