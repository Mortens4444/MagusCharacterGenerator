using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI;

namespace MAGUS.Assistant.Views;

internal sealed partial class PlacesView : ContentView
{
	public PlacesView()
	{
		InitializeComponent();
        Translator.Translate(this);

        // TravelProgress/SleepProgress are computed from wall-clock time with no push notifications
        // of their own (see Character.TravelProgress) - without this, the progress bar would only
        // ever move when something else happened to touch the page's bindings. Ticking every few
        // seconds is plenty since a journey takes days, not seconds.
        //
        // Started/stopped on Loaded/Unloaded rather than running from construction onward: this View
        // is cached and reused per tab (CharacterViewModel.ChangeTab's viewCache), so it goes through
        // Loaded/Unloaded on every tab switch within a single visit, well before CharacterDetailsPage's
        // own Unloaded disposes the CharacterViewModel. An always-running timer here would otherwise
        // keep ticking on a tab the user has switched away from - independently re-detecting and
        // re-announcing the same "hunger wakes you up" interruption a second time once the character's
        // details page is reopened and starts its own, second live timer for the same in-progress sleep.
        var progressTimer = Dispatcher.CreateTimer();
        progressTimer.Interval = TimeSpan.FromSeconds(5);
        progressTimer.Tick += (_, _) => (BindingContext as CharacterViewModel)?.RefreshLiveProgress();
        Loaded += (_, _) => progressTimer.Start();
        Unloaded += (_, _) => progressTimer.Stop();
    }
}