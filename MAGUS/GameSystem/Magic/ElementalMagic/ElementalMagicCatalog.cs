using MAGUS.GameSystem.Magic.ElementalMagic.CreationMosaics;
using MAGUS.GameSystem.Magic.ElementalMagic.Forms;

namespace MAGUS.GameSystem.Magic.ElementalMagic;

/// <summary>
/// Every building block of Elemi Mágia (Elemental Magic), for a future UI to let a wizard
/// combine an element-creation mosaic with a form. Mirrors the pattern used by
/// <see cref="SpellCatalog"/> and <see cref="Psi.PsiDisciplineCatalog"/>.
/// </summary>
public static class ElementalMagicCatalog
{
    public static readonly IReadOnlyList<IElementCreationMosaic> CreationMosaics =
    [
        new PrimalElementCreation(),
        new HeatCreation(),
        new FrostCreation(),
        new LightCreation(),
        new DarknessCreation(),
        new ElementalForceCreation()
    ];

    public static readonly IReadOnlyList<IMosaicForm> Forms =
    [
        new Arrow(),
        new Sword(),
        new Burst(),
        new Carpet(),
        new Wall(),
        new Aura(),
        new Shower(),
        new Dome(),
        new Tent(),
        new Jet()
    ];
}
