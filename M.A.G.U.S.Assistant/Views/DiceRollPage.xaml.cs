using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;
using Mtf.Maui.Controls.Messages;

namespace M.A.G.U.S.Assistant.Views;

internal partial class DiceRollPage : NotifierPage
{
    private DiceRollViewModel ViewModel => BindingContext as DiceRollViewModel;

    public DiceRollPage(DiceRollViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
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

        try
        {
            ViewModel.ShakeService?.Stop();
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    private async void OnDiceRollRequested(object? sender, TaskCompletionSource<bool> tcs)
    {
        try
        {
            await PlayDiceAnimationAsync().ConfigureAwait(false);
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

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        DiceImage.HorizontalOptions = width > height ? LayoutOptions.End : LayoutOptions.Center;
    }
}
