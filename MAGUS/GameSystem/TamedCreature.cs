using MAGUS.Bestiary;
using MAGUS.GameSystem.Places;

namespace MAGUS.GameSystem;

/// <summary>
/// A creature a character has successfully tamed (Character.TryTameCreature) - kept separate from
/// Equipment since a live animal isn't an inventory item, and tracked with its own Location since
/// (unlike a carried Thing) it doesn't necessarily travel along with the character - it may be left
/// behind at a stable, farm, or wherever it was tamed.
/// </summary>
public class TamedCreature
{
    public required Creature Creature { get; set; }

    public City Location { get; set; }
}
