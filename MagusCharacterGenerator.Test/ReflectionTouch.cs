using System.Reflection;

namespace MAGUS.Test;

internal static class ReflectionTouch
{
    public static void TouchAllMembers(object instance)
    {
        var type = instance.GetType();

        foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (!prop.CanRead || prop.GetIndexParameters().Length > 0)
            {
                continue;
            }

            try
            {
                _ = prop.GetValue(instance);
            }
            catch
            {
            }
        }

        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
        {
            if (method.GetParameters().Length > 0 || method.IsGenericMethod || method.IsSpecialName
                || method.DeclaringType == typeof(object))
            {
                continue;
            }

            try
            {
                _ = method.Invoke(instance, null);
            }
            catch
            {
            }
        }
    }
}
