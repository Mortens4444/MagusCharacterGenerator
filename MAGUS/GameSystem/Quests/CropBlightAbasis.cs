using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class CropBlightAbasis : Quest
{
    public override string Name => "Blackened Fields";

    public override string Description => "Fields outside Abasis are withering overnight in neat, unnatural patches. The farmers whisper of a curse; the granary masters just want it to stop before the harvest fails.";

    public override string Objective => "Find the cause of the blight spreading through the fields.";

    public override City City => City.Abasis;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 65;

    public override int MinLevel => 3;

    public override int MaxLevel => 5;

    public override City? SearchLocation => City.Abasis;
}
