using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Vágtató szarvas (Sámán — Állatszellem idézés, Második Törvénykönyv p.132). A deer-blood sigil
/// raises the recipient's Gyorsaság to 20 for movement, dodging and footwork, letting them keep
/// pace with a galloping horse tirelessly; their movement becomes hard to track, raising VÉ by 15
/// for the duration.
/// </summary>
public sealed class DeerSwiftness : ISpell
{
    public string Name => "Deer swiftness";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 250;

    public int DurationInRounds => 12;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            DefenseValue = 15
        });
    }
}
