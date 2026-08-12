using System.Text.RegularExpressions;

namespace MAGUS.Extensions;

public static partial class StringExtensions
{
    public static string ToImageName(this string name)
    {
        var imageName = FindCommas().Replace(name, String.Empty);
        imageName = FindSpecialChars().Replace(imageName, "_");
        return imageName.ToLowerInvariant();
    }

    [GeneratedRegex("[,]")]
    private static partial Regex FindCommas();

    [GeneratedRegex(@"[\s\-,()'’/]+")]
    private static partial Regex FindSpecialChars();
}
