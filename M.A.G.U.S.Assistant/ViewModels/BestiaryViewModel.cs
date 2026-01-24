using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models;
using Mtf.Extensions.Services;
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
        if (FilteredItems.Count == 0)
        {
            return;
        }

        var randomIndex = RandomProvider.GetSecureRandomInt(0, FilteredItems.Count);
        var randomCreature = FilteredItems[randomIndex];
        SelectedItem = randomCreature;
    }
}