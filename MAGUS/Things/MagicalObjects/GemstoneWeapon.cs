using MAGUS.Enums;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;
using MAGUS.Things.Gemstones;

namespace MAGUS.Things.MagicalObjects;

/// <summary>
/// A weapon with a gemstone set into its hilt (Első Törvénykönyv, "Drágakőmágiával készített
/// varázstárgyak - Felruházás": "A markolat bármilyen fegyver markolata lehet; a belefoglalt drágakő
/// csak akkor fejti ki hatását, ha a fegyvert kézben tartják."). Unlike RuneSword's fixed catalog
/// entries (RuneSword63Mp, ...), this is built at crafting time (Character.TryCraftGemstoneWeapon):
/// first transmutation (Átlényegítés) turns the gemstone magic-capable (a fixed Mana cost depending
/// on EffectType - see MagicItemEffectTypeExtensions.TransmutationManaCost), then it's charged with however many Mana
/// points the wizard invests beyond that - 1 Mp = 1 E of effect strength, per "A drágakőbe töltött
/// minden egyes Mana-pont 1 E-vel növeli a benne tárolt mágikus hatás erősségét". The book leaves the
/// exact mechanical translation of most gemstones' effect to the creator ("Minden esetben a pontos
/// hatást a tárgy készítője határozza meg."), so this only tracks which stone, which of the three
/// effect kinds, and how strong (see Gemstone.Description for the flavor/domain it grants - e.g.
/// Tourmaline is "combat, protection" - not a hardcoded combat stat bonus).
///
/// TargetItem is Thing (like RuneObject's), not Weapon - the book doesn't forbid combining Rúnamágia
/// and Drágakőmágia on the same item, so this can wrap a plain Weapon or an already rune-inscribed
/// RuneSword (see Character.WrapsAWeapon, which both crafting methods check against).
///
/// INotForSale, and TargetItem/Gemstone are null-conditioned below (matching RuneObject.Price's own
/// TargetItem?.Price ?? new(0) pattern) because PreloadService.LoadMagicalObjectsAsync reflects over
/// every concrete MagicalObject in this namespace and instantiates each with its parameterless
/// constructor to build the "Magic items" reference catalog (MagicalObjectsPage) - unlike RuneSword's
/// fixed, nameable recipes (e.g. "Rune Sword (63 MP)"), a bare GemstoneWeapon has no TargetItem or
/// Gemstone yet (only TryCraftGemstoneWeapon ever sets those), so it isn't a fixed recipe worth
/// listing there in the first place, and touching Name/Description/Price on that bare instance was
/// throwing a NullReferenceException.
/// </summary>
public class GemstoneWeapon : MagicalObject, INotForSale
{
    public Thing TargetItem { get; set; }

    public Gemstone Gemstone { get; set; }

    public MagicItemEffectType EffectType { get; set; }

    /// <summary>Mana points invested in charging (Erősítés), beyond the Átlényegítés cost already spent when crafted - see Character.TryCraftGemstoneWeapon. MagicalObject.ManaPoints is get-only, so the actual value lives here.</summary>
    public int InvestedManaPoints { get; set; }

    public override int ManaPoints => InvestedManaPoints;

    public override string Name => TargetItem != null && Gemstone != null
        ? $"{TargetItem.Name} ({Gemstone.Name})"
        : base.Name;

    public override string Description => TargetItem != null && Gemstone != null
        ? $"{TargetItem.Description} A {Gemstone.Name} is set into the hilt for {EffectType} ({Gemstone.Description}), charged to strength {ManaPoints}."
        : String.Empty;

    public override double Weight => TargetItem?.Weight ?? 0;

    public override Money Price => Money.DoubleIt(TargetItem?.Price ?? new(0)) + (Gemstone?.Price ?? new(0));
}
