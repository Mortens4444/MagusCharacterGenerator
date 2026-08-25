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
        var progressTimer = Dispatcher.CreateTimer();
        progressTimer.Interval = TimeSpan.FromSeconds(5);
        progressTimer.Tick += (_, _) => (BindingContext as CharacterViewModel)?.RefreshLiveProgress();
        progressTimer.Start();
    }
}
