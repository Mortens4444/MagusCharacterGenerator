using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.Interfaces;
using Mtf.LanguageService.MAUI.Views;
using Mtf.Maui.Controls.Messages;

namespace M.A.G.U.S.Assistant.Views;

internal partial class BestiaryPage : NotifierPage
{
    private bool firstLoad = true;
    private readonly BestiaryViewModel viewModel;
    private readonly ISettings settings;

    public BestiaryPage(BestiaryViewModel viewModel, ISettings settings)
	{
		InitializeComponent();
		BindingContext = viewModel;
		
		viewModel.LoadItems(PreloadService.Instance.Creatures.Select(DisplayItem.FromObject));

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
        if (firstLoad)
        {
            firstLoad = false;

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
                if (settings.ShowRandomBeastWhenBestiaryPageOpened)
                {
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