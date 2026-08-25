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
        var progressTimer = Dispatcher.CreateTimer();
        progressTimer.Interval = TimeSpan.FromSeconds(5);
        progressTimer.Tick += (_, _) => (BindingContext as CharacterViewModel)?.RefreshLiveProgress();
        progressTimer.Start();
    }
}