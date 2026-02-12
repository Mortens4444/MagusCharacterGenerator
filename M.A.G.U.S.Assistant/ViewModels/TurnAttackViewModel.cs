using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Turn;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.ViewModels;

internal sealed class TurnAttackViewModel
{
    private readonly InitiativeEntry initiativeEntry;
    private readonly ResolutionBase attack;
    private readonly int roundNumber;

    public TurnAttackViewModel(int roundNumber, InitiativeEntry initiativeEntry)
    {
        this.roundNumber = roundNumber;
        this.initiativeEntry = initiativeEntry;
        attack = initiativeEntry.AttackOrAimResolution!;
    }

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

            var impact = attack.Impact == M.A.G.U.S.Enums.AttackImpact.Normal ? String.Empty :
                attack.Impact == M.A.G.U.S.Enums.AttackImpact.Critical ? "⚝" : "☠️";
            var attackMode = isRanged ? "🏹" : "🗡";
            var isHpAttack = attack.IsHpDamage ? "🩸" : String.Empty;
            var target = isRanged ? "🎯" : "💥";

            return $"{attackMode}{isHpAttack}{impact} {attack.RollValue + attack.Attack.Value}{(attack.IsSuccessful ? $"{target}{attack.Damage}" : String.Empty)}";
        }
    }
}