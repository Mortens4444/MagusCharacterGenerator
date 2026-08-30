using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem.Places;

namespace MAGUS.GameSystem;

public partial class Character
{
    /// <summary>
    /// Mana cost of TryOpenWizardPortal - Térkapu (a Varázsló/Térmágia mosaic spell), Első
    /// Törvénykönyv p.327 summary table: 68 Mp, 1 kör (round) to cast, stays open ~3 minutes. The
    /// book also restricts the destination to the caster's own Zóna, a 20-láb radius around a placed
    /// Zóna Varázsjele, or somewhere reachable by Távolbahatás (i.e. a place the wizard can actually
    /// see) - none of that Zone/scrying model exists in this app, so as a simplified stand-in this
    /// only checks the caster's class and mana; the destination can be any known city, the same way
    /// CharacterViewModel.OpenPortalAsync's unrelated flat-gold portal already works.
    /// </summary>
    public const int WizardPortalManaCost = 68;

    /// <summary>True if this character could cast Térkapu right now - must be a Wizard with enough mana. See WizardPortalManaCost's remarks for what's simplified away from the book rule.</summary>
    public bool CanOpenWizardPortal => BaseClass is Wizard && Sorcery != null && ManaPoints >= WizardPortalManaCost;

    /// <summary>Casts Térkapu: spends WizardPortalManaCost mana and instantly moves this character to destination. See CanOpenWizardPortal for the gating.</summary>
    public bool TryOpenWizardPortal(City destination)
    {
        if (!CanOpenWizardPortal)
        {
            return false;
        }

        ManaPoints -= WizardPortalManaCost;
        CurrentLocation = destination;
        Position = CityCoordinates.GetPosition(destination);
        return true;
    }
}
