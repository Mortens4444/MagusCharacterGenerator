using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

internal partial class BestiaryPage : SearchListPage
{
    private bool firstLoad = true;

    public BestiaryPage(BestiaryViewModel viewModel)
        : base(viewModel, false, "Bestiary",
          PreloadService.Instance.Creatures.Select(DisplayItem.FromObject))
    {
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
        if (BindingContext is BestiaryViewModel vm)
        {
            if (firstLoad)
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
}