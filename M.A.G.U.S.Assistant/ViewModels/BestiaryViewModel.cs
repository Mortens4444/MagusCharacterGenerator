using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Extensions;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class BestiaryViewModel : SearchListViewModel
{
    public ICommand PickRandomCommand { get; }

    public BestiaryViewModel(ISoundPlayer soundPlayer) : base(soundPlayer)
    {
        PickRandomCommand = new RelayCommand(_ => PickRandomCreature());
    }

    private void PickRandomCreature()
    {
        SelectedItem = EnemyProvider.PickWeightedRandom(FilteredItems,
            c => (c.Source as Creature)?.Occurrence.GetWeight() ?? 0);
    }
}