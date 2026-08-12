using Mtf.LanguageService;

namespace MAGUS.Assistant.Models;

internal sealed class BestiaryCategoryItem
{
    public string Key { get; init; } = String.Empty;

    public string Name => Lng.Elem(Key) ?? Key;
}