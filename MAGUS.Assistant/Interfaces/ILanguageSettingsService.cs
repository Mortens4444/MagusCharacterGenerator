using Mtf.LanguageService.Enums;

namespace MAGUS.Assistant.Interfaces;

/// <summary>
/// The subset of SettingsService's API that App.xaml.cs needs at startup to restore the persisted
/// language. Exists as its own public interface (rather than exposing SettingsService itself)
/// because App's constructor must be public for the DI container to find it at runtime, and a
/// public constructor can't take an internal type as a parameter (CS0051) - see App.xaml.cs.
/// </summary>
public interface ILanguageSettingsService
{
    Task<Language> GetCurrentLanguageAsync();
}
