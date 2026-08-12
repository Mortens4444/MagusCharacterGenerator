using SQLite;

namespace MAGUS.Assistant.Database.Entities;

[Table("Characters")]
internal sealed class CharacterEntity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; } = String.Empty;

    public string RaceName { get; set; } = String.Empty;

    public string ClassName { get; set; } = String.Empty;

    public DateTime LastModified { get; set; }

    public string JsonData { get; set; } = String.Empty;
}