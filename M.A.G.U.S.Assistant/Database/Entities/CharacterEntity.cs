using SQLite;

namespace M.A.G.U.S.Assistant.Database.Entities;

[Table("Characters")]
internal class CharacterEntity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; } = String.Empty;

    public string RaceName { get; set; } = String.Empty;

    public string ClassName { get; set; } = String.Empty;

    public DateTime LastModified { get; set; }

    public string JsonData { get; set; } = String.Empty;
}