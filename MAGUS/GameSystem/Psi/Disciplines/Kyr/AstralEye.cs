using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Kyr;

/// <summary>
/// Asztrálszem (Kyr metódus, p.127-128). Lets the wizard read a target's emotional life, seeing
/// through their Asztrál Pajzs. Always reveals the target's Astral score. On a successful Asztrális
/// Mágiaellenállás, only the most obvious emotions surface (without their target/cause); on a
/// failed resistance, both the emotions and what they're directed at become clear (up to 5
/// obvious, 3 average, or 1 hidden emotion per casting, or a quick scan of up to 10 nearby
/// creatures' Astral scores only). The subject never learns they were read. Every extra Psi point
/// beyond the base 3 doubles the discipline's strength instead of adding 1. Kyr-method disciplines
/// default to Erősség (Power) 1 per the book's own convention (comparable to a magic-mosaic's base
/// strength).
/// </summary>
public sealed class AstralEye : IPsiDiscipline
{
    public string Name => "Astral eye";

    public int? Power => 1;

    public int PsiPointCost => 3;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
