using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models;

namespace M.A.G.U.S.Assistant;

internal class StubSoundPlayer : ISoundPlayer
{
    public event EventHandler? PlaybackEnded;

    public Task PlayAndVibrateAsync(string sound)
    {
        return Task.CompletedTask;
    }

    public Task PlayAsync(string sound)
    {
        return Task.CompletedTask;
    }

    public Task PlayAsync(SoundItem sound, double volume)
    {
        return Task.CompletedTask;
    }

    public void SetVolume(double volume)
    {
    }

    public void Stop()
    {
        PlaybackEnded?.Invoke(this, EventArgs.Empty);
    }
}
