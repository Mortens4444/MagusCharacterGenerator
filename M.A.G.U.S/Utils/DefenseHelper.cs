using M.A.G.U.S.GameSystem.Attributes;
using System.Reflection;

namespace M.A.G.U.S.Utils;

public static class DefenseHelper
{
    public static int Get<TEnum>(TEnum value)
        where TEnum : Enum
    {
        var member = typeof(TEnum)
            .GetMember(value.ToString())
            .FirstOrDefault();

        return member?
            .GetCustomAttribute<DefenseHelperAttribute>()?
            .DefenseValue ?? 0;
    }
}