using DirectShowLib;
using System.Collections.Generic;

namespace Storyteller.Media
{
	public class FilterProvider
	{
		public Dictionary<string, IBaseFilter> Filters { get; } = new Dictionary<string, IBaseFilter>();

		private readonly FilterGraph filterGraph;
		private readonly FilterFactory filterFactory = new FilterFactory();

		public FilterProvider(FilterGraph filterGraph)
		{
			this.filterGraph = filterGraph;
		}

		public IBaseFilter this[string filterName]
		{
			get
			{
				return Filters[filterName];
			}
		}

		public IBaseFilter CreateFilter(NamedFilterCreator filterCreator)
		{
			if (filterCreator is BaseFilterCreator baseFilterCreator)
			{
				AddFilter(baseFilterCreator.BaseFilter, baseFilterCreator.Name);
				return baseFilterCreator.BaseFilter;
			}

			var filter = filterCreator is TypedFilterCreator typedFilterCreator
				? filterFactory.CreateFilter(typedFilterCreator.Type)
				: filterFactory.CreateFilterByName(filterCreator.Name);

			AddFilter(filter, filterCreator.Name);
			return filter;
		}

		private void AddFilter(IBaseFilter filter, string filterName)
		{
			((IGraphBuilder)filterGraph).AddFilter(filter, filterName);
			Filters.Add(filterName, filter);
		}
	}
}
