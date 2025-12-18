using M.A.G.U.S.GameSystem.Turn;

namespace M.A.G.U.S.Assistant.ViewModels;

internal sealed class TurnViewModel
{
    public TurnViewModel(TurnData turn)
    {
        Turn = turn;
        Attacks = [.. turn.Initiatives.Select(initiative => initiative.AttackResolution).Select(attack => new TurnAttackViewModel(attack))];
    }

    public TurnData Turn { get; }

    public int RoundIndex => Turn.Round;

    public IReadOnlyList<TurnAttackViewModel> Attacks { get; }
}