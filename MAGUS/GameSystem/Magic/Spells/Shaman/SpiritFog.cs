using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Köd (Sámán — Természeti mágia, Második Törvénykönyv p.125-126). Conjures a thick, unnatural fog
/// (up to 300 meters from the shaman) that makes bows and thrown weapons unusable and cuts the
/// Támadóérték of anyone standing in it by 15; lasts 5 rounds, extendable with more Mana. Modeled
/// as a flat Attack-value penalty to whoever is caught inside.
/// </summary>
public sealed class SpiritFog : ISpell
{
    public string Name => "Spirit fog";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 5;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = -15
        });
    }
}
