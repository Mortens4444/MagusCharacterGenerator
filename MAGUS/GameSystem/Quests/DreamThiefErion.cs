using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class DreamThiefErion : Quest
{
    public override string Name => "Sleepless in the Quarter";

    public override string Description => "Half the students in one of Erion's dormitories have woken screaming from the same nightmare three nights running, and the college physician has run out of mundane explanations.";

    public override string Objective => "Find and stop whatever is haunting the students' dreams in Erion.";

    public override City City => City.Erion;

    public override Money MoneyReward => new(0, 8, 0);

    public override ulong ExperienceReward => 80;

    public override int MinLevel => 3;

    public override int MaxLevel => 6;

    public override string? TargetCreatureName => "DreamThief";
}
