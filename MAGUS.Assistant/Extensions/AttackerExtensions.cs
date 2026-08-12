using MAGUS.GameSystem;
using Mtf.LanguageService;

namespace MAGUS.Assistant.Extensions;

internal static class AttackerExtensions
{
    public static string GetName(this Attacker attacker) => attacker is Character character ? character.Name : Lng.Elem(attacker.Name);
}
