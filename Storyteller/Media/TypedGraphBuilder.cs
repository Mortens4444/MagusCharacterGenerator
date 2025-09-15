namespace Storyteller.Media
{
	using DirectShowLib;
	using System.Collections.Generic;
	using System.Linq;

	namespace MediaApplication.Media
	{
		public class TypedGraphBuilder
		{
			public FilterGraph FilterGraph => generalGraphBuilder.FilterGraph;

			private readonly GeneralGraphBuilder generalGraphBuilder = new GeneralGraphBuilder();
			private readonly ConnectedFilterProvider connectedFilterProvider = new ConnectedFilterProvider();
			private readonly ConnectionProvider connectionProvider = new ConnectionProvider();
			private IEnumerable<NamedFilterCreator> registeredFilters;

			public void Stop()
			{
				foreach (var registeredFilter in registeredFilters)
				{
					registeredFilter.CallMethod("Close");
					registeredFilter.CallMethod("Release");
				}
			}

			public void BuildAviPlayer(string filename)
			{
				registeredFilters = connectedFilterProvider.GetAviPlayerFilters(filename);
				generalGraphBuilder.RegisterFilters(registeredFilters);
				var connections = connectionProvider.GetAviPlayerConnection(registeredFilters.ToList());
				generalGraphBuilder.BuildGraphWithAutoConnect(connections);
			}

			// TODO: Cannot play sound
			public void BuildMpegPlayer(string filename)
			{
				registeredFilters = connectedFilterProvider.GetMpegPlayerFilters(filename);
				generalGraphBuilder.RegisterFilters(registeredFilters);
				var connections = connectionProvider.GetMpegPlayerConnection(registeredFilters.ToList());
				generalGraphBuilder.BuildGraphWithAutoConnect(connections);
			}
		}
	}
}
