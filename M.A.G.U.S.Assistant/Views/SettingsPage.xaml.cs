using M.A.G.U.S.Assistant.ViewModels;
using Mtf.Extensions;
using Mtf.LanguageService.Enums;
using Mtf.LanguageService.Extensions;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class SettingsPage : NotifierPage
{
    private Dictionary<object, string>? originalTextElements;

    public SettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        var languages = Enum.GetValues<ImplementedLanguage>().Cast<ImplementedLanguage>()
            .OrderBy(l => l.GetDescription())
            .ToList();

        foreach (var lang in languages)
        {
            LanguagePicker.Items.Add(lang.GetDescription());
        }

        LanguagePicker.SelectedIndexChanged += (s, e) =>
        {
            if (LanguagePicker.SelectedIndex == -1)
            {
                return;
            }

            var selectedLangEnum = languages[LanguagePicker.SelectedIndex];
            var selectedLanguage = selectedLangEnum.ToLanguage();
            viewModel.CurrentLanguage = selectedLanguage;
            Lng.DefaultLanguage = selectedLanguage;

            if (originalTextElements == null)
            {
                originalTextElements = Translator.Translate(this);
            }
            else
            {
                Translator.SetOriginalTexts(originalTextElements);
                _ = Translator.Translate(this);
            }

            Shell.Current.Title = Lng.Elem("M.A.G.U.S. Assistant");
        };

        LanguagePicker.SelectedIndex = languages.IndexOf(Lng.DefaultLanguage.ToImplementedLanguage());
    }
}