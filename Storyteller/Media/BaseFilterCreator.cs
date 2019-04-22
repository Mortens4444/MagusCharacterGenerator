using DirectShowLib;
using System;

namespace Storyteller.Media
{
	public class BaseFilterCreator : NamedFilterCreator
	{
		public IBaseFilter BaseFilter { get; private set; }		

		public BaseFilterCreator(string name, IBaseFilter baseFilter, Action<IBaseFilter> postAction = null)
			: base(name, postAction)
		{
			BaseFilter = baseFilter;
		}
	}
}
