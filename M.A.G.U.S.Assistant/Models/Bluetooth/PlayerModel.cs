using M.A.G.U.S.GameSystem;

namespace M.A.G.U.S.Assistant.Models.Bluetooth;

public sealed class PlayerModel
{
    public string Id { get; init; } = String.Empty;
    
    public string Name { get; set; } = String.Empty;

    public Character Character { get; set; }
    
    public bool IsSelected { get; set; }

    public bool IsSelectedSender { get; set; }

    public bool IsSelectedTarget { get; set; }
}
