using MAGUS.Classes.Sorcerer;
using MAGUS.Enums;
using MAGUS.Extensions;
using MAGUS.GameSystem.Psi;
using MAGUS.GameSystem.Psi.Disciplines.Kyr;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications.Scientific;
using MAGUS.Things;
using MAGUS.Things.Gemstones;
using MAGUS.Things.MagicalObjects;
using MAGUS.Things.Weapons;

namespace MAGUS.GameSystem;

public partial class Character
{
    /// <summary>
    /// True for a Thing that is, or ultimately wraps, a Weapon - a plain Weapon, a GemstoneWeapon or
    /// RuneObject built around one, or a chain of both (e.g. a GemstoneWeapon crafted from an already
    /// rune-inscribed RuneSword, or vice versa). The book doesn't forbid combining Rúnamágia and
    /// Drágakőmágia on the same item - both TryCraftGemstoneWeapon and TryCraftRuneWeapon accept
    /// anything this returns true for as their target, so either can be layered on top of the other.
    /// RuneObject also covers non-weapon items (e.g. RuneArmor), which this correctly excludes since
    /// their TargetItem doesn't resolve to a Weapon.
    /// </summary>
    public static bool WrapsAWeapon(Thing thing) => thing switch
    {
        Weapon => true,
        GemstoneWeapon gemstoneWeapon => WrapsAWeapon(gemstoneWeapon.TargetItem),
        RuneObject runeObject => WrapsAWeapon(runeObject.TargetItem),
        _ => false
    };

    /// <summary>
    /// Whether this character currently qualifies to craft a Drágakőmágia-based magic item at all
    /// (Első Törvénykönyv, "Drágakőmágia": "Drágakőmágián alapuló varázstárgyat csak az a varázsló
    /// kasztú karakter készítheti, aki Mesterfokon jártas az azonos nevű képzettségben."). Master
    /// Gemstone magic - there's no Base level for it ("Alapfokú alkalmazása nem ismeretes") - plus
    /// being one of the wizard-caste classes GemstoneWeapon actually allows (via the MagicalObject
    /// default: Wizard, KrannishWarlock). Doesn't check the Trance prerequisite (see
    /// TryCraftGemstoneWeapon) since that's specific to the transmutation step, not to holding the
    /// qualification itself.
    /// </summary>
    public bool CanCraftGemstoneMagicItems =>
        BaseClass is Wizard or KrannishWarlock &&
        Qualifications.OfType<GemstoneMagic>().Any(q => q.QualificationLevel == QualificationLevel.Master);

    /// <summary>
    /// Sets a drágakő (gemstone) into a weapon's hilt (Első Törvénykönyv, "Drágakőmágiával készített
    /// varázstárgyak - Felruházás": "A markolat bármilyen fegyver markolata lehet; a belefoglalt
    /// drágakő csak akkor fejti ki hatását, ha a fegyvert kézben tartják."). <paramref name="item"/>
    /// can be a plain Weapon or an already-crafted GemstoneWeapon/RuneSword that wraps one (see
    /// WrapsAWeapon) - nothing here forbids layering this on top of an already rune-inscribed weapon.
    /// Both item and gemstone must already be owned - they're consumed into the new GemstoneWeapon.
    ///
    /// Two Mana costs, paid together: transmutation (Átlényegítés) turns the mundane gemstone
    /// magic-capable - a fixed cost depending on which of the three effect kinds is chosen
    /// (effectType.TransmutationManaCost: 50/80/100 Mp for Detekció/Védelem/Okozás) - and it
    /// "kizárólag transzban (lásd Pszi - Transz diszciplína) végezhető". The only Trance discipline
    /// modeled so far is KyrTrance (Kyr módszer, p.126), so this is currently a Kyr-Psi-specific
    /// prerequisite - other methods' equivalent isn't sourced yet (mirrors PsiDisciplineCatalog's own
    /// note about per-school gaps). Then charging (Erősítés) invests manaPoints into the stone (1 Mp =
    /// 1 E of effect strength, "A drágakőbe töltött minden egyes Mana-pont 1 E-vel növeli..."), capped
    /// only at however much Mana remains after transmutation - the book's other cap (the stone's carat
    /// size) isn't tracked as a stat here.
    ///
    /// Clears PrimaryWeapon/SecondaryWeapon if either pointed at the consumed item (only possible when
    /// item is itself a plain Weapon - a GemstoneWeapon/RuneSword can never have been equipped there
    /// in the first place), since it no longer exists as a separate Equipment entry once it's wrapped
    /// into the GemstoneWeapon.
    /// </summary>
    public bool TryCraftGemstoneWeapon(Thing item, Gemstone gemstone, MagicItemEffectType effectType, int manaPoints, out GemstoneWeapon? crafted)
    {
        crafted = null;

        if (!CanCraftGemstoneMagicItems || !WrapsAWeapon(item) || !Equipment.Contains(item) || !Equipment.Contains(gemstone))
        {
            return false;
        }

        if (manaPoints <= 0)
        {
            return false;
        }

        if (!PsiDisciplineCatalog.GetAvailable(this).Any(d => d is KyrTrance))
        {
            return false;
        }

        var totalManaCost = effectType.TransmutationManaCost() + manaPoints;
        if (totalManaCost > ManaPoints)
        {
            return false;
        }

        crafted = new GemstoneWeapon { TargetItem = item, Gemstone = gemstone, EffectType = effectType, InvestedManaPoints = manaPoints };

        ManaPoints -= totalManaCost;
        RemoveEquipment(item);
        RemoveEquipment(gemstone);
        AddEquipment(crafted);

        if (PrimaryWeapon == item)
        {
            PrimaryWeapon = null;
        }

        if (SecondaryWeapon == item)
        {
            SecondaryWeapon = null;
        }

        return true;
    }

    /// <summary>
    /// Mana-point tiers RuneSword's catalog already comes in (RuneSword63Mp, 93Mp, 123Mp, 153Mp) - the
    /// same fixed steps TryCraftRuneWeapon lets a player choose between, since the book gives named
    /// rune items their own fixed Mp cost rather than a freely chosen effect strength (contrast
    /// Drágakőmágia's per-E charging).
    /// </summary>
    public static readonly IReadOnlyList<int> RuneWeaponManaTiers = [63, 93, 123, 153];

    /// <summary>
    /// Whether this character currently qualifies to craft a Rúnamágia-based magic item at all (Első
    /// Törvénykönyv, "Rúnamágia": Mesterfokon "a karakter varázstárgyakat alkothat" - Base level only
    /// lets them read runes others already wrote, not inscribe new ones). Same wizard-caste
    /// restriction as CanCraftGemstoneMagicItems (RuneSword's AllowedCreators default: Wizard,
    /// KrannishWarlock).
    /// </summary>
    public bool CanCraftRuneMagicItems =>
        BaseClass is Wizard or KrannishWarlock &&
        Qualifications.OfType<RunicMagic>().Any(q => q.QualificationLevel == QualificationLevel.Master);

    /// <summary>
    /// Inscribes runes into a weapon's hilt (Első Törvénykönyv, "Rúnamágia" - a Jelmágia alfejezete,
    /// ahol "a mágikus hatásokat a rúnák tárolják"), producing one of the fixed RuneSword tiers
    /// (RuneWeaponManaTiers) instead of a freely chosen effect strength - see TryCraftGemstoneWeapon
    /// for the other creation method, which lets the strength be chosen instead.
    /// <paramref name="item"/> can be a plain Weapon or an already-crafted GemstoneWeapon/RuneSword
    /// that wraps one (see WrapsAWeapon) - nothing here forbids layering this on top of an already
    /// gemstone-set weapon. It must already be owned; it's consumed into the returned RuneSword.
    /// Clears PrimaryWeapon/SecondaryWeapon if either pointed at the consumed item (only possible when
    /// item is itself a plain Weapon), since it no longer exists as a separate Equipment entry once
    /// it's wrapped into the RuneSword.
    /// </summary>
    public bool TryCraftRuneWeapon(Thing item, int manaPoints, out RuneSword? crafted)
    {
        crafted = null;

        if (!CanCraftRuneMagicItems || !WrapsAWeapon(item) || !Equipment.Contains(item) || manaPoints > ManaPoints)
        {
            return false;
        }

        crafted = manaPoints switch
        {
            63 => new RuneSword63Mp { TargetItem = item },
            93 => new RuneSword93Mp { TargetItem = item },
            123 => new RuneSword123Mp { TargetItem = item },
            153 => new RuneSword153Mp { TargetItem = item },
            _ => null
        };

        if (crafted == null)
        {
            return false;
        }

        ManaPoints -= manaPoints;
        RemoveEquipment(item);
        AddEquipment(crafted);

        if (PrimaryWeapon == item)
        {
            PrimaryWeapon = null;
        }

        if (SecondaryWeapon == item)
        {
            SecondaryWeapon = null;
        }

        return true;
    }
}
