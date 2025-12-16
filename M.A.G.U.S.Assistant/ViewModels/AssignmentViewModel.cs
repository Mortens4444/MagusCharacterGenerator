using M.A.G.U.S.Bestiary;
using M.A.G.U.S.GameSystem;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal class AssignmentViewModel : BaseViewModel
{
    public AssignmentViewModel(Character character)
    {
        Character = character;
    }

    public Character Character { get; init; }

    public ObservableCollection<Creature> Enemies { get; } = [];

    public double EstimatedTime => 0;
        //Enemies.Count == 0
        //    ? 0
        //    : Enemies.Min(e => e.Distance / Character.Speed);

    public ICommand AssignEnemyCommand { get; }
}
