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
        new Fireball(),
        new WitchsCurse(),
        new SmiteUnbeliever(),
        new ArcaneBolt()
    ];

    public static IEnumerable<ISpell> GetAvailable(Character character) =>
        character.Sorcery == null ? [] : All.Where(spell => spell.School == character.Sorcery.School);
}
