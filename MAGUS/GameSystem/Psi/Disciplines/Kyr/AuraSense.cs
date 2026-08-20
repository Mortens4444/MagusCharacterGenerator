using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Kyr;

/// <summary>
/// Auraérzékelés (Kyr metódus, p.128-129). Lets the wizard perceive a creature's Személyes Aura —
/// recognizing a previously-seen soul in any body (even a swapped or possessed one), spotting an
/// unnatural soul/body mismatch, and identifying race. Base use only reveals the rough magnitude
/// of the target's Static/Dynamic Astral/Mental Pajzsok; seeing the deeper details (soul
/// recognition etc.) requires empowering it enough that the target fails both an Astral and a
/// Mental resistance roll (dual resistance; Astral modeled here since ISpell only has one
/// ResistanceType). The only discipline able to detect Tetszhalál and 4+-strength
/// Érzékelhetetlenség. Every extra Psi point beyond the base 7 doubles the discipline's strength.
/// </summary>
public sealed class AuraSense : IPsiDiscipline
{
    public string Name => "Aura sense";

    public int? Power => 1;

    public int PsiPointCost => 7;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
