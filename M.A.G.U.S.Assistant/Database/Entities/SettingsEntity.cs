using SQLite;

namespace M.A.G.U.S.Assistant.Database.Entities;

[Table("Settings")]
internal class SettingsEntity
{
    [PrimaryKey]
    public string Name { get; set; } = String.Empty;

    public string Value { get; set; } = String.Empty;
}