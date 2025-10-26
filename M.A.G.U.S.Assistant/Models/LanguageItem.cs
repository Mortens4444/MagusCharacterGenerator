﻿namespace M.A.G.U.S.Assistant.Models;

internal class LanguageItem
{
    public string EnumKey { get; set; } = String.Empty;

    public string Name { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public object SourceEnumValue { get; set; } = new();
}
