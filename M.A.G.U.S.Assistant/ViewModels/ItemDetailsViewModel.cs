using CommunityToolkit.Mvvm.ComponentModel;
using M.A.G.U.S.Assistant.CustomEventArgs;
using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Things;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class ItemDetailsViewModel : ObservableObject
{
    public Thing Thing { get; private set; }

    public ItemDetailsViewModel(Character? character, Thing thing)
    {
        Thing = thing;
        IsBuyButtonVisible = character != null && character.Money >= thing.Price;

        Name = thing.Name;
        Description = thing.Description;
        Money = thing.Price.ToTranslatedString();
        Weight = thing.Weight;
        ImageName = thing.ImageName;

        BuyCommand = new RelayCommand(_ =>  OnPurchased(Thing));
    }

    public bool IsBuyButtonVisible { get; init; }
    public string Name { get; } = String.Empty;
    public string Description { get; } = String.Empty;
    public string ImageName { get; } = String.Empty;
    public string Money { get; } = String.Empty;
    public double Weight { get; }

    public ICommand BuyCommand { get; } = new RelayCommand(_ => { });

    public event EventHandler<ThingPurchasedEventArgs>? Purchased;
    public event EventHandler? Closed;

    protected virtual void OnPurchased(Thing thing)
    {
        Purchased?.Invoke(this, new ThingPurchasedEventArgs(thing));
    }

    protected virtual void OnClosed()
    {
        Closed?.Invoke(this, EventArgs.Empty);
    }
}
