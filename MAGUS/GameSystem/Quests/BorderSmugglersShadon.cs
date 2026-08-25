using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class BorderSmugglersShadon : Quest
{
    public override string Name => "Eyes on the Border Road";

    public override string Description => "The scouting reports from Shadon's border hills weren't rumors after all - armed men are moving supplies across the line at night, and the garrison wants them stopped before it becomes an incident between nations.";

    public override string Objective => "Deal with the smugglers operating along Shadon's border.";

    public override City City => City.Shadon;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 55;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
