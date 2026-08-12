using CommunityToolkit.Mvvm.Messaging;
using Mtf.Maui.Controls.Messages;

namespace MAGUS.Assistant.Services;

internal static class EmbeddedResourceHelper
{
    public static bool HasEmbeddedSound(string sound)
    {
        if (String.IsNullOrWhiteSpace(sound))
        {
            return false;
        }

        var resourceId = GetResourceId(sound);
        try
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var asm in assemblies)
            {
                try
                {
                    var names = asm.GetManifestResourceNames();
                    if (names.Any(n => String.Equals(n, resourceId, StringComparison.OrdinalIgnoreCase)))
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
#if DEBUG
                    WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
#endif
                }
            }
        }
        catch (Exception ex)
        {
#if DEBUG
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
#endif
        }

        return false;
    }

    public static string GetResourceId(string sound)
    {
        return $"MAGUS.Assistant.Resources.Raw.{sound}.mp3";
    }
}
