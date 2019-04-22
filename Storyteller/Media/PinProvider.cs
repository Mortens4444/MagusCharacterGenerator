using DirectShowLib;
using System;
using System.Runtime.InteropServices;

namespace Storyteller.Media
{
	public class PinProvider
	{
		private readonly ErrorHandler errorHandler = new ErrorHandler();

		public IPin GetNextPin(IBaseFilter filter, PinDirection pinDirection)
		{
			return GetPin(filter, (pinInfo) => { return pinInfo.dir == pinDirection; });
		}

		public IPin GetPin(IBaseFilter filter, string pinName)
		{
			return GetPin(filter, (pinInfo) => { return pinInfo.name == pinName; });
		}

		private IPin GetPin(IBaseFilter filter, Func<PinInfo, bool> SearchCriteria)
		{
			int statusCode = filter.EnumPins(out IEnumPins epins);
			errorHandler.ShowError(statusCode, "Can't enumerate pins");
			var fetched = Marshal.AllocCoTaskMem(4);
			var pins = new IPin[1];

			while (epins.Next(1, pins, fetched) == 0)
			{
				pins[0].QueryPinInfo(out PinInfo pinInfo);
				bool found = SearchCriteria(pinInfo);
				DsUtils.FreePinInfo(pinInfo);
				if (found)
				{
					return pins[0];
				}
			}
			errorHandler.ShowError(-1, "Pin not found");
			return null;
		}
	}
}
