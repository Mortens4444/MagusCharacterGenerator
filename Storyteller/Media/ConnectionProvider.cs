namespace Storyteller.Media
{
	public class ConnectionProvider
	{
		public OutConnection GetAviPlayerConnection(List<NamedFilterCreator> namedFilterCreators)
		{
			var fileSourceOutput = new OutputPort("Output");
			var fileSource = new OutConnection(namedFilterCreators[0].Name)
			{
				OutputPins = new List<OutputPort> { fileSourceOutput }
			};

			var aviSplitterInput = new InputPort("input pin");
			var aviSplitterVideoStream = new OutputPort("Stream 00");
			var aviSplitterAudioStream = new OutputPort("Stream 01");
			var aviSplitter = new InOutConnection(namedFilterCreators[1].Name)
			{
				InputPins = new List<InputPort> { aviSplitterInput },
				OutputPins = new List<OutputPort> { aviSplitterVideoStream, aviSplitterAudioStream }
			};

			fileSourceOutput.ConnectedPort = aviSplitterInput;

			var mpegDecoderDmoInput = new InputPort("in0");
			var mpegDecoderDmoOutput = new OutputPort("out0");
			var mpegDecoderDmo = new InOutConnection(namedFilterCreators[2].Name)
			{
				InputPins = new List<InputPort> { mpegDecoderDmoInput },
				OutputPins = new List<OutputPort> { mpegDecoderDmoOutput }
			};

			aviSplitterVideoStream.ConnectedPort = mpegDecoderDmoInput;

			var videoRendererInput = new InputPort("VMR Input0");
			var videoRenderer = new InOutConnection(namedFilterCreators[3].Name)
			{
				InputPins = new List<InputPort> { videoRendererInput }
			};

			mpegDecoderDmoOutput.ConnectedPort = videoRendererInput;

			var audioRendererInput = new InputPort("Audio Input pin (rendered)");
			var audioRenderer = new InOutConnection(namedFilterCreators[4].Name)
			{
				InputPins = new List<InputPort> { audioRendererInput }
			};

			aviSplitterAudioStream.ConnectedPort = audioRendererInput;

			return fileSource;
		}

		public OutConnection GetMpegPlayerConnection(List<NamedFilterCreator> namedFilterCreators)
		{
			var fileSourceOutput = new OutputPort("Output");
			var fileSource = new OutConnection(namedFilterCreators[0].Name)
			{
				OutputPins = new List<OutputPort> { fileSourceOutput }
			};

			var mpeg2DemultiplexerInput = new InputPort("MPEG-2 Stream");
			var mpeg2DemultiplexerVideoOut = new OutputPort("Video");
			var mpeg2DemultiplexerAc3Out = new OutputPort("AC-3");
			var mpeg2Demultiplexer = new InOutConnection(namedFilterCreators[1].Name)
			{
				InputPins = new List<InputPort> { mpeg2DemultiplexerInput },
				OutputPins = new List<OutputPort> { mpeg2DemultiplexerVideoOut, mpeg2DemultiplexerAc3Out }
			};

			fileSourceOutput.ConnectedPort = mpeg2DemultiplexerInput;

			var ffdshowVideoDecoderInput = new InputPort("In");
			var ffdshowVideoDecoderOutput = new OutputPort("Out");
			var ffdshowVideoDecoder = new InOutConnection(namedFilterCreators[2].Name)
			{
				InputPins = new List<InputPort> { ffdshowVideoDecoderInput },
				OutputPins = new List<OutputPort> { ffdshowVideoDecoderOutput }
			};

			mpeg2DemultiplexerVideoOut.ConnectedPort = ffdshowVideoDecoderInput;

			var videoRendererInput = new InputPort("VMR Input0");
			var videoRenderer = new InOutConnection(namedFilterCreators[3].Name)
			{
				InputPins = new List<InputPort> { videoRendererInput }
			};

			ffdshowVideoDecoderOutput.ConnectedPort = videoRendererInput;

			var ffdshowAudioDecoderInput = new InputPort("In");
			var ffdshowAudioDecoderOutput = new OutputPort("Out");
			var ffdshowAudioDecoder = new InOutConnection(namedFilterCreators[4].Name)
			{
				InputPins = new List<InputPort> { ffdshowAudioDecoderInput }
			};

			mpeg2DemultiplexerAc3Out.ConnectedPort = ffdshowAudioDecoderInput;

			var audioRendererInput = new InputPort("Audio Input pin (rendered)");
			var audioRenderer = new InConnection(namedFilterCreators[5].Name)
			{
				InputPins = new List<InputPort> { audioRendererInput }
			};

			ffdshowAudioDecoderOutput.ConnectedPort = audioRendererInput;

			return fileSource;
		}
	}

}
