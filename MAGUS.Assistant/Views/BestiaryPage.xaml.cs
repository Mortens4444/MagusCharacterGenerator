using CommunityToolkit.Mvvm.Messaging;
using MAGUS.Assistant.Models;
using MAGUS.Assistant.Services;
using MAGUS.Assistant.ViewModels;
using MAGUS.Interfaces;
using Mtf.LanguageService.MAUI.Views;
using Mtf.Maui.Controls.Messages;

namespace MAGUS.Assistant.Views;

internal sealed partial class BestiaryPage : NotifierPage
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

        // Unloaded (not OnDisappearing) fires only once the page is actually removed from the
        // navigation stack, not when merely covered by a modal (e.g. a creature details page
        // pushed on top) - see EncounterPage.OnAppearing for why OnDisappearing can't be trusted
        // for this.
        Unloaded += (_, _) => this.viewModel.Dispose();
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
                vm.SelectedBestiaryCategory = vm.BestiaryCategories[0];
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