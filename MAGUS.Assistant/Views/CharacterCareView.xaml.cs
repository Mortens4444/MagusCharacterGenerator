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
        // is cached and reused per tab (CharacterViewModel.ChangeTab's viewCache), and Page/ViewModel
        // instances are never explicitly disposed on navigating away (CharacterViewModel.Dispose is
        // never called), so an always-running timer here would keep ticking forever on an orphaned,
        // stale Character instance from a previous visit - independently re-detecting and re-announcing
        // the same "hunger wakes you up" interruption a second time once the character's details page
        // is reopened and starts its own, second live timer for the same in-progress sleep.
        var progressTimer = Dispatcher.CreateTimer();
        progressTimer.Interval = TimeSpan.FromSeconds(5);
        progressTimer.Tick += (_, _) => (BindingContext as CharacterViewModel)?.RefreshLiveProgress();
        Loaded += (_, _) => progressTimer.Start();
        Unloaded += (_, _) => progressTimer.Stop();
    }
}
