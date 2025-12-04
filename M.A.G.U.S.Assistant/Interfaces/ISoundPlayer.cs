using M.A.G.U.S.Assistant.Models;

namespace M.A.G.U.S.Assistant.Interfaces;

public interface ISoundPlayer
{
    Task PlayAsync(string sound);

    Task PlayAsync(SoundItem sound, double volume);

    void Stop();

    void SetVolume(double volume);

    event EventHandler PlaybackEnded;
}
