using Mtf.LanguageService.MAUI;

namespace MAGUS.Assistant.Views;

internal sealed partial class SearchListView : ContentView
{
	public SearchListView()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}