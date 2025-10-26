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
    private Character? character;

    public Character? Character
    {
        get => character;
        set
        {
            character = value;
        }
    }

    public MarketPage()
        : base("Market",
            "M.A.G.U.S.Things"
                .CreateInstancesFromNamespace<Thing>()
                .OrderBy(r => Lng.Elem(r.Name))
                .Select(r => DisplayItem.FromThing(r, null)))
    {
        character = null;
    }

    public MarketPage(Character character)
        : base($"{Lng.Elem("Market")} - {character.Name}",
            "M.A.G.U.S.Things"
                .CreateInstancesFromNamespace<Thing>()
                .OrderBy(r => Lng.Elem(r.Name))
                .Select(r => DisplayItem.FromThing(r, character.Money)))
    {
        this.character = character;
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
                    void handler(object? s, ThingPurchasedEventArgs args)
                    {
                        try
                        {
                            Character?.Buy(args.Thing);
                            Device.BeginInvokeOnMainThread(async () => await Navigation.PopAsync());
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
}