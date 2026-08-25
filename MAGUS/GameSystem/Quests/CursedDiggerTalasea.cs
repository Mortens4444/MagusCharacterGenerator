using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class CursedDiggerTalasea : Quest
{
    public override string Name => "He Went In Whole";

    public override string Description => "A digger who went missing in Talasea's ruins a month ago came back changed - his crew swears the thing prowling the site at night still wears his boots.";

    public override string Objective => "Find and put an end to whatever the missing digger became.";

    public override City City => City.Talasea;

    public override Money MoneyReward => new(0, 10, 0);

    public override ulong ExperienceReward => 110;

    public override int MinLevel => 4;

    public override int MaxLevel => 7;

    public override string? TargetCreatureName => "Werewolf";
}
