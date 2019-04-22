using DirectShowLib;
using System.Collections.Generic;
using System.Linq;

namespace Storyteller.Media
{
	public class GeneralGraphBuilder
	{
		public FilterGraph FilterGraph { get; set; } = new FilterGraph();

		private readonly MediaConnector mediaConnector;
		private readonly FilterProvider filterProvider;
		private readonly ErrorHandler errorHandler = new ErrorHandler();

		public GeneralGraphBuilder()
		{
			filterProvider = new FilterProvider(FilterGraph);
			mediaConnector = new MediaConnector(filterProvider, FilterGraph);
		}

		public void BuildGraphWithAutoConnect(OutConnection outConnection)
		{
			ConnectOutputPins(outConnection);
		}

		private void ConnectOutputPins(OutConnection outConnection)
		{
			if (outConnection.OutputPins != null)
			{
				foreach (var outputPin in outConnection.OutputPins)
				{
					if (outputPin.ConnectedPort != null)
					{
						mediaConnector.ConnectDirect(outputPin.Filter.Name, outputPin.Name, outputPin.ConnectedPort.Filter.Name, outputPin.ConnectedPort.Name);
						ConnectOutputPins(outputPin.ConnectedPort.Filter as OutConnection);
					}
				}
			}
		}

		public void BuildGraphWithAutoConnect(IEnumerable<NamedFilterCreator> filterCreators)
		{
			RegisterFilters(filterCreators);

			var filters = filterProvider.Filters;
			for (int i = 0; i < filters.Count - 1; i++)
			{
				var filter = filters.Keys.ElementAt(i);
				var nextFilter = filters.Keys.ElementAt(i + 1);
				mediaConnector.ConnectDirect(filter, nextFilter);
			}
		}

		public void RegisterFilters(IEnumerable<NamedFilterCreator> filterCreators)
		{
			CreateGraphBuilder();

			foreach (var filterCreator in filterCreators)
			{
				var filter = filterProvider.CreateFilter(filterCreator);
				filterCreator.PostAction?.Invoke(filter);
			}
		}

		public void ManualConnect(string outputFilter, string ouputPinName, string inputFilter, string inputPinName)
		{
			mediaConnector.ConnectDirect(outputFilter, ouputPinName, inputFilter, inputPinName);
		}

		private void CreateGraphBuilder()
		{
			var captureGraphBuilder = (ICaptureGraphBuilder2)new CaptureGraphBuilder2();
			var statusCode = captureGraphBuilder.SetFiltergraph((IGraphBuilder)FilterGraph);
			errorHandler.ShowError(statusCode, "CaptureGraphBuilder SetFiltergraph execution error");
		}
	}

}
