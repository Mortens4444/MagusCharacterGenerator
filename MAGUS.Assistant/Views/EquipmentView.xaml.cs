using Mtf.LanguageService.MAUI;

namespace MAGUS.Assistant.Views;

internal sealed partial class EquipmentView : ContentView
{
	public EquipmentView()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}