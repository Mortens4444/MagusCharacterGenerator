using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Utils;

public static class ClassCreator
{
    public static IClass GetClass(Type classType, int level, bool needPsi = true)
    {
        bool hasPsi = false;
        IClass? result = null;
        do
        {
            try
            {
                result = (IClass)Activator.CreateInstance(classType, [level, true]);
                hasPsi = result.Qualifications.Any(q => q is IPsi);
            }
            catch { }
        }
        while (!hasPsi && needPsi);
        return result;
    }
}
