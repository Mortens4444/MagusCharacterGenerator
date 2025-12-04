using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI;
using Mtf.Maui.Controls.Models;

namespace M.A.G.U.S.Assistant.Views;

internal partial class RollFormulaPage : NotifierPage
{
    private RollFormulaViewModel ViewModel => BindingContext as RollFormulaViewModel;
    private DateTime lastShake = DateTime.MinValue;
    private const double ShakeThresholdG = 2.2;
    private const int ShakeDebounceMs = 800;

    public RollFormulaPage(RollFormulaViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        ViewModel.RollRequested += OnRollRequested;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Translator.Translate(this);

        try
        {
            ViewModel.ShakeService.Start();
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        try
        {
            ViewModel.ShakeService.Stop();
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
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

    private async void OnRollRequested(object? sender, TaskCompletionSource<bool> tcs)
    {
        try
        {
            await PlayDiceAnimationAsync();
            tcs.SetResult(true);
        }
        catch (Exception ex)
        {
            tcs.SetException(ex);
        }
    }

    private async Task PlayDiceAnimationAsync()
    {
        try
        {
            await Dispatcher.DispatchAsync(async () =>
            {
                await Task.WhenAll(
                    this.FindByName<Image>("DiceImage").RotateTo(360, 400)
                );
                this.FindByName<Image>("DiceImage").Rotation = 0;
                await this.FindByName<Image>("DiceImage").TranslateTo(-8, 0, 50);
                await this.FindByName<Image>("DiceImage").TranslateTo(8, 0, 50);
                await this.FindByName<Image>("DiceImage").TranslateTo(0, 0, 30);
            });
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }
}
