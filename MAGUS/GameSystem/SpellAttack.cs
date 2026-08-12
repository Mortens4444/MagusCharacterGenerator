using MAGUS.Interfaces;
using Newtonsoft.Json;

namespace MAGUS.GameSystem;

public sealed class SpellAttack : MysticAttack
{
    public ISpell Spell { get; init; }

    public int ManaCost => Spell.ManaCost;

    [JsonConstructor]
    public SpellAttack() : base() { }

    public SpellAttack(ISpell spell)
        : base(spell.Name, spell.InitiateValue, spell.ResistanceType, spell.CastingTimeInSegments, spell.DurationInRounds, spell.GetDamage)
    {
        Spell = spell;
    }
}
