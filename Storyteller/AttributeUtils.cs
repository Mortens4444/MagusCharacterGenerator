namespace Storyteller;

public static class AttributeUtils
{
	public static int GetIntPropertyValue(this object instance, string propertyName)
	{
		var value = instance.GetPropertyValue(propertyName);
		return value == null ? 0 : (int)value;
	}

	public static object? GetPropertyValue(this object instance, string propertyName)
	{
		var property = instance.GetType().GetProperty(propertyName);
		return property?.GetValue(instance);
	}

	public static object[]? GetCustomAttributes(this object instance, string propertyName)
	{
		var property = instance.GetType().GetProperty(propertyName);
		return property?.GetCustomAttributes(false);
	}

	public static T GetAttribute<T>(this object[] attributes)
		where T : Attribute
	{
		return attributes.FirstOrDefault(attribute => attribute is T) as T;
	}
}
