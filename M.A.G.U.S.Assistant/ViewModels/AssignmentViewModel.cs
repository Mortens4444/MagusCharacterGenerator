using M.A.G.U.S.Bestiary;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Turn;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal class AssignmentViewModel : BaseViewModel
{
    public AssignmentViewModel(Character character)
    {
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
        TurnHistory.Add(new TurnViewModel(turn));
    }
}
