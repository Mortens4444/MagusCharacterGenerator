using MAGUS.Assistant.ViewModels;
using Mtf.Extensions;
using Mtf.LanguageService.Enums;
using Mtf.LanguageService.Extensions;
using Mtf.LanguageService;
using Mtf.LanguageService.MAUI.Views;
using Mtf.LanguageService.MAUI;

namespace MAGUS.Assistant.Views;

internal sealed partial class SettingsPage : NotifierPage
{
    private readonly Dictionary<object, string>? originalTextElements;

    public SettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        originalTextElements = Translator.Translate(this);

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
            Translator.SetOriginalTexts(originalTextElements);
            _ = Translator.Translate(this);
            viewModel.RefreshLanguageDependentBindings();
            Shell.Current.Title = Lng.Elem("MAGUS Assistant");
        };

        LanguagePicker.SelectedIndex = languages.IndexOf(Lng.DefaultLanguage.ToImplementedLanguage());
    }
}