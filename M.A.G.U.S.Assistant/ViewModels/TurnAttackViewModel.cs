using M.A.G.U.S.GameSystem.Turn;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.ViewModels;

internal sealed class TurnAttackViewModel
{
    private readonly AttackResolution attack;

    public TurnAttackViewModel(AttackResolution attack)
    {
        this.attack = attack;
    }

    public string HitLocation => String.IsNullOrEmpty(attack.HitSubLocation) ? attack.HitLocation.ToString() : $"{attack.HitLocation} ({attack.HitSubLocation})";

    public string Result => attack.IsSuccessful ? $"{Lng.Elem("Hit")} ({attack.AttackRoll})" : attack.Impact.ToString();
}