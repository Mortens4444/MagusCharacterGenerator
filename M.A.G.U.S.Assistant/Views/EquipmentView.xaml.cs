using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

internal sealed partial class EquipmentView : ContentView
{
	public EquipmentView()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}