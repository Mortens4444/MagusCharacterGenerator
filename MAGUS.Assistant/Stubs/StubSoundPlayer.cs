using MAGUS.Assistant.Interfaces;
using MAGUS.Assistant.Models;

namespace MAGUS.Assistant.Stubs;

internal sealed class StubSoundPlayer : ISoundPlayer
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
