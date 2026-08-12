using MAGUS.GameSystem.Turn;

namespace MAGUS.Assistant.ViewModels;

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