using Mtf.Extensions;
using Mtf.LanguageService;
using Mtf.LanguageService.Enums;
using Mtf.LanguageService.Extensions;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

public partial class MainPage : NotifierPage
{
    private Dictionary<object, string> originalTextElements;

    public MainPage()
    {
        InitializeComponent();

        var languages = Enum.GetValues(typeof(ImplementedLanguage)).Cast<ImplementedLanguage>()
            .OrderBy(l => l.GetDescription())
            .ToList();
        foreach (var lang in languages)
        {
            LanguagePicker.Items.Add(lang.GetDescription());
        }
        LanguagePicker.SelectedIndex = languages.IndexOf(Lng.DefaultLanguage.ToImplementedLanguage());

        LanguagePicker.SelectedIndexChanged += (s, e) =>
        {
            var selected = languages[LanguagePicker.SelectedIndex];
            Lng.DefaultLanguage = selected.ToLanguage();
            if (originalTextElements != null)
            {
                Translator.SetOriginalTexts(originalTextElements);
            }
            originalTextElements = Translator.Translate(this);
        };
    }
}
