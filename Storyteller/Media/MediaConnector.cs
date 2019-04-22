using DirectShowLib;
using System;

namespace Storyteller.Media
{
	public class MediaConnector
	{
		private readonly FilterProvider filterProvider;
		private readonly FilterGraph filterGraph;
		private readonly ErrorHandler errorHandler = new ErrorHandler();
		private readonly PinProvider pinProvider = new PinProvider();

		public MediaConnector(FilterProvider filterProvider, FilterGraph filterGraph)
		{
			this.filterProvider = filterProvider;
			this.filterGraph = filterGraph;
		}

		public void ConnectDirect(string upStreamFilterName, string downStreamFilterName)
		{
			ConnectDirect(upStreamFilterName, downStreamFilterName,
				(filter) => { return pinProvider.GetNextPin(filter, PinDirection.Output); },
				(filter) => { return pinProvider.GetNextPin(filter, PinDirection.Input); });
		}

		public void ConnectDirect(string upStreamFilterName, string upStreamOutputPinName, string downStreamFilterName, string downStreamInputPinName)
		{
			ConnectDirect(upStreamFilterName, downStreamFilterName,
				(filter) => { return pinProvider.GetPin(filter, upStreamOutputPinName); },
				(filter) => { return pinProvider.GetPin(filter, downStreamInputPinName); });
		}

		public void ConnectDirect(string upStreamFilterName, string downStreamFilterName, Func<IBaseFilter, IPin> OutputPinProvider, Func<IBaseFilter, IPin> InputPinProvider)
		{
			var upStreamFilter = filterProvider[upStreamFilterName];
			var downStreamFilter = filterProvider[downStreamFilterName];
			var upStreamOutputPin = OutputPinProvider(upStreamFilter);
			var downStreamInputPin = InputPinProvider(downStreamFilter);
			var hr = ConnectDirect(upStreamOutputPin, downStreamInputPin);
			errorHandler.ShowError(hr, $"Can't connect {upStreamFilterName} and {downStreamFilterName}");
		}

		private int ConnectDirect(IPin upStreamOutputPin, IPin downStreamInputPin, AMMediaType mediaType = null)
		{
			return ((IGraphBuilder)filterGraph).ConnectDirect(upStreamOutputPin, downStreamInputPin, mediaType);
		}
	}
}
