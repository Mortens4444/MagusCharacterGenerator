using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

internal sealed partial class QualificationsView : ContentView
{
	public QualificationsView()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}