using FontAwesome.Sharp;
using MagusCharacterGenerator.Castes;
using MagusCharacterGenerator.GameSystem;
using Microsoft.Win32;
using Mtf.Helper;
using Mtf.Languages;
using Mtf.Languages.Utils;
using Storyteller;
using Storyteller.Converter;
using Storyteller.Media;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace StoryTeller
{
	public partial class MainForm : Form
    {
		[DllImport("user32.dll", SetLastError = true)]
		static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		private CharcterGenerator charcterGenerator;
		public bool ChangeLanguage { get; private set; }

		public MainForm()
		{
			try
			{
				string keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
				string valueName = Path.GetFileName(Application.ExecutablePath);
				if (Registry.GetValue(keyName, valueName, null) == null)
				{
					Registry.SetValue(keyName, valueName, 32768, RegistryValueKind.DWord);
				}
			}
			catch
			{
				ErrorBox.Show(Lng.Elem("Registry write error"), Lng.Elem(@"You need to start the application with administrator right for the first time if you want to use the map functionality or create HKEY_LOCAL_MACHINE\SOFTWARE\[WOW6432Node\]Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION\Storyteller.exe REG_DWORD 0x8000 registry entries."));
			}

			InitializeComponent();

			LoadIcons();

			imageList.Images.Add("0", IconChar.Folder.ToBitmap(16, Color.DarkGoldenrod));
			imageList.Images.Add("1", IconChar.Image.ToBitmap(16, Color.ForestGreen));
			imageList.Images.Add("2", IconChar.FileAudio.ToBitmap(16, Color.LightSeaGreen));
			imageList.Images.Add("3", IconChar.User.ToBitmap(16, Color.BlanchedAlmond));

			DirectoryExtension.CreateApplicationDirectories();

			tvImages.Nodes.GetFilesAndFolders(PathProvider.Maps, 1, ExtensionProvider.ImagesFilter);
			tvMusic.Nodes.GetFilesAndFolders(PathProvider.Music, 2, ExtensionProvider.AudioFilter);
			tvSoundEffects.Nodes.GetFilesAndFolders(PathProvider.SoundEffects, 2, ExtensionProvider.AudioFilter);
			tvCharacters.Nodes.GetFilesAndFolders(PathProvider.Characters, 1, ExtensionProvider.ImagesFilter);
			tvVideoClips.Nodes.GetFilesAndFolders(PathProvider.VideoClips, 1, ExtensionProvider.VideoFilter);

			tvImages.ExpandAll();

			FillListViewGroup(lvMarket, "Accomodation");
			FillListViewGroup(lvMarket, "Animals");
			FillListViewGroup(lvMarket, "Clothes");
			FillListViewGroup(lvMarket, "Debauchery");
			FillListViewGroup(lvMarket, "Food");
			FillListViewGroup(lvMarket, "Other");
			FillListViewGroup(lvMarket, "Trappings");
			FillListViewGroup(lvMarket, "Travelling");

			GetLanguages();

			Lng.Translate(this);

			LoadStory(rtbStory);

			charcterGenerator = new CharcterGenerator
			{
				TopLevel = false,
				FormBorderStyle = FormBorderStyle.None,
				Dock = DockStyle.Fill
			};
			pCharacterContent.Controls.Add(charcterGenerator);
			charcterGenerator.Show();
		}

		private void GetLanguages()
		{
			var languages = Enum.GetNames(typeof(Language));
			foreach (var language in languages)
			{
				var menuItem = new ToolStripMenuItem(language);
				menuItem.Click += (object sender, EventArgs e) =>
				{
					var lng = (Language)Enum.Parse(typeof(Language), language);
					TranslationCore.ChangeToLanguage(lng);
					ChangeLanguage = true;
					Close();
				};
				tsmiLanguages.DropDownItems.Add(menuItem);
			}
		}

		private void LoadIcons()
		{
			Icon = IconCreator.Get(IconChar.BookReader, Color.Maroon);
			tsmiNew.Image = IconCreator.GetImage(IconChar.HackerNews);
			tsmiCharacter.Image = IconCreator.GetImage(IconChar.UserAlt);
			tsmiCharacterSheetOdt.Image = IconCreator.GetImage(IconChar.File);
			tsmiCharacterSheetPdf.Image = IconCreator.GetImage(IconChar.FilePdf);
			tsmiExit.Image = IconCreator.GetImage(IconChar.DoorOpen);
			tsmiHelp.Image = IconCreator.GetImage(IconChar.HandsHelping);
			tsmiAbout.Image = IconCreator.GetImage(IconChar.Info);
		}

		private void LoadStory(RichTextBox rtbStory)
		{
			var storyTxt = Path.Combine(Application.StartupPath, "story.txt");
			var storyRtf = Path.Combine(Application.StartupPath, "story.rtf");
			if (File.Exists(storyRtf))
			{
				try
				{
					rtbStory.LoadFile(storyRtf);
				}
				catch (Exception ex)
				{
					ErrorBox.Show(ex);
				}
			}
			else if (File.Exists(storyTxt))
			{
				rtbStory.Text = File.ReadAllText(storyTxt);
			}
			else
			{
				rtbStory.Text = String.Concat(Lng.Elem("There is no 'story.rtf' or 'story.txt' file in the folder: "), Application.StartupPath);
			}
		}

		private void FillListViewGroup(ListView listView, string listViewGroupName)
		{
			var types = typeof(Caste).GetTypesInNamespace($"MagusCharacterGenerator.Things.{listViewGroupName}");
			int index = 0;
			foreach (var type in types)
			{
				dynamic obj = Activator.CreateInstance(type);

				var listViewItem = new ListViewItem(obj.ToString());
				listViewItem.SubItems.Add(obj.Price.ToString());
				if (index++ % 2 == 0)
				{
					listViewItem.BackColor = Color.LightCyan;
				}
				var listViewGroup = listView.Groups[listViewGroupName];
				listViewItem.Group = listViewGroup;
				listView.Items.Add(listViewItem);
			}
		}

		private void TvMaps_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            pbImages.LoadImage(e.Node.Tag as string);
        }

        private void TvMaps_AfterSelect(object sender, TreeViewEventArgs e)
        {
            pbImages.LoadImage(e.Node.Tag as string);
        }

		private void TsmiCharacter_Click(object sender, EventArgs e)
		{
			var charcterGenerator = new CharcterGenerator(true);
			if (charcterGenerator.ShowDialog() == DialogResult.OK)
			{
				tvCharacters.Nodes.GetFilesAndFoldersWithClear(PathProvider.Characters, 1, ExtensionProvider.ImagesFilter);
			}
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			var fileSystemWatcher = new FileSystemWatcher(PathProvider.Characters);
			fileSystemWatcher.Changed += FileSystemWatcher_Changed;
			fileSystemWatcher.Created += FileSystemWatcher_Created;
			fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
			fileSystemWatcher.EnableRaisingEvents = true;
		}

		private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
		{
			//throw new NotImplementedException();
		}

		private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
		{
			//if (e.ChangeType == WatcherChangeTypes.Created && Path.GetDirectoryName(e.FullPath).Equals(PathProvider.Characters))
			//{
			//	Task.Factory.StartNew(() =>
			//	{
			//		Thread.Sleep(1000);
			//		var character = Character.Load(Path.Combine(e.FullPath, String.Concat("character", ExtensionProvider.CharacterSheetExtension)));
			//		var treeNode = TreeNodeCollectionExtensions.CreateNode(character.Name, e.FullPath, 3);
			//		tvCharacters.Invoke((MethodInvoker)(() =>
			//		{
			//			tvCharacters.Nodes.Add(treeNode);
			//		}));					
			//	});
			//}
		}

		private void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void TvMusic_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			PlayMusic(e.Node.Tag as string, chkMusicLoop.Checked, lvNowPlayingMusic);
		}

		private void TvSoundEffects_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			PlayMusic(e.Node.Tag as string, chkSoundsLoop.Checked, lvNowPlayingSounds);
		}

		private void PlayMusic(string filePath, bool loop, ListView listView)
		{
			if (!Directory.Exists(filePath))
			{
				var musicPlayer = new MusicPlayer(filePath);
				musicPlayer.Play(loop);
				musicPlayer.PlayStopped += (_, __) =>
				{
					listView.Items.RemoveByKey(musicPlayer.Id);
				};
				var item = MusicPlayerToListViewItem.Convert(musicPlayer);
				if (listView.Items.Count % 2 == 0)
				{
					item.BackColor = Color.LightCyan;
				}
				item.SubItems.Add(Lng.Elem(musicPlayer.Loop ? "Yes" : "No"));
				listView.Items.Add(item);
			}
		}

		private void TsmiRemoveMusic_Click(object sender, EventArgs e)
		{
			GeneralRemoveMusic(lvNowPlayingMusic);
		}

		private void TsmiRemoveSounds_Click(object sender, EventArgs e)
		{
			GeneralRemoveMusic(lvNowPlayingSounds);
		}

		private void GeneralRemoveMusic(ListView listView)
		{
			if (listView.SelectedItems != null)
			{
				foreach (ListViewItem selectedItem in listView.SelectedItems)
				{
					var musicPlayer = (MusicPlayer)selectedItem.Tag;
					musicPlayer.Stop();
					listView.Items.RemoveByKey(musicPlayer.Id);
				}
			}
		}

		private void TvVideoClips_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			//var filePath = @"D:\FEL3\Videojátékok - a modern szórakozás S01E01.avi";
			//var generalGraphBuilder = new GeneralGraphBuilder();

			////var connectedFilterProvider = new ConnectedFilterProvider();
			////var registeredFilters = connectedFilterProvider.GetAviPlayerFilters(filePath);
			////generalGraphBuilder.RegisterFilters(registeredFilters);

			//var filterGraph = (IGraphBuilder)generalGraphBuilder.FilterGraph;

			////var filterGraph = (IGraphBuilder)new FilterGraph();
			//var asyncReader = new AsyncReader();
			//((IFileSourceFilter)asyncReader).Load(filePath, null);
			//filterGraph.AddFilter((IBaseFilter)asyncReader, "File Source (Async.)");
			//filterGraph.AddFilter((IBaseFilter)new AviSplitter(), "AVI Splitter");
			//var DMOWrapperFilter = new DMOWrapperFilter();
			//var mpeg4sDecoderDmoGuid = new Guid("{2A11BAE2-FE6E-4249-864B-9E9ED6E8DBC2}");
			//var mpeg4sDecoderDmoCatGuid = new Guid("{4A69B442-28BE-4991-969C-B500ADF5D8A8}");
			//((IDMOWrapperFilter)DMOWrapperFilter).Init(mpeg4sDecoderDmoGuid, mpeg4sDecoderDmoCatGuid);
			//filterGraph.AddFilter((IBaseFilter)DMOWrapperFilter, "Mpeg4s Decoder DMO");
			//var videoRendererGuid = new Guid("{6BC1CFFA-8FC1-4261-AC22-CFB4CC38DB50}");
			//var videoRenderer = (IBaseFilter)Activator.CreateInstance(Type.GetTypeFromCLSID(videoRendererGuid));
			//filterGraph.AddFilter(videoRenderer, "Video Renderer");
			//var defaultWaveOutGuid = new Guid("{E0F158E1-CB04-11D0-BD4E-00A0C911CE86}");
			//var defaultWaveOut = (IBaseFilter)Activator.CreateInstance(Type.GetTypeFromCLSID(videoRendererGuid));
			//filterGraph.AddFilter(defaultWaveOut, "Default WaveOut Device");

			//var connections = GetConnections();

			//generalGraphBuilder.FilterGraph = (FilterGraph)filterGraph;
			//generalGraphBuilder.BuildGraphWithAutoConnect(connections);


			//IBaseFilter pSource;
			//var hr = filterGraph.AddSourceFilter(@"C:\SourceForge\mflib\Test\Media\AspectRatio4x3.wmv", null, out pSource);
			//DsError.ThrowExceptionForHR(hr);


			////Name: "Enhanced Video Renderer", // evr.dll
			////         Guid: new Guid("{FA10746C-9B63-4B6C-BC49-FC300EA5F256}")

			//new BaseFilterCreator("File Source (Async.)", (IBaseFilter)new AsyncReader(), (IBaseFilter filter) => { ((IFileSourceFilter)filter).Load(filePath, null); }),
			//         new BaseFilterCreator("AVI Splitter", (IBaseFilter)new AviSplitter()),
			//         new BaseFilterCreator("Mpeg4s Decoder DMO", (IBaseFilter)new DMOWrapperFilter(), (IBaseFilter filter) => { ((IDMOWrapperFilter)filter).Init(filterPropertyProvider.GetGuid(FilterType.Mpeg4sDecoderDmo), filterPropertyProvider.GetGuid(FilterType.Mpeg4sDecoderDmoCat)); }),
			//         //new BaseFilterCreator("Video Renderer", (IBaseFilter)new VideoRenderer()),
			//         var videoRendererGuid = new Guid("{6BC1CFFA-8FC1-4261-AC22-CFB4CC38DB50}");
			//(IBaseFilter)Activator.CreateInstance(Type.GetTypeFromCLSID(videoRendererGuid));

			//new NamedFilterCreator("Default WaveOut Device")

			//filterGraph.AddFilter(filter, filterName);
			//IBaseFilter pEVR = (IBaseFilter)new EnhancedVideoRenderer();
			//hr = filterGraph.AddFilter(pEVR, "EVR");

			//var typedGraphBuilder = new TypedGraphBuilder();
			//typedGraphBuilder.BuildAviPlayer(@"D:\FEL3\Videojátékok - a modern szórakozás S01E01.avi");
			////typedGraphBuilder.BuildAviPlayer(e.Node.Tag as string);

			//var mediaControl = (IMediaControl)typedGraphBuilder.FilterGraph;
			//mediaControl.Run();
			//var mediaEvent = (IMediaEvent)typedGraphBuilder.FilterGraph;
			//bool stop = false;
			//while (!stop)
			//{
			//	Thread.Sleep(500);
			//	Application.DoEvents();
			//	while (mediaEvent.GetEvent(out EventCode ev, out IntPtr p1, out IntPtr p2, 0) == 0)
			//	{
			//		if ((ev == EventCode.Complete) || (ev == EventCode.UserAbort) || (ev == EventCode.ErrorAbort))
			//		{
			//			stop = Stop(typedGraphBuilder);
			//			mediaEvent.FreeEventParams(ev, p1, p2);
			//		}

			//		//if ((ev == EventCode.Complete) || (ev == EventCode.UserAbort))
			//		//{
			//		//	typedGraphBuilder.Stop();
			//		//	mediaControl.Stop();
			//		//	stop = true;
			//		//}
			//		//else
			//		//{
			//		//	if (ev == EventCode.ErrorAbort)
			//		//	{
			//		//		typedGraphBuilder.Stop();
			//		//		mediaControl.Stop();
			//		//		stop = true;
			//		//	}
			//		//	mediaEvent.FreeEventParams(ev, p1, p2);
			//		//}
			//	}
			//}

			ProcessUtils.Start(e.Node.Tag as string);
		}

		//private OutConnection GetConnections()
		//{
		//	var fileSourceOutput = new OutputPort("Output");
		//	var fileSource = new OutConnection("File Source (Async.)")
		//	{
		//		OutputPins = new List<OutputPort> { fileSourceOutput }
		//	};

		//	var aviSplitterInput = new InputPort("input pin");
		//	var aviSplitterVideoStream = new OutputPort("Stream 00");
		//	var aviSplitterAudioStream = new OutputPort("Stream 01");
		//	var aviSplitter = new InOutConnection("AVI Splitter")
		//	{
		//		InputPins = new List<InputPort> { aviSplitterInput },
		//		OutputPins = new List<OutputPort> { aviSplitterVideoStream, aviSplitterAudioStream }
		//	};

		//	fileSourceOutput.ConnectedPort = aviSplitterInput;

		//	var mpegDecoderDmoInput = new InputPort("in0");
		//	var mpegDecoderDmoOutput = new OutputPort("out0");
		//	var mpegDecoderDmo = new InOutConnection("Mpeg4s Decoder DMO")
		//	{
		//		InputPins = new List<InputPort> { mpegDecoderDmoInput },
		//		OutputPins = new List<OutputPort> { mpegDecoderDmoOutput }
		//	};

		//	aviSplitterVideoStream.ConnectedPort = mpegDecoderDmoInput;

		//	var videoRendererInput = new InputPort("VMR Input0");
		//	var videoRenderer = new InOutConnection("Video Renderer")
		//	{
		//		InputPins = new List<InputPort> { videoRendererInput }
		//	};

		//	mpegDecoderDmoOutput.ConnectedPort = videoRendererInput;

		//	var audioRendererInput = new InputPort("Audio Input pin (rendered)");
		//	var audioRenderer = new InOutConnection("Default WaveOut Device")
		//	{
		//		InputPins = new List<InputPort> { audioRendererInput }
		//	};

		//	aviSplitterAudioStream.ConnectedPort = audioRendererInput;

		//	return fileSource;
		//}

		//private static bool Stop(TypedGraphBuilder typedGraphBuilder)
		//{
		//	typedGraphBuilder.Stop();
		//	var mediaControl = (IMediaControl)typedGraphBuilder.FilterGraph;
		//	mediaControl.Stop();
		//	return true;
		//}

		private void TsmiCharacterSheetOdt_Click(object sender, EventArgs e)
		{
			ProcessUtils.Start(Path.Combine(Application.StartupPath, @"CharacterSheet\M.A.G.U.S. Karakterlap.odt"));
		}

		private void TsmiCharacterSheetPdf_Click(object sender, EventArgs e)
		{
			ProcessUtils.Start(Path.Combine(Application.StartupPath, @"CharacterSheet\M.A.G.U.S. Karakterlap.pdf"));
		}

		private void TsmiExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void TsmiAbout_Click(object sender, EventArgs e)
		{
			var aboutForm = new AboutForm();
			aboutForm.ShowDialog();
		}

		private void TsmiGetSounds_Click(object sender, EventArgs e)
		{
			ProcessUtils.Start("https://freesound.org/browse/");
		}

		private void TsmiArkenForge_Click(object sender, EventArgs e)
		{
			ProcessUtils.Start("https://arkenforge.com/");
		}

		private void TsmiKranichWarlock_Click(object sender, EventArgs e)
		{
			ProcessUtils.Start("https://www.kalandozok.hu/magus/kalandozok/jatszhatokasztok/magiahasznalo/boszorkanymester/kraniboszorkanymester(mg)kalandozok.pdf");
		}

		private void TsmiNastarPriest_Click(object sender, EventArgs e)
		{
			ProcessUtils.Start("https://nemaakos.files.wordpress.com/2014/10/nastar2.pdf");
		}

		private void TsmiVelarPriest_Click(object sender, EventArgs e)
		{
			ProcessUtils.Start("https://nemaakos.files.wordpress.com/2015/12/velar.pdf");
		}

		private void TsmiWeapons_Click(object sender, EventArgs e)
		{
			ProcessUtils.Start("https://www.kalandozok.hu/magus/sarkanyvar/fegyverek/fegyverekesvertek(theelf)sarkanyvar.pdf?fref=gc");
		}

		private void TsmiHttpsKalandozokHu_Click(object sender, EventArgs e)
		{
			ProcessUtils.Start("https://kalandozok.hu/");
		}

		private void TvCharacters_AfterSelect(object sender, TreeViewEventArgs e)
		{
			var path = (string)e.Node.Tag;
			if (!Directory.Exists(path))
			{
				path = Directory.GetParent(path).FullName;
			}
			var characterFile = Path.Combine(path, String.Concat("character", ExtensionProvider.CharacterSheetExtension));
			if (File.Exists(characterFile))
			{
				var character = Character.Load(characterFile);
				charcterGenerator.LoadCharacter(character, (string)e.Node.Tag);
			}
		}

		private void RacesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ProcessUtils.Start("https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/");
		}

		private void ChkMusicFilter_CheckedChanged(object sender, EventArgs e)
		{
			ReloadMusicNodes();
		}

		private void TbMusicFilter_TextChanged(object sender, EventArgs e)
		{
			if (chkMusicFilter.Checked)
			{
				ReloadMusicNodes();
			}
		}

		private void ReloadMusicNodes()
		{
			tvMusic.Nodes.Clear();
			if (!chkMusicFilter.Checked)
			{
				tvMusic.Nodes.GetFilesAndFolders(PathProvider.Music, 2, ExtensionProvider.AudioFilter);
			}
			else
			{
				tvMusic.Nodes.GetFilesAndFolders(tbMusicFilter.Text, PathProvider.Music, 2, ExtensionProvider.AudioFilter);
			}
		}

		private void ChkSoundFilter_CheckedChanged(object sender, EventArgs e)
		{
			ReloadSoundNodes();
		}

		private void TbSoundFilter_TextChanged(object sender, EventArgs e)
		{
			if (chkSoundFilter.Checked)
			{
				ReloadSoundNodes();
			}
		}

		private void ReloadSoundNodes()
		{
			tvSoundEffects.Nodes.Clear();
			if (!chkSoundFilter.Checked)
			{
				tvSoundEffects.Nodes.GetFilesAndFolders(PathProvider.SoundEffects, 2, ExtensionProvider.AudioFilter);
			}
			else
			{
				tvSoundEffects.Nodes.GetFilesAndFolders(tbSoundFilter.Text, PathProvider.SoundEffects, 2, ExtensionProvider.AudioFilter);
			}
		}

		private void TsmiGoogle_Click(object sender, EventArgs e)
		{
			ProcessUtils.Start("https://www.google.com/search?biw=914&bih=451&tbs=sur%3Afc&tbm=isch&sa=1&ei=69l-XMe3A8ejwAL5qq2QDg&q=free+dungeons+and+dragons+characters&oq=free+dungeons+and+dragons+characters&gs_l=img.3...14077.17207..17433...0.0..0.74.683.10......1....1..gws-wiz-img.......0i19.EHlAQ8pWrA0");
		}

		private void TsmiPinterest_Click(object sender, EventArgs e)
		{
			ProcessUtils.Start("https://hu.pinterest.com/topics/fantasy-characters/");
		}

		private void RtbStory_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			var linkText = e.LinkText.Substring(1);
			if (e.LinkText.StartsWith("@"))
			{
				tabControl.SelectedTab = tabControl.TabPages["tpCharacters"];
				foreach (TreeNode characterNode in tvCharacters.Nodes)
				{
					if (characterNode.Text == linkText)
					{
						tvCharacters.SelectedNode = characterNode;
						break;
					}
				}
			}
		}
	}
}
