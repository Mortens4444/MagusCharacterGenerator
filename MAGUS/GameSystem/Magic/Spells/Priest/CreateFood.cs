using MAGUS.Enums;
using MAGUS.Interfaces;
using MAGUS.Things.Food;

namespace MAGUS.GameSystem.Magic.Spells.Priest;

/// <summary>
/// Élelemteremtés (Szférikus — Élet, Természet). Conjures food/drink enough for 3 people or one
/// horse-sized creature - modeled as a single ready-to-eat meal (LunchDinner, HungerValue 100) added
/// to the target's Equipment, same "self or another saved character" target picker as any other spell
/// (CharacterViewModel.CastSpellAsync), letting a priest feed a starving companion as well as
/// themselves. Deals no damage; only OnHit does anything.
/// </summary>
public sealed class CreateFood : ISpell
{
    public string Name => "Create food";

    public MagicSchool School => MagicSchool.Priest;

    public Sphere[] Spheres => [Sphere.Life, Sphere.Nature];

    public int? Power => 5;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 999;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        if (target is Character character)
        {
            character.Equipment.Add(new LunchDinner());
        }
    }
}
