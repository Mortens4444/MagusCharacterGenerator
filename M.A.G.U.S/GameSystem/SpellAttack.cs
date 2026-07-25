using M.A.G.U.S.Interfaces;
using Newtonsoft.Json;

namespace M.A.G.U.S.GameSystem;

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
