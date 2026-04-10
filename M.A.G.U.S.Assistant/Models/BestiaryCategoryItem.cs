using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Models;

internal sealed class BestiaryCategoryItem
{
    public string Key { get; init; } = String.Empty;

    public string Name => Lng.Elem(Key) ?? Key;
}