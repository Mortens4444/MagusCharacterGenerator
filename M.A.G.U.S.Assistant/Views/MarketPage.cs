using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.CustomEventArgs;
using M.A.G.U.S.Assistant.Messages;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Things;
using Mtf.Extensions;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Views;

internal partial class MarketPage : SearchListPage
{
    public MarketPage(SearchListViewModel viewModel)
        : base(viewModel,
            "Market",
            "M.A.G.U.S.Things".CreateInstancesFromNamespace<Thing>().OrderBy(r => Lng.Elem(r.Name)).Select(r => DisplayItem.FromThing(r, null)))
    {
    }

    public MarketPage(SearchListViewModel viewModel, Character character)
        : base(viewModel,
            $"{Lng.Elem("Market")} - {character.Name}",
            "M.A.G.U.S.Things"
                .CreateInstancesFromNamespace<Thing>()
                .OrderBy(r => Lng.Elem(r.Name))
                .Select(r => DisplayItem.FromThing(r, character)))
    {
        viewModel.Character = character;
    }

    protected override void OnDetailsClicked(object sender, EventArgs e)
    {
        try
        {
            var selected = ViewModel?.SelectedItem;
            if (selected == null)
            {
                WeakReferenceMessenger.Default.Send(Lng.Elem("Select a creature first"));
                return;
            }

            if (selected.Source is Thing thing)
            {
                var page = new ItemDetailsPage(thing);
                if (page.BindingContext is ItemDetailsViewModel vm)
                {
                    async void handler(object? s, ThingPurchasedEventArgs args)
                    {
                        try
                        {
                            ViewModel?.Character?.Buy(args.Thing);
                            RefreshAffordability();
                            if (Dispatcher != null)
                            {
                                await Dispatcher.DispatchAsync(async () =>
                                {
                                    await Navigation.PopAsync().ConfigureAwait(false);
                                }).ConfigureAwait(false);
                            }
                            else
                            {
                                await Navigation.PopAsync().ConfigureAwait(false);
                            }
                        }
                        catch (Exception ex)
                        {
                            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex.Message));
                        }
                        finally
                        {
                            vm.Purchased -= handler;
                        }
                    }

                    vm.Purchased += handler;
                }

                Navigation.PushAsync(page);
                return;
            }

            base.OnDetailsClicked(sender, e);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex.Message));
        }
    }

    private void RefreshAffordability()
    {
        var items = ViewModel?.Items;
        if (items == null)
        {
            return;
        }

        foreach (var item in items.OfType<DisplayItem>())
        {
            item.OnPropertyChanged(nameof(DisplayItem.Enabled));
        }
    }
}