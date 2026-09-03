using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI;

namespace MAGUS.Assistant.Views;

internal sealed partial class CharacterCareView : ContentView
{
    public CharacterCareView()
    {
        InitializeComponent();
        Translator.Translate(this);

        // SleepProgress is computed from wall-clock time with no push notifications of its own (see
        // Character.SleepProgress) - without this, the progress bar would only ever move when
        // something else happened to touch the page's bindings.
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
