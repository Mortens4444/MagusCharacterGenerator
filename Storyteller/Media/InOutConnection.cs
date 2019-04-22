using System.Collections.Generic;

namespace Storyteller.Media
{
	public class InOutConnection : OutConnection
	{
		private IEnumerable<IInputPort> inputPins;

		public IEnumerable<IInputPort> InputPins
		{
			get => inputPins;
			set
			{
				if (inputPins != value)
				{
					inputPins = value;

					if (inputPins != null)
					{
						foreach (var inputPin in inputPins)
						{
							inputPin.Filter = this;
						}
					}
				}
			}
		}

		public InOutConnection(string name, IEnumerable<IInputPort> inputPins = null, IEnumerable<IOutputPort> outputPins = null)
			: base(name)
		{
			InputPins = inputPins;
			OutputPins = outputPins;
		}
	}
}
