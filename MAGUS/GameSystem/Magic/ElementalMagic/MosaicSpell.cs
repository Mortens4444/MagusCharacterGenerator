using MAGUS.Enums;
using MAGUS.GameSystem.Magic.ElementalMagic.Forms;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.ElementalMagic;

/// <summary>
/// A ready-to-cast spell composed from an element-creation mosaic and the Arrow form - the
/// only Elemental Magic form that maps cleanly onto the existing single-target
/// <see cref="ISpell"/>/SpellAttack/CombatEngine pipeline. Mana cost and casting time are the
/// sum of the mosaics involved (p. 291); Arrow's damage is the created element's damage.
/// Elemental Magic mosaics carry no Mágiaellenállás entry in the book, so this bypasses the
/// magic-resistance roll like a spell with null Power.
/// </summary>
public sealed class MosaicArrowSpell : ISpell
{
    private static readonly Arrow arrow = new();

    private readonly IElementCreationMosaic creation;
    private readonly CreatedElement element;

    public MosaicArrowSpell(IElementCreationMosaic creation, CreatedElement element)
    {
        this.creation = creation;
        this.element = element;
    }

    public string Name => $"{creation.Name} Arrow";

    public MagicSchool School => MagicSchool.Mosaic;

    public int? Power => null;

    public int ManaCost => creation.GetManaCost(element.Strength);

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => creation.CastingTimeInSegments;

    public int DurationInRounds => 1;

    public int GetDamage() => arrow.GetDamage(element);
}

/// <summary>
/// Same idea as <see cref="MosaicArrowSpell"/>, but for the Sword form: wraps the created
/// element around a specific melee weapon's blade, adding the element's damage to the
/// weapon's own. Lasts 5 rounds while wielded.
/// </summary>
public sealed class MosaicSwordSpell : ISpell
{
    private static readonly Sword sword = new();

    private readonly IElementCreationMosaic creation;
    private readonly CreatedElement element;
    private readonly IWeapon weapon;

    public MosaicSwordSpell(IElementCreationMosaic creation, CreatedElement element, IWeapon weapon)
    {
        this.creation = creation;
        this.element = element;
        this.weapon = weapon;
    }

    public string Name => $"{creation.Name} Sword";

    public MagicSchool School => MagicSchool.Mosaic;

    public int? Power => null;

    public int ManaCost => creation.GetManaCost(element.Strength);

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => creation.CastingTimeInSegments;

    public int DurationInRounds => sword.DurationInRounds;

    public int GetDamage() => sword.GetDamage(element, weapon);
}
