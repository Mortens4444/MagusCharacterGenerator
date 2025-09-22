using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.GameSystem.Languages;
using Mtf.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

public class LanguagesViewModel : INotifyPropertyChanged
{
    public ObservableCollection<string> Types { get; } = ["Living", "Ancient"];

    public ObservableCollection<LanguageItem> Languages { get; } = [];
    public ObservableCollection<LanguageItem> FilteredLanguages { get; } = [];

    string _searchText = String.Empty;
    public string SearchText
    {
        get => _searchText;
        set
        {
            if (_searchText == value) return;
            _searchText = value ?? String.Empty;
            OnPropertyChanged(nameof(SearchText));
            ApplyFilter();
        }
    }

    string _selectedType = "Living";
    public string SelectedType
    {
        get => _selectedType;
        set
        {
            if (_selectedType == value) return;
            _selectedType = value ?? String.Empty;
            OnPropertyChanged(nameof(SelectedType));
            LoadByType(_selectedType);
        }
    }

    LanguageItem _selectedLanguage;
    public LanguageItem SelectedLanguage
    {
        get => _selectedLanguage;
        set
        {
            if (_selectedLanguage == value) return;
            _selectedLanguage = value;
            OnPropertyChanged(nameof(SelectedLanguage));
            // itt kezelheted a kiválasztást (pl. navigálás vagy mentés)
        }
    }

    public ICommand SelectCommand { get; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public LanguagesViewModel()
    {
        SelectCommand = new RelayCommand(o =>
        {
            if (o is LanguageItem li) SelectedLanguage = li;
        });

        SelectedType = Types.First();
    }

    void LoadByType(string type)
    {
        Languages.Clear();

        if (type == "Living")
        {
            var items = GetEnumItems(typeof(Language)).OrderBy(i => i.Name);
            foreach (var it in items) Languages.Add(it);
        }
        else
        {
            var items = GetEnumItems(typeof(AntientLanguage)).OrderBy(i => i.Name);
            foreach (var it in items) Languages.Add(it);
        }

        ApplyFilter();
    }

    IEnumerable<LanguageItem> GetEnumItems(Type enumType)
    {
        foreach (var val in Enum.GetValues(enumType))
        {
            //var member = enumType.GetMember(val.ToString()).FirstOrDefault();
            //var descAttr = member?.GetCustomAttribute<DescriptionAttribute>();
            //var desc = descAttr?.Description ?? val.ToString();
            
            yield return new LanguageItem
            {
                EnumKey = val.ToString(),
                Name = val.GetDescription(),
                Description = String.Empty,
                SourceEnumValue = val
            };
        }
    }

    void ApplyFilter()
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
        foreach (var it in query) FilteredLanguages.Add(it);
    }

    void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
