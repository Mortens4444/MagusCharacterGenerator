using SQLite;

namespace M.A.G.U.S.Assistant.Database.Entities;

public class DrawingEntity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public string ElementsJson { get; set; }
}
