using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Turn;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.ViewModels;

internal sealed class TurnAttackViewModel(int roundNumber, InitiativeEntry initiativeEntry)
{
    private readonly InitiativeEntry initiativeEntry = initiativeEntry;
    private readonly ResolutionBase attack = initiativeEntry.AttackOrAimResolution!;
    private readonly int roundNumber = roundNumber;

    public int RoundNumber => roundNumber;

    public int Initiative => initiativeEntry?.FinalInitiative ?? 0;

    public string Attacker => initiativeEntry?.Attacker?.Source is Character character ? character.Name : Lng.Elem(initiativeEntry?.Attacker?.Source?.Name ?? String.Empty);

    public string Direction => attack != null ? Lng.Elem(attack.Direction.GetDescription()) : String.Empty; // Should be in InitiateEntry?

    public int ActualHealthPoints => initiativeEntry?.Attacker.Source.ActualHealthPoints ?? 0;

    public int ActualPainTolerancePoints => initiativeEntry?.Attacker.Source.ActualPainTolerancePoints?? 0;

    public string HitLocation => attack != null ? String.IsNullOrEmpty(attack.HitSubLocation) ? Lng.Elem(attack.HitLocation) : $"{Lng.Elem(attack.HitLocation)} ({Lng.Elem(attack.HitSubLocation)})" : String.Empty;

    public string Result
    {
        get
        {
            if (attack == null)
            {
                return "🚶‍";
            }

            var isRanged = attack.Attack is RangedAttack;
            if (!attack.IsSuccessful)
            {
                return isRanged ? "🏹❌" : "🗡❌";
            }

            var impact = attack.Impact == AttackImpact.Normal ? String.Empty :
                attack.Impact == AttackImpact.CriticalDamage ? "⚝" : "☠️";
            var attackMode = isRanged ? "🏹" : "🗡";
            var isHpAttack = attack.IsHpDamage ? "🩸" : String.Empty;
            string damageKind = attack.IsHpDamage ? Lng.Elem("HP") : Lng.Elem("PTP");
            var target = isRanged ? "🎯" : "💥";

            return $"{attackMode}{isHpAttack}{impact} {attack.RollValue + attack.Attack.Value}{(attack.IsSuccessful ? $"{target}{attack.Damage}{damageKind}" : String.Empty)}";
        }
    }
}