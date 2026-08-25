using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class AwakeningMagicTalasea : Quest
{
    public override string Name => "A Pulse in the Stone";

    public override string Description => "Deep in Talasea, a section of wall hums faintly under your hand - old amund magic, stirring for reasons that ended with this city centuries ago and shouldn't be starting again now.";

    public override string Objective => "Find the source of the awakening magic in Talasea's ruins.";

    public override City City => City.Talasea;

    public override Money MoneyReward => new(0, 11, 0);

    public override ulong ExperienceReward => 130;

    public override int MinLevel => 5;

    public override int MaxLevel => 8;

    public override string? TargetCreatureName => "AstralVampire";
}
