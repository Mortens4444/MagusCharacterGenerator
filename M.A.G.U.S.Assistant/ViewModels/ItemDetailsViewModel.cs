using CommunityToolkit.Mvvm.ComponentModel;
using M.A.G.U.S.Assistant.CustomEventArgs;
using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Things;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class ItemDetailsViewModel : ObservableObject
{
    private readonly Thing? thing;

    public ItemDetailsViewModel() { }

    public ItemDetailsViewModel(Thing thing)
    {
        this.thing = thing ?? throw new ArgumentNullException(nameof(thing));

        Name = thing.Name;
        Description = thing.Description;
        Money = thing.Price.ToTranslatedString();
        Weight = thing.Weight;
        ImageName = thing.ImageName;

        BuyCommand = new RelayCommand(_ => OnBuy());
    }

    public string Name { get; } = String.Empty;
    public string Description { get; } = String.Empty;
    public string ImageName { get; } = String.Empty;
    public string ImageName2 { get; } = String.Empty;
    public string Money { get; } = String.Empty;
    public double Weight { get; }
    public ImageSource? ImageSource { get; }
    public ImageSource? ImageSource2 { get; }

    public ICommand BuyCommand { get; } = new RelayCommand(_ => { });

    public event EventHandler<ThingPurchasedEventArgs>? Purchased;
    public event EventHandler? Closed;

    protected virtual void OnPurchased(Thing t)
    {
        Purchased?.Invoke(this, new ThingPurchasedEventArgs(t));
    }

    protected virtual void OnClosed()
    {
        Closed?.Invoke(this, EventArgs.Empty);
    }

    private void OnBuy()
    {
        if (thing == null)
        {
            return;
        }

        OnPurchased(thing);
    }
}
