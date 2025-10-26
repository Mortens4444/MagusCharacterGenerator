﻿using CommunityToolkit.Mvvm.ComponentModel;
using M.A.G.U.S.Assistant.CustomEventArgs;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Things;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal class ItemDetailsViewModel : ObservableObject
{
    private readonly Thing? thing;

    public ItemDetailsViewModel() { }

    public ItemDetailsViewModel(Thing thing)
    {
        this.thing = thing ?? throw new ArgumentNullException(nameof(thing));

        Name = thing.Name;
        Description = thing.Description ?? String.Empty;
        Money = thing.Price;
        Weight = thing.Weight;
        ImageSource = ImageSourceFromName(thing.ImageName);

        BuyCommand = new RelayCommand(_ => OnBuy());
        CloseCommand = new RelayCommand(_ => OnClose());
    }

    public string Name { get; } = String.Empty;
    public string Description { get; } = String.Empty;
    public Money Money { get; } = default!;
    public double Weight { get; }
    public ImageSource? ImageSource { get; }

    public ICommand BuyCommand { get; } = new RelayCommand(_ => { });
    public ICommand CloseCommand { get; } = new RelayCommand(_ => { });

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

    private void OnClose()
    {
        OnClosed();
    }

    private static ImageSource? ImageSourceFromName(string? imageName)
    {
        try
        {
            if (String.IsNullOrEmpty(imageName))
            {
                return null;
            }

            return ImageSource.FromResource(imageName, typeof(ItemDetailsViewModel).Assembly);
        }
        catch
        {
            return null;
        }
    }
}
