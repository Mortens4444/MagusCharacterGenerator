using DirectShowLib;

namespace Storyteller.Media
{
	public class ConnectedFilterProvider
	{
		private readonly FilterInfoProvider filterPropertyProvider = new FilterInfoProvider();

		public IEnumerable<NamedFilterCreator> GetAviPlayerFilters(string filePath)
		{
			return
            [
                new BaseFilterCreator("File Source (Async.)", (IBaseFilter)new AsyncReader(), (IBaseFilter filter) => { ((IFileSourceFilter)filter).Load(filePath, null); }),
				new BaseFilterCreator("AVI Splitter", (IBaseFilter)new AviSplitter()),
				new BaseFilterCreator("Mpeg4s Decoder DMO", (IBaseFilter)new DMOWrapperFilter(), (IBaseFilter filter) => { ((IDMOWrapperFilter)filter).Init(filterPropertyProvider.GetGuid(FilterType.Mpeg4sDecoderDmo), filterPropertyProvider.GetGuid(FilterType.Mpeg4sDecoderDmoCat)); }),
                //new BaseFilterCreator("Video Renderer", (IBaseFilter)new VideoRenderer()),
                new TypedFilterCreator(FilterType.VideoRenderer),
				new NamedFilterCreator("Default WaveOut Device")
			];
		}

		public IEnumerable<NamedFilterCreator> GetMpegPlayerFilters(string filePath)
		{
			return
            [
                new BaseFilterCreator("File Source (Async.)", (IBaseFilter)new AsyncReader(), (IBaseFilter filter) => { ((IFileSourceFilter)filter).Load(filePath, null); }),
				new TypedFilterCreator(FilterType.Mpeg2Demultiplexer),
				new TypedFilterCreator(FilterType.FFDShowVideoDecoder),
				new TypedFilterCreator(FilterType.VideoRenderer),
				new TypedFilterCreator(FilterType.FFDShowAudioDecoder),
				new NamedFilterCreator("Default DirectSound Device")
			];
		}
	}
}
