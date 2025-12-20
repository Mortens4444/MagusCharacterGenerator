using M.A.G.U.S.Bestiary;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Turn;
using M.A.G.U.S.Interfaces;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal class AssignmentViewModel : BaseViewModel
{
    private readonly ISettings settings;

    public AssignmentViewModel(ISettings settings, Character character)
    {
        this.settings = settings;
        Character = character;
    }

    public Character Character { get; init; }

    public ObservableCollection<TurnViewModel> TurnHistory { get; } = [];

    public ObservableCollection<Creature> Enemies { get; } = [];

    public double EstimatedTime => 0;
    //Enemies.Count == 0
    //    ? 0
    //    : Enemies.Min(e => e.Distance / Character.Speed);

    public void AddTurn(TurnData turn)
    {
        var turnViewModel = new TurnViewModel(turn);
        if (settings.AssignmentTurnHistoryNewestOnTop)
        {
            TurnHistory.Insert(0, turnViewModel);
        }
        else
        {
            TurnHistory.Add(turnViewModel);
        }
    }
}
