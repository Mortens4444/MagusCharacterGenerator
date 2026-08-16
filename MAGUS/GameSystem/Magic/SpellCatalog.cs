using MAGUS.Enums;
using MAGUS.Extensions;
using MAGUS.GameSystem.Magic.Spells.Fire;
using MAGUS.GameSystem.Magic.Spells.Mosaic;
using MAGUS.GameSystem.Magic.Spells.Other;
using MAGUS.GameSystem.Magic.Spells.Priest;
using MAGUS.GameSystem.Magic.Spells.Witch;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic;

public static class SpellCatalog
{
    public static readonly IReadOnlyList<ISpell> All =
    [
        new MagicMissile(),
        new FireArrow(MagicSchool.Mosaic), // Wizards shoot fire arrows too, alongside their magic missile.
        new Fireball(),
        new FireArrow(),
        new WitchsCurse(),
        new LightningBolt(),
        new LightningBolt(MagicSchool.Warlock),
        new SmiteUnbeliever(),
        new ArcaneBolt(),

        // Priest spells shared by all spheres (Kis Arkánum Litániái/Rituálói).
        new WordOfPower(),
        new Blessing(),
        new HolyLight(),
        new DetectMagicPower(),
        new DispelMagic(),
        new Ceremony(),
        new Asceticism(),

        // Priest spells gated to specific spheres (Szférikus varázslatok).
        new AstralGlimpse(),
        new Punishment(),
        new Strike(),
        new Silence(),
        new CreateFood()
    ];

    public static IEnumerable<ISpell> GetAvailable(Character character)
    {
        if (character.Sorcery == null)
        {
            return [];
        }

        var schoolMatches = All.Where(spell => spell.School == character.Sorcery.School);

        if (character.Sorcery.School != MagicSchool.Priest)
        {
            return schoolMatches;
        }

        // Priest spells are additionally gated by the character's deity: a priest only gets a
        // sphere-tagged spell if their god grants at least one of that spell's spheres.
        var knownSpheres = character.Deity.GetAvailableSpheres();
        return schoolMatches.Where(spell => spell.Spheres.Intersect(knownSpheres).Any());
    }
}
