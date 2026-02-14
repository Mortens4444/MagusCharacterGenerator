using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Extensions;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class BestiaryViewModel : SearchListViewModel, IDisposable
{
    private readonly IShakeService? shakeService;

    public IShakeService? ShakeService => shakeService;

    public ICommand PickRandomCommand { get; }

    public BestiaryViewModel(ISoundPlayer soundPlayer, IShakeService shakeService) : base(soundPlayer)
    {
        this.shakeService = shakeService;
        if (shakeService != null)
        {
            shakeService.ShakeDetected += OnShakeDetected;
        }
        PickRandomCommand = new RelayCommand(_ => PickRandomCreature());
    }

    private void PickRandomCreature()
    {
        SelectedItem = EnemyProvider.PickWeightedRandom(FilteredItems,
            c => (c.Source as Creature)?.Occurrence.GetWeight() ?? 0);
    }

    private void OnShakeDetected(object? sender, EventArgs e)
    {
        CommandExecutor.ExecuteOnUIThread(TriggerActionFromShake);
    }

    public void TriggerActionFromShake()
    {
        PickRandomCreature();
    }

    public void Dispose()
    {
        if (shakeService != null)
        {
            shakeService.ShakeDetected -= OnShakeDetected;
        }
    }
}