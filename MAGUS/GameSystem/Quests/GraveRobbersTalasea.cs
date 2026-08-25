using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

/// <summary>Talasea (Thalatheia) is Refis's ruined amund city - like Sonnion, uninhabited, so this is simply what the ruins themselves present to whoever walks in.</summary>
public sealed class GraveRobbersTalasea : Quest
{
    public override string Name => "Freshly Broken Seals";

    public override string Description => "Someone has beaten you to Talasea's tombs - several seals lie shattered, and the tools left behind aren't centuries old like everything else around them.";

    public override string Objective => "Find whoever is looting Talasea's tombs.";

    public override City City => City.Talasea;

    public override Money MoneyReward => new(0, 8, 0);

    public override ulong ExperienceReward => 80;

    public override int MinLevel => 3;

    public override int MaxLevel => 6;

    public override City? SearchLocation => City.Talasea;
}
