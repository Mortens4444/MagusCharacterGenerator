using M.A.G.U.S.Assistant.Models;

namespace M.A.G.U.S.Assistant.Interfaces;

internal interface ISoundPlayer
{
    Task PlayAsync(string sound);

    Task PlayAndVibrateAsync(string sound);

    Task PlayAsync(SoundItem sound, double volume);

    void Stop();

    void SetVolume(double volume);

    event EventHandler PlaybackEnded;
}
