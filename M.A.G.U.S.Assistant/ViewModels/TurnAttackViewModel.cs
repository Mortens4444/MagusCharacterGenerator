using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Turn;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;
using System.Globalization;

namespace M.A.G.U.S.Assistant.ViewModels;

internal sealed class TurnAttackViewModel
{
    private readonly InitiativeEntry initiativeEntry;
    private readonly AttackResolution attack;
    private readonly int roundNumber;

    public TurnAttackViewModel(int roundNumber, InitiativeEntry initiativeEntry)
    {
        this.roundNumber = roundNumber;
        this.initiativeEntry = initiativeEntry;
        attack = initiativeEntry.AttackResolution!;
    }

    public int RoundNumber => roundNumber;

    public int Initiative => initiativeEntry?.FinalInitiative ?? 0;

    public string Attacker => initiativeEntry?.Attacker?.Source is Character character ? character.Name : Lng.Elem(initiativeEntry?.Attacker?.Source?.Name ?? String.Empty);

    public string Direction => Lng.Elem(attack.Direction.GetDescription());

    public string HitLocation => String.IsNullOrEmpty(attack.HitSubLocation) ? Lng.Elem(attack.HitLocation) : $"{Lng.Elem(attack.HitLocation)} ({Lng.Elem(attack.HitSubLocation)})";

    public string Result
    {
        get
        {
            var attackText = $"{Lng.Elem("Hit")} ({attack.AttackRoll} + {attack.Attack.Value} = {attack.AttackRoll + attack.Attack.Value})";
            return attack.IsSuccessful ?
                attack.Impact == M.A.G.U.S.Enums.AttackImpact.Normal ? attackText : $"{Lng.Elem(attack.Impact.ToString())} {attackText.ToLower(CultureInfo.CurrentCulture)}" :
                Lng.Elem("Unsuccessful attack");
        }
    }
}