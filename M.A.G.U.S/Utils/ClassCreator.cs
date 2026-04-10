using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Utils;

public static class ClassCreator
{
    public static IClass GetClass(Type classType, int level, bool needPsi = true)
    {
        ArgumentNullException.ThrowIfNull(classType);

        if (!typeof(IClass).IsAssignableFrom(classType))
        {
            throw new ArgumentException($"The type {classType.FullName} does not implement {nameof(IClass)}.", nameof(classType));
        }

        const int maxAttempts = 100;

        for (var i = 0; i < maxAttempts; i++)
        {
            try
            {
                if (Activator.CreateInstance(classType, level, true) is not IClass result)
                {
                    continue;
                }

                var hasPsi = result.Qualifications.Any(q => q is IPsi);
                if (!needPsi || hasPsi)
                {
                    return result;
                }
            }
            catch { }
        }

        throw new InvalidOperationException($"Could not create an instance of {classType.FullName} that satisfies needPsi = {needPsi}.");
    }
}
