using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MissingCourierShadon : Quest
{
    public override string Name => "Undelivered";

    public override string Description => "An imperial courier never reached her destination in Shadon, and the sealed dispatch she carried was never meant to be read by anyone else. Discretion is worth as much as speed here.";

    public override string Objective => "Find the missing courier and recover the sealed dispatch.";

    public override City City => City.Shadon;

    public override Money MoneyReward => new(0, 9, 0);

    public override ulong ExperienceReward => 80;

    public override int MinLevel => 3;

    public override int MaxLevel => 6;

    public override City? SearchLocation => City.Shadon;
}
