using MagusAssistant.ViewModels;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

public partial class DiceRollPage : ContentPage
{
    private DiceRollViewModel ViewModel => BindingContext as DiceRollViewModel;

    private DateTime lastShake = DateTime.MinValue;
    private const double ShakeThreshold = 20.0; // m/s^2
    private const int ShakeDebounceMs = 800;

    public DiceRollPage()
    {
        InitializeComponent();
        if (ViewModel != null)
        {
            ViewModel.DiceRolled += OnDiceRolled;
        }
    }

    protected override async void OnAppearing()
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
        catch
        {
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
        catch
        {
        }
    }

    private void OnAccelerometerReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
        try
        {
            var ax = e.Reading.Acceleration.X;
            var ay = e.Reading.Acceleration.Y;
            var az = e.Reading.Acceleration.Z;

            var total = Math.Sqrt(ax * ax + ay * ay + az * az);

            if (total > ShakeThreshold)
            {
                var now = DateTime.UtcNow;
                if ((now - lastShake).TotalMilliseconds > ShakeDebounceMs)
                {
                    lastShake = now;
                    MainThread.BeginInvokeOnMainThread(() => TriggerRollFromShake());
                }
            }
        }
        catch
        {
        }
    }

    private void TriggerRollFromShake()
    {
        try
        {
            Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(80));
        }
        catch
        {
        }

        try
        {
            if (ViewModel?.RollCommand != null && ViewModel.RollCommand.CanExecute(null))
            {
                ViewModel.RollCommand.Execute(null);
            }
        }
        catch
        {
        }
    }

    private void OnDiceRolled(object sender, EventArgs e)
    {
        _ = PlayDiceAnimationAsync();
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
