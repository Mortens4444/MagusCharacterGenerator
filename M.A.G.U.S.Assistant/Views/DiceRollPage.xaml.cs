using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Messages;
using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

public partial class DiceRollPage : NotifierPage
{
    private DiceRollViewModel ViewModel => BindingContext as DiceRollViewModel;

    private DateTime lastShake = DateTime.MinValue;
    private const double ShakeThresholdG = 2.2;
    private const int ShakeDebounceMs = 800;

    public DiceRollPage()
    {
        InitializeComponent();
        if (ViewModel != null)
        {
            ViewModel.DiceRollRequested += OnDiceRollRequested;
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Translator.Translate(this);

        try
        {
            Accelerometer.ReadingChanged += OnAccelerometerReadingChanged;
            if (!Accelerometer.IsMonitoring)
            {
                Accelerometer.Start(SensorSpeed.UI);
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex.Message));
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        try
        {
            Accelerometer.ReadingChanged -= OnAccelerometerReadingChanged;
            if (Accelerometer.IsMonitoring)
            {
                Accelerometer.Stop();
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex.Message));
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
                    MainThread.BeginInvokeOnMainThread(() => TriggerRollFromShake());
                }
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex.Message));
        }
    }

    private void TriggerRollFromShake()
    {

        try
        {
            if (ViewModel?.RollCommand != null && ViewModel.RollCommand.CanExecute(null))
            {
                try
                {
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(80));
                }
                catch (Exception ex)
                {
                    WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex.Message));
                }
                ViewModel.RollCommand.Execute(null);
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex.Message));
        }
    }

    private async void OnDiceRollRequested(object? sender, TaskCompletionSource<bool> tcs)
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
            await DiceImage.RotateTo(360, 500);
            DiceImage.Rotation = 0;
            await DiceImage.TranslateTo(-10, 0, 50);
            await DiceImage.TranslateTo(10, 0, 50);
            await DiceImage.TranslateTo(-6, 0, 40);
            await DiceImage.TranslateTo(6, 0, 40);
            await DiceImage.TranslateTo(0, 0, 30);
        }
        catch
        {
        }
    }
}
