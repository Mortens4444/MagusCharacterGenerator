using System;
using System.Collections.Generic;
using System.Linq;

namespace Storyteller.Media
{
	public class FilterInfoProvider
	{
		private static readonly Dictionary<FilterType, (string Name, Guid Guid)> filterProperties
			= new Dictionary<FilterType, (string Name, Guid Guid)>()
		{
			{
				FilterType.AudioRenderer,
				(
					Name: "Default WaveOut Device", // qedit.dll
                    Guid: new Guid("{E0F158E1-CB04-11D0-BD4E-00A0C911CE86}")
				)
			},
			{
				FilterType.Mpeg2Demultiplexer,
				(
					Name: "MPEG-2 Demultiplexer",
					Guid: new Guid("{AFB6C280-2C41-11D3-8A60-0000F81E0E4A}")
				)
			},
			{
				FilterType.Mpeg4sDecoderDmo,
				(
					Name: "Mpeg4s Decoder DMO", // DMO
                    Guid: new Guid("{2A11BAE2-FE6E-4249-864B-9E9ED6E8DBC2}")
				)
			},
			{
				FilterType.Mpeg4sDecoderDmoCat,
				(
					Name: "Mpeg4s Decoder DMO category", // DMO category
                    Guid: new Guid("{4A69B442-28BE-4991-969C-B500ADF5D8A8}")
				)
			},
			{
				FilterType.VideoRenderer,
				(
					Name: "Video Renderer", // quartz.dll
                    Guid: new Guid("{6BC1CFFA-8FC1-4261-AC22-CFB4CC38DB50}")
				)
			},
			{
				FilterType.FFDShowVideoDecoder,
				(
					Name: "ffdshow Video Decoder", // ffdshow                 
                    Guid: new Guid("{04FE9017-F873-410E-871E-AB91661A4EF7}")
				)
			},
			{
				FilterType.FFDShowAudioDecoder,
				(
					Name: "ffdshow Audio Decoder", // ffdshow                 
                    Guid: new Guid("{0F40E1E5-4F79-4988-B1A9-CC98794E6B55}")
				)
			},
			{
				FilterType.DefaultDirectSoundDevice,
				(
					Name: "Default DirectSound Device",
					Guid: new Guid("{E0F158E1-CB04-11D0-BD4E-00A0C911CE86}")
				)
			}
		};

		public string GetName(FilterType filterType)
		{
			return filterProperties[filterType].Name;
		}

		public Guid GetGuid(FilterType filterType)
		{
			return filterProperties[filterType].Guid;
		}

		public Guid GetGuid(string filterName)
		{
			var filterKeyValuePair = filterProperties.First(filter => filter.Value.Name == filterName);
			return filterKeyValuePair.Value.Guid;
		}

		public FilterType GetFilterType(string filterName)
		{
			var filterKeyValuePair = filterProperties.First(filter => filter.Value.Name == filterName);
			return filterKeyValuePair.Key;
		}
	}
}
