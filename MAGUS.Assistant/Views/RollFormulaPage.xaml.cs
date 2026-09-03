using CommunityToolkit.Mvvm.Messaging;
using MAGUS.Assistant.Interfaces;
using MAGUS.Assistant.Models;
using MAGUS.Assistant.Services;
using MAGUS.Assistant.ViewModels;
using MAGUS.Models;
using Mtf.LanguageService;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;
using Mtf.Maui.Controls.Messages;

namespace MAGUS.Assistant.Views;

internal sealed partial class RollFormulaPage : NotifierPage
{
    private bool isClosing;
    private DateTime lastShake = DateTime.MinValue;
    private const double ShakeThresholdG = 2.2;
    private const int ShakeDebounceMs = 800;
    private readonly TaskCompletionSource<int> tcs = new();

    public RollFormulaPage(ISoundPlayer soundPlayer, IShakeService shakeService, DiceThrowFormula rollFormula, string title)
        : this(soundPlayer, shakeService, new LocalizedRollFormula(rollFormula, title))
    {
    }

    public RollFormulaPage(ISoundPlayer soundPlayer, IShakeService shakeService, LocalizedRollFormula rollFormula)
    {
        InitializeComponent();
        RollFormulaTitle.Text = Lng.Elem(rollFormula.Title);
        BindingContext = new RollFormulaViewModel(soundPlayer, shakeService, rollFormula);
        ViewModel.RollRequested += OnRollRequested;
        ViewModel.CloseRequested += async (_, _) => await CloseAsync().ConfigureAwait(true);

        // Unloaded (not OnDisappearing) fires only once the page is actually removed from the
        // navigation stack - this page is itself shown modally, so Unloaded lines up with its
        // final close (see EncounterPage.OnAppearing for why OnDisappearing generally can't be
        // trusted for this kind of teardown).
        Unloaded += (_, _) => ViewModel.Dispose();
    }

    public Task<int> ResultTask => tcs.Task;

    public RollFormulaViewModel ViewModel => BindingContext as RollFormulaViewModel ?? throw new ArgumentNullException(nameof(BindingContext), $"{nameof(BindingContext)} should be convertable to {nameof(RollFormulaViewModel)}");

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Translator.Translate(this);

        try
        {
            ViewModel.ShakeService?.Start();
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        // Unconditional, matching OnAppearing's unconditional Start(): this used to run only on
        // the first OnDisappearing (a "firstRun" guard), so backgrounding the app once while this
        // dialog was open left the accelerometer subscribed on every subsequent disappear - which
        // rooted this page (via the static Accelerometer.ReadingChanged event) for the rest of the
        // process's life instead of letting it be garbage-collected once closed.
        try
        {
            ViewModel.ShakeService?.Stop();
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    private async Task CloseAsync()
    {
        if (!isClosing)
        {
            isClosing = true;
            await ShellNavigationService.CloseModalPageAsync().ConfigureAwait(true);
            tcs.TrySetResult(ViewModel.Result);
        }
    }

    private void OnAccelerometerReadingChanged(object? sender, AccelerometerChangedEventArgs e)
    {
        try
        {
            var ax = e.Reading.Acceleration.X;
            var ay = e.Reading.Acceleration.Y;
            var az = e.Reading.Acceleration.Z;
            var total = Math.Sqrt(ax * ax + ay * ay + az * az);

            if (total > ShakeThresholdG)
            {
                var now = DateTime.UtcNow;
                if ((now - lastShake).TotalMilliseconds > ShakeDebounceMs)
                {
                    lastShake = now;
                    MainThread.BeginInvokeOnMainThread(() => ViewModel.TriggerActionFromShake());
                }
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    private async void OnRollRequested(object? _, TaskCompletionSource<bool> tcs)
    {
        try
        {
            await PlayDiceAnimationAsync().ConfigureAwait(true);
            tcs.SetResult(true);
        }
        catch (Exception ex)
        {
            tcs.SetException(ex);
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    private async Task PlayDiceAnimationAsync()
    {
        try
        {
            await DiceImage.RotateToAsync(360, 500).ConfigureAwait(true);
            DiceImage.Rotation = 0;
            await DiceImage.TranslateToAsync(-10, 0, 50).ConfigureAwait(true);
            await DiceImage.TranslateToAsync(10, 0, 50).ConfigureAwait(true);
            await DiceImage.TranslateToAsync(-6, 0, 40).ConfigureAwait(true);
            await DiceImage.TranslateToAsync(6, 0, 40).ConfigureAwait(true);
            await DiceImage.TranslateToAsync(0, 0, 30).ConfigureAwait(true);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }
}
