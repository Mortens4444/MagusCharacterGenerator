using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Csúfítás (Sámán — Zotgejt/Vérszimpatikus mágia, Második Törvénykönyv p.134). Cutting a Zotgejt
/// puppet (a wax/rag effigy built from the victim's hair, blood or other bodily remnants, see
/// Zotgejt - bábu - készítése) with a blade opens a matching wound on the real victim, dealing
/// 2D6 FP and leaving a scar that never heals naturally, even face-disfiguring if cut there. Only
/// works on a completed, named Zotgejt puppet - that ritual itself is not separately modeled.
/// </summary>
public sealed class PuppetDisfigurement : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Puppet disfigurement";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 25;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._2D6)]
    public int GetDamage() => diceThrow._2D6();
}
