using M.A.G.U.S.GameSystem;
using Mtf.LanguageService.Core;

namespace M.A.G.U.S.Assistant.Extensions;

internal static class AttackerExtensions
{
    public static string GetName(this Attacker attacker) => attacker is Character character ? character.Name : Lng.Elem(attacker.Name);
}
