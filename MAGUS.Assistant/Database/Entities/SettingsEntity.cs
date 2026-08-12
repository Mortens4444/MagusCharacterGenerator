using SQLite;

namespace MAGUS.Assistant.Database.Entities;

[Table("Settings")]
internal sealed class SettingsEntity
{
    [PrimaryKey]
    public string Name { get; set; } = String.Empty;

    public string Value { get; set; } = String.Empty;
}