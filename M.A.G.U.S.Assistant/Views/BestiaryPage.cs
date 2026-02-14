using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.Interfaces;
using Mtf.Maui.Controls.Messages;

namespace M.A.G.U.S.Assistant.Views;

internal partial class BestiaryPage : SearchListPage
{
    private bool firstLoad = true;
    private BestiaryViewModel viewModel;
    private readonly ISettings settings;

    public BestiaryPage(BestiaryViewModel viewModel, ISettings settings)
        : base(viewModel, false, "Bestiary",
          PreloadService.Instance.Creatures.Select(DisplayItem.FromObject))
    {
        this.settings = settings;
        this.viewModel = viewModel;
        var randomToolbarItem = new ToolbarItem
        {
            //IconImageSource = "beast.png",
            Text = "🎲", //Lng.Elem("Random"),
            Order = ToolbarItemOrder.Primary,
            Priority = 0
        };

        randomToolbarItem.SetBinding(MenuItem.CommandProperty, nameof(BestiaryViewModel.PickRandomCommand));
        ToolbarItems.Add(randomToolbarItem);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //Translator.Translate(this);
        try
        {
            viewModel.ShakeService?.Start();
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
        if (BindingContext is BestiaryViewModel vm)
        {
            if (firstLoad && settings.ShowRandomBeastWhenBestiaryPageOpened)
            {
                firstLoad = false;
                _ = Task.Run(async () =>
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        vm.PickRandomCommand.Execute(null);
                    });
                });
            }
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        try
        {
            viewModel.ShakeService?.Stop();
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }
}