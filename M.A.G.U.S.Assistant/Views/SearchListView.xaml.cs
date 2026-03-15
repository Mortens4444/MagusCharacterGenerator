using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

internal partial class SearchListView : ContentView
{
	public SearchListView()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}