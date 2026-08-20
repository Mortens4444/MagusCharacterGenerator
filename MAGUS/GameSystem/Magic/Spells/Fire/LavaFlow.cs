using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Lávafolyam (Tűzvarázsló, Első Törvénykönyv p.279). A tűzvarázsló zónájának teljes
/// szélességében meghasad a föld, és izzó láva tör elő; akit elér, nyomban életét veszti.
/// Represents the rulebook's outright death on a failed resistance roll directly, rather than
/// approximating it as a large damage roll. Fire-school damage bypasses magic resistance
/// entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class LavaFlow : ISpell
{
    public string Name => "Lava flow";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 45;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.ActualHealthPoints = 0;
    }
}
