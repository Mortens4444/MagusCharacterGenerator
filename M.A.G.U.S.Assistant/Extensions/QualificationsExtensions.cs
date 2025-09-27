using M.A.G.U.S.Qualifications;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Extensions;

public static class QualificationsExtensions
{
    public static IEnumerable<Qualification> OrderByLocalizedName(this IEnumerable<Qualification> source)
    {
        if (source == null)
        {
            return [];
        }

        return source.OrderBy(q => Lng.Elem(q.Name));
    }
}
