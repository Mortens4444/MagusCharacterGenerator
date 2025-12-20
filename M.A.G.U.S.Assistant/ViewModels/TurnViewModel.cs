using M.A.G.U.S.GameSystem.Turn;

namespace M.A.G.U.S.Assistant.ViewModels;

internal sealed class TurnViewModel
{
    public TurnViewModel(TurnData turn)
    {
        Turn = turn;
        Attacks = [.. turn.Initiatives.Select(initiative => new TurnAttackViewModel(Turn.Round, initiative))];
    }

    public TurnData Turn { get; }

    public IReadOnlyList<TurnAttackViewModel> Attacks { get; }
}