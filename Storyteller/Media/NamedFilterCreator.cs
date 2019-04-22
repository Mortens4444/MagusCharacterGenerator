using DirectShowLib;
using System;

namespace Storyteller.Media
{
	public class NamedFilterCreator
	{
		public string Name { get; }

		public Action<IBaseFilter> PostAction { get; }

		public NamedFilterCreator(string name, Action<IBaseFilter> postAction = null)
		{
			Name = name;
			PostAction = postAction;
		}
	}
}
