using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

/// <summary>Sonnion is a ruined, uninhabited amund city, so like LostTextSonnion this has no city NPC to hand it out - the vault is simply what a careful search of the ruins turns up.</summary>
public sealed class HiddenVaultSonnion : Quest
{
    public override string Name => "A Seam in the Wall";

    public override string Description => "A section of Sonnion's collapsed colonnade doesn't match the stone around it - too regular, too deliberate - and whatever's sealed behind it hasn't seen daylight since the city fell.";

    public override string Objective => "Search Sonnion's ruins for the sealed vault behind the false wall.";

    public override City City => City.Sonnion;

    public override Money MoneyReward => new(0, 9, 0);

    public override ulong ExperienceReward => 90;

    public override int MinLevel => 4;

    public override int MaxLevel => 6;

    public override City? SearchLocation => City.Sonnion;
}
