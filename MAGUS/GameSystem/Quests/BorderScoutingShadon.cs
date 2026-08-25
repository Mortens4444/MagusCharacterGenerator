using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class BorderScoutingShadon : Quest
{
    public override string Name => "Movement at the Border";

    public override string Description => "A garrison commander near Shadon's border has too few scouts and too many rumors of armed movement in the hills. He needs eyes he can trust, quietly, before he raises an alarm he can't take back.";

    public override string Objective => "Scout the border hills and report what's really moving out there.";

    public override City City => City.Shadon;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 65;

    public override int MinLevel => 3;

    public override int MaxLevel => 5;

    public override City? SearchLocation => City.Shadon;
}
