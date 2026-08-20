namespace MAGUS.GameSystem.Magic.ElementalMagic.Forms;

/// <summary>
/// One of the ten shapes (6 Iskolaforma + 4 Szabálytalan Elemi Forma) a
/// <see cref="CreatedElement"/> can be poured into. Source: p. 295-297.
/// </summary>
public interface IMosaicForm
{
    string Name { get; }

    /// <summary>How many rounds the shaped effect lasts. 0 means instantaneous (single burst of effect).</summary>
    int DurationInRounds { get; }
}
