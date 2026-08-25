namespace MAGUS.Interfaces;

/// <summary>
/// Marks an ISpell that restores ActualHealthPoints rather than damaging - lets code identify "does
/// this character know a healing spell" (see Character.CanHeal, used by the Heal quest mechanic in
/// CharacterViewModel) without hardcoding a name list. Purely a marker; the actual healing happens
/// in the spell's own OnHit, same as any other spell.
/// </summary>
public interface IHealingSpell : ISpell;
