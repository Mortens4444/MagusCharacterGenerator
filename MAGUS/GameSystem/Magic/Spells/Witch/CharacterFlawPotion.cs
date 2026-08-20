using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Jellemtorzítás itala (Boszorkány — Bájitalok, Első Törvénykönyv p.233-234). Book Mana cost is
/// 20 plus whichever Jellemtorzító Átok is bottled; 50 is a representative estimate (20 + a
/// mid-range curse cost). Book fixes the potion's base Erősség at 30E regardless of the
/// underlying curse — shown as a flat Power 30.
/// </summary>
public sealed class CharacterFlawPotion : ISpell
{
    public string Name => "Character flaw potion";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 30;

    public int ManaCost => 50;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
