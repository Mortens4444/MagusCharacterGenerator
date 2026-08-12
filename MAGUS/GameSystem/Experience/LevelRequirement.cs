namespace MAGUS.GameSystem.Experience;

public class LevelRequirement
{
    public int Level { get; set; }
    
    public ulong MinExperience { get; set; }

    public ulong MaxExperience { get; set; }
}
