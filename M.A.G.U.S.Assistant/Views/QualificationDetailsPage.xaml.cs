using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;
using Mtf.Maui.Controls.Messages;

namespace M.A.G.U.S.Assistant.Views;

internal partial class QualificationDetailsPage : NotifierPage
{
    public QualificationDetailsPage(QualificationDetailsViewModel qualificationDetailsViewModel)
    {
        InitializeComponent();
        Title = Lng.Elem(qualificationDetailsViewModel.Qualification.Name);
        BindingContext = qualificationDetailsViewModel;
        qualificationDetailsViewModel.Closed += OnVmClosed;
    }

    private async void OnVmClosed(object? sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync("..").ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }
}