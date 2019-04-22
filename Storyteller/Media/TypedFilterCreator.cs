namespace Storyteller.Media
{
	public class TypedFilterCreator : NamedFilterCreator
	{
		private static readonly FilterInfoProvider filterInfoProvider = new FilterInfoProvider();

		public FilterType Type { get; private set; }

		public TypedFilterCreator(FilterType type)
			: base(filterInfoProvider.GetName(type))
		{
			Type = type;
		}
	}
}
