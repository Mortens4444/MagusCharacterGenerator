using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.GameSystem.Languages;
using Mtf.Extensions;
using Mtf.LanguageService;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal class LanguagesViewModel : INotifyPropertyChanged
{
    public ObservableCollection<LanguageTypes> Types { get; } =
        [LanguageTypes.Living, LanguageTypes.Ancient];

    public ObservableCollection<LanguageItem> Languages { get; } = [];
    public ObservableCollection<LanguageItem> FilteredLanguages { get; } = [];

    string searchText = String.Empty;
    public string SearchText
    {
        get => searchText;
        set
        {
            if (searchText == value)
            {
                return;
            }

            searchText = value ?? String.Empty;
            OnPropertyChanged(nameof(SearchText));
            ApplyFilter();
        }
    }

    LanguageTypes selectedType = LanguageTypes.Ancient;
    public LanguageTypes SelectedType
    {
        get => selectedType;
        set
        {
            if (selectedType == value)
            {
                return;
            }

            selectedType = value;
            OnPropertyChanged(nameof(SelectedType));
            LoadByType(selectedType);
        }
    }

    LanguageItem? selectedLanguage;
    public LanguageItem? SelectedLanguage
    {
        get => selectedLanguage;
        set
        {
            if (selectedLanguage == value)
            {
                return;
            }

            selectedLanguage = value;
            OnPropertyChanged(nameof(SelectedLanguage));
        }
    }

    public ICommand SelectCommand { get; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public LanguagesViewModel()
    {
        SelectCommand = new RelayCommand(o =>
        {
            if (o is LanguageItem li)
            {
                SelectedLanguage = li;
            }
        });

        SelectedType = LanguageTypes.Living;
        LoadByType(selectedType);
    }

    private void LoadByType(LanguageTypes type)
    {
        Languages.Clear();

        var enumItemType = type == LanguageTypes.Living ? typeof(Language) : typeof(AntientLanguage);
        var items = GetEnumItems(enumItemType).OrderBy(i => Lng.Elem(i.Name));
        foreach (var item in items)
        {
            Languages.Add(item);
        }

        ApplyFilter();
    }

    private static IEnumerable<LanguageItem> GetEnumItems(Type enumType)
    {
        foreach (var val in Enum.GetValues(enumType))
        {
            yield return new LanguageItem
            {
                EnumKey = val.ToString() ?? String.Empty,
                Name = val.ToString() ?? String.Empty,
                Description = val.GetDescription(),
                SourceEnumValue = val
            };
        }
    }

    private void ApplyFilter()
    {
        var query = Languages.AsEnumerable();
        var st = SearchText?.Trim();
        if (!String.IsNullOrWhiteSpace(st))
        {
            query = query.Where(l =>
                (l.Name?.IndexOf(st, StringComparison.CurrentCultureIgnoreCase) >= 0) ||
                (l.EnumKey?.IndexOf(st, StringComparison.CurrentCultureIgnoreCase) >= 0));
        }

        FilteredLanguages.Clear();
        foreach (var it in query)
        {
            FilteredLanguages.Add(it);
        }
    }

    void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
