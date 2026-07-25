using M.A.G.U.S.GameSystem.Magic.Spells.Fire;
using M.A.G.U.S.GameSystem.Magic.Spells.Mosaic;
using M.A.G.U.S.GameSystem.Magic.Spells.Other;
using M.A.G.U.S.GameSystem.Magic.Spells.Priest;
using M.A.G.U.S.GameSystem.Magic.Spells.Witch;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.GameSystem.Magic;

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
