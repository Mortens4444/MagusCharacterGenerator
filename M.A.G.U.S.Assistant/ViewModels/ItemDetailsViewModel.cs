using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        IsBuyButtonVisible = character != null && character.Money >= thing.MultipliedPrice;

        Name = thing.Name;
        Description = thing.Description;
        Money = thing.MultipliedPrice.ToTranslatedString();
        Weight = thing.Weight;
        ImageName = thing.ImageName;

        BuyCommand = new RelayCommand(() =>  OnPurchased(Thing));
        CloseCommand = new RelayCommand(() => OnClosed());
    }

    public bool IsBuyButtonVisible { get; init; }
    public string Name { get; } = String.Empty;
    public string Description { get; } = String.Empty;
    public string ImageName { get; } = String.Empty;
    public string Money { get; } = String.Empty;
    public double Weight { get; }

    public ICommand BuyCommand { get; }
    public ICommand CloseCommand { get; }

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
