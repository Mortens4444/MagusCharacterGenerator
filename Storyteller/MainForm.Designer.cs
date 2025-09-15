namespace StoryTeller
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ListViewGroup listViewGroup1 = new ListViewGroup("Accomodation", HorizontalAlignment.Left);
            ListViewGroup listViewGroup2 = new ListViewGroup("Animals", HorizontalAlignment.Left);
            ListViewGroup listViewGroup3 = new ListViewGroup("Clothes", HorizontalAlignment.Left);
            ListViewGroup listViewGroup4 = new ListViewGroup("Debauchery", HorizontalAlignment.Left);
            ListViewGroup listViewGroup5 = new ListViewGroup("Food", HorizontalAlignment.Left);
            ListViewGroup listViewGroup6 = new ListViewGroup("Other", HorizontalAlignment.Left);
            ListViewGroup listViewGroup7 = new ListViewGroup("Trappings", HorizontalAlignment.Left);
            ListViewGroup listViewGroup8 = new ListViewGroup("Travelling", HorizontalAlignment.Left);
            menuStrip = new MenuStrip();
            tsmiNew = new ToolStripMenuItem();
            tsmiCharacter = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmiCharacterSheetOdt = new ToolStripMenuItem();
            tsmiCharacterSheetPdf = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            tsmiExit = new ToolStripMenuItem();
            tsmiAccessories = new ToolStripMenuItem();
            tsmiArkenForge = new ToolStripMenuItem();
            tsmiGetSounds = new ToolStripMenuItem();
            tsmiGetImages = new ToolStripMenuItem();
            tsmiGoogle = new ToolStripMenuItem();
            tsmiPinterest = new ToolStripMenuItem();
            tsmiCastes = new ToolStripMenuItem();
            tsmiKranichWarlock = new ToolStripMenuItem();
            tsmiNastarPriest = new ToolStripMenuItem();
            tsmiVelarPriest = new ToolStripMenuItem();
            tsmiOther = new ToolStripMenuItem();
            tsmiHttpsKalandozokHu = new ToolStripMenuItem();
            tsmiWeaponsAndArmors = new ToolStripMenuItem();
            racesToolStripMenuItem = new ToolStripMenuItem();
            tsmiSettings = new ToolStripMenuItem();
            tsmiLanguages = new ToolStripMenuItem();
            tsmiHelp = new ToolStripMenuItem();
            tsmiAbout = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            MainPanel = new Panel();
            tabControl = new TabControl();
            tpMap = new TabPage();
            wbMap = new WebBrowser();
            tpStory = new TabPage();
            pStory = new Panel();
            rtbStory = new RichTextBox();
            tpCharacters = new TabPage();
            pCharacters = new Panel();
            pCharacterContent = new Panel();
            splitter2 = new Splitter();
            pCharacterList = new Panel();
            tvCharacters = new TreeView();
            imageList = new ImageList(components);
            tpImages = new TabPage();
            pImages = new Panel();
            pImageContent = new Panel();
            pbImages = new PictureBox();
            splitter1 = new Splitter();
            pImagesLeft = new Panel();
            tvImages = new TreeView();
            tpVideoClips = new TabPage();
            pVideoClip = new Panel();
            pAllVideo = new Panel();
            tvVideoClips = new TreeView();
            tpMusic = new TabPage();
            panelMusic = new Panel();
            panelMusicContent = new Panel();
            pNowPlayingMusic = new Panel();
            gbNowPlayingMusic = new GroupBox();
            lvNowPlayingMusic = new ListView();
            chMusic = new ColumnHeader();
            chLoopMusic = new ColumnHeader();
            cmdMusicPlayControls = new ContextMenuStrip(components);
            tsmiRemoveMusic = new ToolStripMenuItem();
            splitter5 = new Splitter();
            pAllMusic = new Panel();
            gbAllMusic = new GroupBox();
            chkMusicFilter = new CheckBox();
            tbMusicFilter = new TextBox();
            chkMusicLoop = new CheckBox();
            tvMusic = new TreeView();
            tpSoundEffects = new TabPage();
            pSoundEffects = new Panel();
            panelSoundEffectsContent = new Panel();
            pNowPlayingSounds = new Panel();
            gbNowPlayingSounds = new GroupBox();
            lvNowPlayingSounds = new ListView();
            chSounds = new ColumnHeader();
            chLoop = new ColumnHeader();
            cmdSoundsPlayControls = new ContextMenuStrip(components);
            tsmiRemoveSounds = new ToolStripMenuItem();
            splitter4 = new Splitter();
            pAllSounds = new Panel();
            gbAllSounds = new GroupBox();
            chkSoundFilter = new CheckBox();
            tbSoundFilter = new TextBox();
            chkSoundsLoop = new CheckBox();
            tvSoundEffects = new TreeView();
            tpCombat = new TabPage();
            panelCombat = new Panel();
            panelCombatContent = new Panel();
            splitter3 = new Splitter();
            pAllCharacters = new Panel();
            tpMarket = new TabPage();
            lvMarket = new ListView();
            chName = new ColumnHeader();
            chPrice = new ColumnHeader();
            menuStrip.SuspendLayout();
            MainPanel.SuspendLayout();
            tabControl.SuspendLayout();
            tpMap.SuspendLayout();
            tpStory.SuspendLayout();
            pStory.SuspendLayout();
            tpCharacters.SuspendLayout();
            pCharacters.SuspendLayout();
            pCharacterList.SuspendLayout();
            tpImages.SuspendLayout();
            pImages.SuspendLayout();
            pImageContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbImages).BeginInit();
            pImagesLeft.SuspendLayout();
            tpVideoClips.SuspendLayout();
            pAllVideo.SuspendLayout();
            tpMusic.SuspendLayout();
            panelMusic.SuspendLayout();
            panelMusicContent.SuspendLayout();
            pNowPlayingMusic.SuspendLayout();
            gbNowPlayingMusic.SuspendLayout();
            cmdMusicPlayControls.SuspendLayout();
            pAllMusic.SuspendLayout();
            gbAllMusic.SuspendLayout();
            tpSoundEffects.SuspendLayout();
            pSoundEffects.SuspendLayout();
            panelSoundEffectsContent.SuspendLayout();
            pNowPlayingSounds.SuspendLayout();
            gbNowPlayingSounds.SuspendLayout();
            cmdSoundsPlayControls.SuspendLayout();
            pAllSounds.SuspendLayout();
            gbAllSounds.SuspendLayout();
            tpCombat.SuspendLayout();
            panelCombat.SuspendLayout();
            tpMarket.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { tsmiNew, tsmiAccessories, tsmiSettings, tsmiHelp });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 2, 0, 2);
            menuStrip.Size = new Size(933, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // tsmiNew
            // 
            tsmiNew.DropDownItems.AddRange(new ToolStripItem[] { tsmiCharacter, toolStripSeparator1, tsmiCharacterSheetOdt, tsmiCharacterSheetPdf, toolStripSeparator2, tsmiExit });
            tsmiNew.Name = "tsmiNew";
            tsmiNew.Size = new Size(43, 20);
            tsmiNew.Text = "New";
            // 
            // tsmiCharacter
            // 
            tsmiCharacter.Name = "tsmiCharacter";
            tsmiCharacter.Size = new Size(185, 22);
            tsmiCharacter.Text = "Character";
            tsmiCharacter.Click += TsmiCharacter_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(182, 6);
            // 
            // tsmiCharacterSheetOdt
            // 
            tsmiCharacterSheetOdt.Name = "tsmiCharacterSheetOdt";
            tsmiCharacterSheetOdt.Size = new Size(185, 22);
            tsmiCharacterSheetOdt.Text = "Character sheet (odt)";
            tsmiCharacterSheetOdt.Click += TsmiCharacterSheetOdt_Click;
            // 
            // tsmiCharacterSheetPdf
            // 
            tsmiCharacterSheetPdf.Name = "tsmiCharacterSheetPdf";
            tsmiCharacterSheetPdf.Size = new Size(185, 22);
            tsmiCharacterSheetPdf.Text = "Character sheet (pdf)";
            tsmiCharacterSheetPdf.Click += TsmiCharacterSheetPdf_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(182, 6);
            // 
            // tsmiExit
            // 
            tsmiExit.Name = "tsmiExit";
            tsmiExit.Size = new Size(185, 22);
            tsmiExit.Text = "Exit";
            tsmiExit.Click += TsmiExit_Click;
            // 
            // tsmiAccessories
            // 
            tsmiAccessories.DropDownItems.AddRange(new ToolStripItem[] { tsmiArkenForge, tsmiGetSounds, tsmiGetImages, tsmiCastes, tsmiOther });
            tsmiAccessories.Name = "tsmiAccessories";
            tsmiAccessories.Size = new Size(80, 20);
            tsmiAccessories.Text = "Accessories";
            // 
            // tsmiArkenForge
            // 
            tsmiArkenForge.Name = "tsmiArkenForge";
            tsmiArkenForge.Size = new Size(133, 22);
            tsmiArkenForge.Text = "Arkenforge";
            tsmiArkenForge.Click += TsmiArkenForge_Click;
            // 
            // tsmiGetSounds
            // 
            tsmiGetSounds.Name = "tsmiGetSounds";
            tsmiGetSounds.Size = new Size(133, 22);
            tsmiGetSounds.Text = "Get sounds";
            tsmiGetSounds.Click += TsmiGetSounds_Click;
            // 
            // tsmiGetImages
            // 
            tsmiGetImages.DropDownItems.AddRange(new ToolStripItem[] { tsmiGoogle, tsmiPinterest });
            tsmiGetImages.Name = "tsmiGetImages";
            tsmiGetImages.Size = new Size(133, 22);
            tsmiGetImages.Text = "Get images";
            // 
            // tsmiGoogle
            // 
            tsmiGoogle.Name = "tsmiGoogle";
            tsmiGoogle.Size = new Size(120, 22);
            tsmiGoogle.Text = "Google";
            tsmiGoogle.Click += TsmiGoogle_Click;
            // 
            // tsmiPinterest
            // 
            tsmiPinterest.Name = "tsmiPinterest";
            tsmiPinterest.Size = new Size(120, 22);
            tsmiPinterest.Text = "Pinterest";
            tsmiPinterest.Click += TsmiPinterest_Click;
            // 
            // tsmiCastes
            // 
            tsmiCastes.DropDownItems.AddRange(new ToolStripItem[] { tsmiKranichWarlock, tsmiNastarPriest, tsmiVelarPriest });
            tsmiCastes.Name = "tsmiCastes";
            tsmiCastes.Size = new Size(133, 22);
            tsmiCastes.Text = "Castes";
            // 
            // tsmiKranichWarlock
            // 
            tsmiKranichWarlock.Name = "tsmiKranichWarlock";
            tsmiKranichWarlock.Size = new Size(158, 22);
            tsmiKranichWarlock.Text = "Kranich warlock";
            tsmiKranichWarlock.Click += TsmiKranichWarlock_Click;
            // 
            // tsmiNastarPriest
            // 
            tsmiNastarPriest.Name = "tsmiNastarPriest";
            tsmiNastarPriest.Size = new Size(158, 22);
            tsmiNastarPriest.Text = "Nastar priest";
            tsmiNastarPriest.Click += TsmiNastarPriest_Click;
            // 
            // tsmiVelarPriest
            // 
            tsmiVelarPriest.Name = "tsmiVelarPriest";
            tsmiVelarPriest.Size = new Size(158, 22);
            tsmiVelarPriest.Text = "Velar priest";
            tsmiVelarPriest.Click += TsmiVelarPriest_Click;
            // 
            // tsmiOther
            // 
            tsmiOther.DropDownItems.AddRange(new ToolStripItem[] { tsmiHttpsKalandozokHu, tsmiWeaponsAndArmors, racesToolStripMenuItem });
            tsmiOther.Name = "tsmiOther";
            tsmiOther.Size = new Size(133, 22);
            tsmiOther.Text = "Other";
            // 
            // tsmiHttpsKalandozokHu
            // 
            tsmiHttpsKalandozokHu.Name = "tsmiHttpsKalandozokHu";
            tsmiHttpsKalandozokHu.Size = new Size(196, 22);
            tsmiHttpsKalandozokHu.Text = "https://kalandozok.hu/";
            tsmiHttpsKalandozokHu.Click += TsmiHttpsKalandozokHu_Click;
            // 
            // tsmiWeaponsAndArmors
            // 
            tsmiWeaponsAndArmors.Name = "tsmiWeaponsAndArmors";
            tsmiWeaponsAndArmors.Size = new Size(196, 22);
            tsmiWeaponsAndArmors.Text = "Weapons and armors";
            tsmiWeaponsAndArmors.Click += TsmiWeapons_Click;
            // 
            // racesToolStripMenuItem
            // 
            racesToolStripMenuItem.Name = "racesToolStripMenuItem";
            racesToolStripMenuItem.Size = new Size(196, 22);
            racesToolStripMenuItem.Text = "Races";
            racesToolStripMenuItem.Click += RacesToolStripMenuItem_Click;
            // 
            // tsmiSettings
            // 
            tsmiSettings.DropDownItems.AddRange(new ToolStripItem[] { tsmiLanguages });
            tsmiSettings.Name = "tsmiSettings";
            tsmiSettings.Size = new Size(61, 20);
            tsmiSettings.Text = "Settings";
            // 
            // tsmiLanguages
            // 
            tsmiLanguages.Name = "tsmiLanguages";
            tsmiLanguages.Size = new Size(131, 22);
            tsmiLanguages.Text = "Languages";
            // 
            // tsmiHelp
            // 
            tsmiHelp.DropDownItems.AddRange(new ToolStripItem[] { tsmiAbout });
            tsmiHelp.Name = "tsmiHelp";
            tsmiHelp.Size = new Size(44, 20);
            tsmiHelp.Text = "Help";
            // 
            // tsmiAbout
            // 
            tsmiAbout.Name = "tsmiAbout";
            tsmiAbout.Size = new Size(107, 22);
            tsmiAbout.Text = "About";
            tsmiAbout.Click += TsmiAbout_Click;
            // 
            // statusStrip
            // 
            statusStrip.Location = new Point(0, 652);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(933, 22);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip1";
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(tabControl);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 24);
            MainPanel.Margin = new Padding(4, 3, 4, 3);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(933, 628);
            MainPanel.TabIndex = 2;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tpMap);
            tabControl.Controls.Add(tpStory);
            tabControl.Controls.Add(tpCharacters);
            tabControl.Controls.Add(tpImages);
            tabControl.Controls.Add(tpVideoClips);
            tabControl.Controls.Add(tpMusic);
            tabControl.Controls.Add(tpSoundEffects);
            tabControl.Controls.Add(tpCombat);
            tabControl.Controls.Add(tpMarket);
            tabControl.Dock = DockStyle.Fill;
            tabControl.ImageList = imageList;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(4, 3, 4, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(933, 628);
            tabControl.TabIndex = 0;
            // 
            // tpMap
            // 
            tpMap.Controls.Add(wbMap);
            tpMap.Location = new Point(4, 24);
            tpMap.Margin = new Padding(4, 3, 4, 3);
            tpMap.Name = "tpMap";
            tpMap.Padding = new Padding(4, 3, 4, 3);
            tpMap.Size = new Size(925, 600);
            tpMap.TabIndex = 8;
            tpMap.Text = "Map";
            tpMap.UseVisualStyleBackColor = true;
            // 
            // wbMap
            // 
            wbMap.Dock = DockStyle.Fill;
            wbMap.Location = new Point(4, 3);
            wbMap.Margin = new Padding(4, 3, 4, 3);
            wbMap.MinimumSize = new Size(23, 23);
            wbMap.Name = "wbMap";
            wbMap.ScriptErrorsSuppressed = true;
            wbMap.Size = new Size(917, 594);
            wbMap.TabIndex = 0;
            wbMap.Url = new Uri("https://kalandozok.hu/ynev/", UriKind.Absolute);
            // 
            // tpStory
            // 
            tpStory.Controls.Add(pStory);
            tpStory.Location = new Point(4, 24);
            tpStory.Margin = new Padding(4, 3, 4, 3);
            tpStory.Name = "tpStory";
            tpStory.Padding = new Padding(4, 3, 4, 3);
            tpStory.Size = new Size(925, 600);
            tpStory.TabIndex = 6;
            tpStory.Text = "Story";
            tpStory.UseVisualStyleBackColor = true;
            // 
            // pStory
            // 
            pStory.Controls.Add(rtbStory);
            pStory.Dock = DockStyle.Fill;
            pStory.Location = new Point(4, 3);
            pStory.Margin = new Padding(4, 3, 4, 3);
            pStory.Name = "pStory";
            pStory.Size = new Size(917, 594);
            pStory.TabIndex = 0;
            // 
            // rtbStory
            // 
            rtbStory.Dock = DockStyle.Fill;
            rtbStory.Location = new Point(0, 0);
            rtbStory.Margin = new Padding(4, 3, 4, 3);
            rtbStory.Name = "rtbStory";
            rtbStory.Size = new Size(917, 594);
            rtbStory.TabIndex = 0;
            rtbStory.Text = "";
            rtbStory.LinkClicked += RtbStory_LinkClicked;
            // 
            // tpCharacters
            // 
            tpCharacters.Controls.Add(pCharacters);
            tpCharacters.Location = new Point(4, 24);
            tpCharacters.Margin = new Padding(4, 3, 4, 3);
            tpCharacters.Name = "tpCharacters";
            tpCharacters.Padding = new Padding(4, 3, 4, 3);
            tpCharacters.Size = new Size(925, 600);
            tpCharacters.TabIndex = 3;
            tpCharacters.Text = "Characters";
            tpCharacters.UseVisualStyleBackColor = true;
            // 
            // pCharacters
            // 
            pCharacters.Controls.Add(pCharacterContent);
            pCharacters.Controls.Add(splitter2);
            pCharacters.Controls.Add(pCharacterList);
            pCharacters.Dock = DockStyle.Fill;
            pCharacters.Location = new Point(4, 3);
            pCharacters.Margin = new Padding(4, 3, 4, 3);
            pCharacters.Name = "pCharacters";
            pCharacters.Size = new Size(917, 594);
            pCharacters.TabIndex = 0;
            // 
            // pCharacterContent
            // 
            pCharacterContent.Dock = DockStyle.Fill;
            pCharacterContent.Location = new Point(286, 0);
            pCharacterContent.Margin = new Padding(4, 3, 4, 3);
            pCharacterContent.Name = "pCharacterContent";
            pCharacterContent.Size = new Size(631, 594);
            pCharacterContent.TabIndex = 2;
            // 
            // splitter2
            // 
            splitter2.Location = new Point(282, 0);
            splitter2.Margin = new Padding(4, 3, 4, 3);
            splitter2.Name = "splitter2";
            splitter2.Size = new Size(4, 594);
            splitter2.TabIndex = 1;
            splitter2.TabStop = false;
            // 
            // pCharacterList
            // 
            pCharacterList.Controls.Add(tvCharacters);
            pCharacterList.Dock = DockStyle.Left;
            pCharacterList.Location = new Point(0, 0);
            pCharacterList.Margin = new Padding(4, 3, 4, 3);
            pCharacterList.Name = "pCharacterList";
            pCharacterList.Size = new Size(282, 594);
            pCharacterList.TabIndex = 0;
            // 
            // tvCharacters
            // 
            tvCharacters.Dock = DockStyle.Fill;
            tvCharacters.ImageIndex = 0;
            tvCharacters.ImageList = imageList;
            tvCharacters.Location = new Point(0, 0);
            tvCharacters.Margin = new Padding(4, 3, 4, 3);
            tvCharacters.Name = "tvCharacters";
            tvCharacters.SelectedImageIndex = 0;
            tvCharacters.Size = new Size(282, 594);
            tvCharacters.TabIndex = 0;
            tvCharacters.AfterSelect += TvCharacters_AfterSelect;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth8Bit;
            imageList.ImageSize = new Size(16, 16);
            imageList.TransparentColor = Color.Transparent;
            // 
            // tpImages
            // 
            tpImages.Controls.Add(pImages);
            tpImages.Location = new Point(4, 24);
            tpImages.Margin = new Padding(4, 3, 4, 3);
            tpImages.Name = "tpImages";
            tpImages.Padding = new Padding(4, 3, 4, 3);
            tpImages.Size = new Size(925, 600);
            tpImages.TabIndex = 0;
            tpImages.Text = "Images";
            tpImages.UseVisualStyleBackColor = true;
            // 
            // pImages
            // 
            pImages.Controls.Add(pImageContent);
            pImages.Controls.Add(splitter1);
            pImages.Controls.Add(pImagesLeft);
            pImages.Dock = DockStyle.Fill;
            pImages.Location = new Point(4, 3);
            pImages.Margin = new Padding(4, 3, 4, 3);
            pImages.Name = "pImages";
            pImages.Size = new Size(917, 594);
            pImages.TabIndex = 0;
            // 
            // pImageContent
            // 
            pImageContent.Controls.Add(pbImages);
            pImageContent.Dock = DockStyle.Fill;
            pImageContent.Location = new Point(286, 0);
            pImageContent.Margin = new Padding(4, 3, 4, 3);
            pImageContent.Name = "pImageContent";
            pImageContent.Size = new Size(631, 594);
            pImageContent.TabIndex = 2;
            // 
            // pbImages
            // 
            pbImages.Dock = DockStyle.Fill;
            pbImages.Location = new Point(0, 0);
            pbImages.Margin = new Padding(4, 3, 4, 3);
            pbImages.Name = "pbImages";
            pbImages.Size = new Size(631, 594);
            pbImages.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImages.TabIndex = 0;
            pbImages.TabStop = false;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(282, 0);
            splitter1.Margin = new Padding(4, 3, 4, 3);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(4, 594);
            splitter1.TabIndex = 1;
            splitter1.TabStop = false;
            // 
            // pImagesLeft
            // 
            pImagesLeft.Controls.Add(tvImages);
            pImagesLeft.Dock = DockStyle.Left;
            pImagesLeft.Location = new Point(0, 0);
            pImagesLeft.Margin = new Padding(4, 3, 4, 3);
            pImagesLeft.Name = "pImagesLeft";
            pImagesLeft.Size = new Size(282, 594);
            pImagesLeft.TabIndex = 0;
            // 
            // tvImages
            // 
            tvImages.Dock = DockStyle.Fill;
            tvImages.ImageIndex = 0;
            tvImages.ImageList = imageList;
            tvImages.Location = new Point(0, 0);
            tvImages.Margin = new Padding(4, 3, 4, 3);
            tvImages.Name = "tvImages";
            tvImages.SelectedImageIndex = 0;
            tvImages.Size = new Size(282, 594);
            tvImages.TabIndex = 0;
            tvImages.AfterSelect += TvMaps_AfterSelect;
            tvImages.NodeMouseClick += TvMaps_NodeMouseClick;
            // 
            // tpVideoClips
            // 
            tpVideoClips.Controls.Add(pVideoClip);
            tpVideoClips.Controls.Add(pAllVideo);
            tpVideoClips.Location = new Point(4, 24);
            tpVideoClips.Margin = new Padding(4, 3, 4, 3);
            tpVideoClips.Name = "tpVideoClips";
            tpVideoClips.Padding = new Padding(4, 3, 4, 3);
            tpVideoClips.Size = new Size(925, 600);
            tpVideoClips.TabIndex = 5;
            tpVideoClips.Text = "Video clips";
            tpVideoClips.UseVisualStyleBackColor = true;
            // 
            // pVideoClip
            // 
            pVideoClip.Dock = DockStyle.Fill;
            pVideoClip.Location = new Point(286, 3);
            pVideoClip.Margin = new Padding(4, 3, 4, 3);
            pVideoClip.Name = "pVideoClip";
            pVideoClip.Size = new Size(635, 594);
            pVideoClip.TabIndex = 3;
            // 
            // pAllVideo
            // 
            pAllVideo.Controls.Add(tvVideoClips);
            pAllVideo.Dock = DockStyle.Left;
            pAllVideo.Location = new Point(4, 3);
            pAllVideo.Margin = new Padding(4, 3, 4, 3);
            pAllVideo.Name = "pAllVideo";
            pAllVideo.Size = new Size(282, 594);
            pAllVideo.TabIndex = 2;
            // 
            // tvVideoClips
            // 
            tvVideoClips.Dock = DockStyle.Fill;
            tvVideoClips.ImageIndex = 0;
            tvVideoClips.ImageList = imageList;
            tvVideoClips.Location = new Point(0, 0);
            tvVideoClips.Margin = new Padding(4, 3, 4, 3);
            tvVideoClips.Name = "tvVideoClips";
            tvVideoClips.SelectedImageIndex = 0;
            tvVideoClips.Size = new Size(282, 594);
            tvVideoClips.TabIndex = 0;
            tvVideoClips.NodeMouseDoubleClick += TvVideoClips_NodeMouseDoubleClick;
            // 
            // tpMusic
            // 
            tpMusic.Controls.Add(panelMusic);
            tpMusic.Location = new Point(4, 24);
            tpMusic.Margin = new Padding(4, 3, 4, 3);
            tpMusic.Name = "tpMusic";
            tpMusic.Padding = new Padding(4, 3, 4, 3);
            tpMusic.Size = new Size(925, 600);
            tpMusic.TabIndex = 1;
            tpMusic.Text = "Music";
            tpMusic.UseVisualStyleBackColor = true;
            // 
            // panelMusic
            // 
            panelMusic.Controls.Add(panelMusicContent);
            panelMusic.Controls.Add(splitter5);
            panelMusic.Controls.Add(pAllMusic);
            panelMusic.Dock = DockStyle.Fill;
            panelMusic.Location = new Point(4, 3);
            panelMusic.Margin = new Padding(4, 3, 4, 3);
            panelMusic.Name = "panelMusic";
            panelMusic.Size = new Size(917, 594);
            panelMusic.TabIndex = 1;
            // 
            // panelMusicContent
            // 
            panelMusicContent.Controls.Add(pNowPlayingMusic);
            panelMusicContent.Dock = DockStyle.Fill;
            panelMusicContent.Location = new Point(286, 0);
            panelMusicContent.Margin = new Padding(4, 3, 4, 3);
            panelMusicContent.Name = "panelMusicContent";
            panelMusicContent.Size = new Size(631, 594);
            panelMusicContent.TabIndex = 3;
            // 
            // pNowPlayingMusic
            // 
            pNowPlayingMusic.Controls.Add(gbNowPlayingMusic);
            pNowPlayingMusic.Dock = DockStyle.Left;
            pNowPlayingMusic.Location = new Point(0, 0);
            pNowPlayingMusic.Margin = new Padding(4, 3, 4, 3);
            pNowPlayingMusic.Name = "pNowPlayingMusic";
            pNowPlayingMusic.Size = new Size(286, 594);
            pNowPlayingMusic.TabIndex = 0;
            // 
            // gbNowPlayingMusic
            // 
            gbNowPlayingMusic.Controls.Add(lvNowPlayingMusic);
            gbNowPlayingMusic.Dock = DockStyle.Fill;
            gbNowPlayingMusic.Location = new Point(0, 0);
            gbNowPlayingMusic.Margin = new Padding(4, 3, 4, 3);
            gbNowPlayingMusic.Name = "gbNowPlayingMusic";
            gbNowPlayingMusic.Padding = new Padding(4, 3, 4, 3);
            gbNowPlayingMusic.Size = new Size(286, 594);
            gbNowPlayingMusic.TabIndex = 0;
            gbNowPlayingMusic.TabStop = false;
            gbNowPlayingMusic.Text = "Now playing";
            // 
            // lvNowPlayingMusic
            // 
            lvNowPlayingMusic.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvNowPlayingMusic.Columns.AddRange(new ColumnHeader[] { chMusic, chLoopMusic });
            lvNowPlayingMusic.ContextMenuStrip = cmdMusicPlayControls;
            lvNowPlayingMusic.FullRowSelect = true;
            lvNowPlayingMusic.Location = new Point(4, 57);
            lvNowPlayingMusic.Margin = new Padding(4, 3, 4, 3);
            lvNowPlayingMusic.Name = "lvNowPlayingMusic";
            lvNowPlayingMusic.Size = new Size(278, 533);
            lvNowPlayingMusic.TabIndex = 0;
            lvNowPlayingMusic.UseCompatibleStateImageBehavior = false;
            lvNowPlayingMusic.View = View.Details;
            // 
            // chMusic
            // 
            chMusic.Text = "Music";
            chMusic.Width = 177;
            // 
            // chLoopMusic
            // 
            chLoopMusic.Text = "Loop";
            // 
            // cmdMusicPlayControls
            // 
            cmdMusicPlayControls.Items.AddRange(new ToolStripItem[] { tsmiRemoveMusic });
            cmdMusicPlayControls.Name = "cmdMusicPlayControls";
            cmdMusicPlayControls.Size = new Size(153, 26);
            // 
            // tsmiRemoveMusic
            // 
            tsmiRemoveMusic.Name = "tsmiRemoveMusic";
            tsmiRemoveMusic.Size = new Size(152, 22);
            tsmiRemoveMusic.Text = "Remove music";
            tsmiRemoveMusic.Click += TsmiRemoveMusic_Click;
            // 
            // splitter5
            // 
            splitter5.Location = new Point(282, 0);
            splitter5.Margin = new Padding(4, 3, 4, 3);
            splitter5.Name = "splitter5";
            splitter5.Size = new Size(4, 594);
            splitter5.TabIndex = 2;
            splitter5.TabStop = false;
            // 
            // pAllMusic
            // 
            pAllMusic.Controls.Add(gbAllMusic);
            pAllMusic.Dock = DockStyle.Left;
            pAllMusic.Location = new Point(0, 0);
            pAllMusic.Margin = new Padding(4, 3, 4, 3);
            pAllMusic.Name = "pAllMusic";
            pAllMusic.Size = new Size(282, 594);
            pAllMusic.TabIndex = 1;
            // 
            // gbAllMusic
            // 
            gbAllMusic.Controls.Add(chkMusicFilter);
            gbAllMusic.Controls.Add(tbMusicFilter);
            gbAllMusic.Controls.Add(chkMusicLoop);
            gbAllMusic.Controls.Add(tvMusic);
            gbAllMusic.Dock = DockStyle.Fill;
            gbAllMusic.Location = new Point(0, 0);
            gbAllMusic.Margin = new Padding(4, 3, 4, 3);
            gbAllMusic.Name = "gbAllMusic";
            gbAllMusic.Padding = new Padding(4, 3, 4, 3);
            gbAllMusic.Size = new Size(282, 594);
            gbAllMusic.TabIndex = 0;
            gbAllMusic.TabStop = false;
            gbAllMusic.Text = "All music";
            // 
            // chkMusicFilter
            // 
            chkMusicFilter.AutoSize = true;
            chkMusicFilter.Location = new Point(149, 8);
            chkMusicFilter.Margin = new Padding(4, 3, 4, 3);
            chkMusicFilter.Name = "chkMusicFilter";
            chkMusicFilter.Size = new Size(52, 19);
            chkMusicFilter.TabIndex = 7;
            chkMusicFilter.Text = "Filter";
            chkMusicFilter.UseVisualStyleBackColor = true;
            chkMusicFilter.CheckedChanged += ChkMusicFilter_CheckedChanged;
            // 
            // tbMusicFilter
            // 
            tbMusicFilter.Location = new Point(149, 30);
            tbMusicFilter.Margin = new Padding(4, 3, 4, 3);
            tbMusicFilter.Name = "tbMusicFilter";
            tbMusicFilter.Size = new Size(129, 23);
            tbMusicFilter.TabIndex = 2;
            tbMusicFilter.TextChanged += TbMusicFilter_TextChanged;
            // 
            // chkMusicLoop
            // 
            chkMusicLoop.AutoSize = true;
            chkMusicLoop.Location = new Point(7, 30);
            chkMusicLoop.Margin = new Padding(4, 3, 4, 3);
            chkMusicLoop.Name = "chkMusicLoop";
            chkMusicLoop.Size = new Size(53, 19);
            chkMusicLoop.TabIndex = 1;
            chkMusicLoop.Text = "Loop";
            chkMusicLoop.UseVisualStyleBackColor = true;
            // 
            // tvMusic
            // 
            tvMusic.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tvMusic.FullRowSelect = true;
            tvMusic.ImageIndex = 0;
            tvMusic.ImageList = imageList;
            tvMusic.Location = new Point(4, 57);
            tvMusic.Margin = new Padding(4, 3, 4, 3);
            tvMusic.Name = "tvMusic";
            tvMusic.SelectedImageIndex = 0;
            tvMusic.Size = new Size(275, 533);
            tvMusic.TabIndex = 0;
            tvMusic.NodeMouseDoubleClick += TvMusic_NodeMouseDoubleClick;
            // 
            // tpSoundEffects
            // 
            tpSoundEffects.Controls.Add(pSoundEffects);
            tpSoundEffects.Location = new Point(4, 24);
            tpSoundEffects.Margin = new Padding(4, 3, 4, 3);
            tpSoundEffects.Name = "tpSoundEffects";
            tpSoundEffects.Padding = new Padding(4, 3, 4, 3);
            tpSoundEffects.Size = new Size(925, 600);
            tpSoundEffects.TabIndex = 4;
            tpSoundEffects.Text = "Sound effects";
            tpSoundEffects.UseVisualStyleBackColor = true;
            // 
            // pSoundEffects
            // 
            pSoundEffects.Controls.Add(panelSoundEffectsContent);
            pSoundEffects.Controls.Add(splitter4);
            pSoundEffects.Controls.Add(pAllSounds);
            pSoundEffects.Dock = DockStyle.Fill;
            pSoundEffects.Location = new Point(4, 3);
            pSoundEffects.Margin = new Padding(4, 3, 4, 3);
            pSoundEffects.Name = "pSoundEffects";
            pSoundEffects.Size = new Size(917, 594);
            pSoundEffects.TabIndex = 1;
            // 
            // panelSoundEffectsContent
            // 
            panelSoundEffectsContent.Controls.Add(pNowPlayingSounds);
            panelSoundEffectsContent.Dock = DockStyle.Fill;
            panelSoundEffectsContent.Location = new Point(286, 0);
            panelSoundEffectsContent.Margin = new Padding(4, 3, 4, 3);
            panelSoundEffectsContent.Name = "panelSoundEffectsContent";
            panelSoundEffectsContent.Size = new Size(631, 594);
            panelSoundEffectsContent.TabIndex = 3;
            // 
            // pNowPlayingSounds
            // 
            pNowPlayingSounds.Controls.Add(gbNowPlayingSounds);
            pNowPlayingSounds.Dock = DockStyle.Left;
            pNowPlayingSounds.Location = new Point(0, 0);
            pNowPlayingSounds.Margin = new Padding(4, 3, 4, 3);
            pNowPlayingSounds.Name = "pNowPlayingSounds";
            pNowPlayingSounds.Size = new Size(286, 594);
            pNowPlayingSounds.TabIndex = 1;
            // 
            // gbNowPlayingSounds
            // 
            gbNowPlayingSounds.Controls.Add(lvNowPlayingSounds);
            gbNowPlayingSounds.Dock = DockStyle.Fill;
            gbNowPlayingSounds.Location = new Point(0, 0);
            gbNowPlayingSounds.Margin = new Padding(4, 3, 4, 3);
            gbNowPlayingSounds.Name = "gbNowPlayingSounds";
            gbNowPlayingSounds.Padding = new Padding(4, 3, 4, 3);
            gbNowPlayingSounds.Size = new Size(286, 594);
            gbNowPlayingSounds.TabIndex = 0;
            gbNowPlayingSounds.TabStop = false;
            gbNowPlayingSounds.Text = "Now playing";
            // 
            // lvNowPlayingSounds
            // 
            lvNowPlayingSounds.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvNowPlayingSounds.Columns.AddRange(new ColumnHeader[] { chSounds, chLoop });
            lvNowPlayingSounds.ContextMenuStrip = cmdSoundsPlayControls;
            lvNowPlayingSounds.FullRowSelect = true;
            lvNowPlayingSounds.Location = new Point(4, 57);
            lvNowPlayingSounds.Margin = new Padding(4, 3, 4, 3);
            lvNowPlayingSounds.Name = "lvNowPlayingSounds";
            lvNowPlayingSounds.Size = new Size(278, 533);
            lvNowPlayingSounds.TabIndex = 0;
            lvNowPlayingSounds.UseCompatibleStateImageBehavior = false;
            lvNowPlayingSounds.View = View.Details;
            // 
            // chSounds
            // 
            chSounds.Text = "Sounds";
            chSounds.Width = 177;
            // 
            // chLoop
            // 
            chLoop.Text = "Loop";
            // 
            // cmdSoundsPlayControls
            // 
            cmdSoundsPlayControls.Items.AddRange(new ToolStripItem[] { tsmiRemoveSounds });
            cmdSoundsPlayControls.Name = "cmdMusicPlayControls";
            cmdSoundsPlayControls.Size = new Size(167, 26);
            // 
            // tsmiRemoveSounds
            // 
            tsmiRemoveSounds.Name = "tsmiRemoveSounds";
            tsmiRemoveSounds.Size = new Size(166, 22);
            tsmiRemoveSounds.Text = "Remove sound(s)";
            tsmiRemoveSounds.Click += TsmiRemoveSounds_Click;
            // 
            // splitter4
            // 
            splitter4.Location = new Point(282, 0);
            splitter4.Margin = new Padding(4, 3, 4, 3);
            splitter4.Name = "splitter4";
            splitter4.Size = new Size(4, 594);
            splitter4.TabIndex = 2;
            splitter4.TabStop = false;
            // 
            // pAllSounds
            // 
            pAllSounds.Controls.Add(gbAllSounds);
            pAllSounds.Dock = DockStyle.Left;
            pAllSounds.Location = new Point(0, 0);
            pAllSounds.Margin = new Padding(4, 3, 4, 3);
            pAllSounds.Name = "pAllSounds";
            pAllSounds.Size = new Size(282, 594);
            pAllSounds.TabIndex = 1;
            // 
            // gbAllSounds
            // 
            gbAllSounds.Controls.Add(chkSoundFilter);
            gbAllSounds.Controls.Add(tbSoundFilter);
            gbAllSounds.Controls.Add(chkSoundsLoop);
            gbAllSounds.Controls.Add(tvSoundEffects);
            gbAllSounds.Dock = DockStyle.Fill;
            gbAllSounds.Location = new Point(0, 0);
            gbAllSounds.Margin = new Padding(4, 3, 4, 3);
            gbAllSounds.Name = "gbAllSounds";
            gbAllSounds.Padding = new Padding(4, 3, 4, 3);
            gbAllSounds.Size = new Size(282, 594);
            gbAllSounds.TabIndex = 0;
            gbAllSounds.TabStop = false;
            gbAllSounds.Text = "All sound effects";
            // 
            // chkSoundFilter
            // 
            chkSoundFilter.AutoSize = true;
            chkSoundFilter.Location = new Point(149, 8);
            chkSoundFilter.Margin = new Padding(4, 3, 4, 3);
            chkSoundFilter.Name = "chkSoundFilter";
            chkSoundFilter.Size = new Size(52, 19);
            chkSoundFilter.TabIndex = 6;
            chkSoundFilter.Text = "Filter";
            chkSoundFilter.UseVisualStyleBackColor = true;
            chkSoundFilter.CheckedChanged += ChkSoundFilter_CheckedChanged;
            // 
            // tbSoundFilter
            // 
            tbSoundFilter.Location = new Point(149, 30);
            tbSoundFilter.Margin = new Padding(4, 3, 4, 3);
            tbSoundFilter.Name = "tbSoundFilter";
            tbSoundFilter.Size = new Size(129, 23);
            tbSoundFilter.TabIndex = 4;
            tbSoundFilter.TextChanged += TbSoundFilter_TextChanged;
            // 
            // chkSoundsLoop
            // 
            chkSoundsLoop.AutoSize = true;
            chkSoundsLoop.Location = new Point(7, 30);
            chkSoundsLoop.Margin = new Padding(4, 3, 4, 3);
            chkSoundsLoop.Name = "chkSoundsLoop";
            chkSoundsLoop.Size = new Size(53, 19);
            chkSoundsLoop.TabIndex = 2;
            chkSoundsLoop.Text = "Loop";
            chkSoundsLoop.UseVisualStyleBackColor = true;
            // 
            // tvSoundEffects
            // 
            tvSoundEffects.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tvSoundEffects.ImageIndex = 0;
            tvSoundEffects.ImageList = imageList;
            tvSoundEffects.Location = new Point(-4, 57);
            tvSoundEffects.Margin = new Padding(4, 3, 4, 3);
            tvSoundEffects.Name = "tvSoundEffects";
            tvSoundEffects.SelectedImageIndex = 0;
            tvSoundEffects.Size = new Size(282, 530);
            tvSoundEffects.TabIndex = 0;
            tvSoundEffects.NodeMouseDoubleClick += TvSoundEffects_NodeMouseDoubleClick;
            // 
            // tpCombat
            // 
            tpCombat.Controls.Add(panelCombat);
            tpCombat.Location = new Point(4, 24);
            tpCombat.Margin = new Padding(4, 3, 4, 3);
            tpCombat.Name = "tpCombat";
            tpCombat.Padding = new Padding(4, 3, 4, 3);
            tpCombat.Size = new Size(925, 600);
            tpCombat.TabIndex = 2;
            tpCombat.Text = "Combat";
            tpCombat.UseVisualStyleBackColor = true;
            // 
            // panelCombat
            // 
            panelCombat.Controls.Add(panelCombatContent);
            panelCombat.Controls.Add(splitter3);
            panelCombat.Controls.Add(pAllCharacters);
            panelCombat.Dock = DockStyle.Fill;
            panelCombat.Location = new Point(4, 3);
            panelCombat.Margin = new Padding(4, 3, 4, 3);
            panelCombat.Name = "panelCombat";
            panelCombat.Size = new Size(917, 594);
            panelCombat.TabIndex = 1;
            // 
            // panelCombatContent
            // 
            panelCombatContent.Dock = DockStyle.Fill;
            panelCombatContent.Location = new Point(286, 0);
            panelCombatContent.Margin = new Padding(4, 3, 4, 3);
            panelCombatContent.Name = "panelCombatContent";
            panelCombatContent.Size = new Size(631, 594);
            panelCombatContent.TabIndex = 3;
            // 
            // splitter3
            // 
            splitter3.Location = new Point(282, 0);
            splitter3.Margin = new Padding(4, 3, 4, 3);
            splitter3.Name = "splitter3";
            splitter3.Size = new Size(4, 594);
            splitter3.TabIndex = 2;
            splitter3.TabStop = false;
            // 
            // pAllCharacters
            // 
            pAllCharacters.Dock = DockStyle.Left;
            pAllCharacters.Location = new Point(0, 0);
            pAllCharacters.Margin = new Padding(4, 3, 4, 3);
            pAllCharacters.Name = "pAllCharacters";
            pAllCharacters.Size = new Size(282, 594);
            pAllCharacters.TabIndex = 1;
            // 
            // tpMarket
            // 
            tpMarket.Controls.Add(lvMarket);
            tpMarket.Location = new Point(4, 24);
            tpMarket.Margin = new Padding(4, 3, 4, 3);
            tpMarket.Name = "tpMarket";
            tpMarket.Padding = new Padding(4, 3, 4, 3);
            tpMarket.Size = new Size(925, 600);
            tpMarket.TabIndex = 7;
            tpMarket.Text = "Market";
            tpMarket.UseVisualStyleBackColor = true;
            // 
            // lvMarket
            // 
            lvMarket.Columns.AddRange(new ColumnHeader[] { chName, chPrice });
            lvMarket.Dock = DockStyle.Fill;
            lvMarket.FullRowSelect = true;
            listViewGroup1.Header = "Accomodation";
            listViewGroup1.Name = "Accomodation";
            listViewGroup2.Header = "Animals";
            listViewGroup2.Name = "Animals";
            listViewGroup3.Header = "Clothes";
            listViewGroup3.Name = "Clothes";
            listViewGroup4.Header = "Debauchery";
            listViewGroup4.Name = "Debauchery";
            listViewGroup5.Header = "Food";
            listViewGroup5.Name = "Food";
            listViewGroup6.Header = "Other";
            listViewGroup6.Name = "Other";
            listViewGroup7.Header = "Trappings";
            listViewGroup7.Name = "Trappings";
            listViewGroup8.Header = "Travelling";
            listViewGroup8.Name = "Travelling";
            lvMarket.Groups.AddRange(new ListViewGroup[] { listViewGroup1, listViewGroup2, listViewGroup3, listViewGroup4, listViewGroup5, listViewGroup6, listViewGroup7, listViewGroup8 });
            lvMarket.Location = new Point(4, 3);
            lvMarket.Margin = new Padding(4, 3, 4, 3);
            lvMarket.Name = "lvMarket";
            lvMarket.Size = new Size(917, 594);
            lvMarket.TabIndex = 0;
            lvMarket.UseCompatibleStateImageBehavior = false;
            lvMarket.View = View.Details;
            // 
            // chName
            // 
            chName.Text = "Name";
            chName.Width = 151;
            // 
            // chPrice
            // 
            chPrice.Text = "Price";
            chPrice.Width = 126;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 674);
            Controls.Add(MainPanel);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Storyteller";
            Shown += MainForm_Shown;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            MainPanel.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tpMap.ResumeLayout(false);
            tpStory.ResumeLayout(false);
            pStory.ResumeLayout(false);
            tpCharacters.ResumeLayout(false);
            pCharacters.ResumeLayout(false);
            pCharacterList.ResumeLayout(false);
            tpImages.ResumeLayout(false);
            pImages.ResumeLayout(false);
            pImageContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbImages).EndInit();
            pImagesLeft.ResumeLayout(false);
            tpVideoClips.ResumeLayout(false);
            pAllVideo.ResumeLayout(false);
            tpMusic.ResumeLayout(false);
            panelMusic.ResumeLayout(false);
            panelMusicContent.ResumeLayout(false);
            pNowPlayingMusic.ResumeLayout(false);
            gbNowPlayingMusic.ResumeLayout(false);
            cmdMusicPlayControls.ResumeLayout(false);
            pAllMusic.ResumeLayout(false);
            gbAllMusic.ResumeLayout(false);
            gbAllMusic.PerformLayout();
            tpSoundEffects.ResumeLayout(false);
            pSoundEffects.ResumeLayout(false);
            panelSoundEffectsContent.ResumeLayout(false);
            pNowPlayingSounds.ResumeLayout(false);
            gbNowPlayingSounds.ResumeLayout(false);
            cmdSoundsPlayControls.ResumeLayout(false);
            pAllSounds.ResumeLayout(false);
            gbAllSounds.ResumeLayout(false);
            gbAllSounds.PerformLayout();
            tpCombat.ResumeLayout(false);
            panelCombat.ResumeLayout(false);
            tpMarket.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpImages;
        private System.Windows.Forms.Panel pImages;
        private System.Windows.Forms.Panel pImageContent;
        private System.Windows.Forms.PictureBox pbImages;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pImagesLeft;
        private System.Windows.Forms.TreeView tvImages;
        private System.Windows.Forms.TabPage tpCharacters;
        private System.Windows.Forms.TabPage tpMusic;
        private System.Windows.Forms.TabPage tpSoundEffects;
        private System.Windows.Forms.TabPage tpCombat;
        private System.Windows.Forms.Panel pCharacters;
        private System.Windows.Forms.Panel panelMusic;
        private System.Windows.Forms.Panel pSoundEffects;
        private System.Windows.Forms.Panel panelCombat;
        private System.Windows.Forms.Panel pCharacterList;
        private System.Windows.Forms.Panel pCharacterContent;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel pAllMusic;
        private System.Windows.Forms.Splitter splitter5;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Panel pAllSounds;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel pAllCharacters;
        private System.Windows.Forms.Panel panelMusicContent;
        private System.Windows.Forms.Panel panelSoundEffectsContent;
        private System.Windows.Forms.Panel panelCombatContent;
        private System.Windows.Forms.TreeView tvCharacters;
        private System.Windows.Forms.TreeView tvMusic;
        private System.Windows.Forms.TreeView tvSoundEffects;
        private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolStripMenuItem tsmiNew;
		private System.Windows.Forms.ToolStripMenuItem tsmiCharacter;
		private System.Windows.Forms.TabPage tpVideoClips;
		private System.Windows.Forms.TabPage tpStory;
		private System.Windows.Forms.Panel pAllVideo;
		private System.Windows.Forms.TreeView tvVideoClips;
		private System.Windows.Forms.ToolStripMenuItem tsmiCharacterSheetOdt;
		private System.Windows.Forms.TabPage tpMarket;
		private System.Windows.Forms.ListView lvMarket;
		private System.Windows.Forms.ColumnHeader chName;
		private System.Windows.Forms.ColumnHeader chPrice;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem tsmiCharacterSheetPdf;
		private System.Windows.Forms.Panel pStory;
		private System.Windows.Forms.RichTextBox rtbStory;
		private System.Windows.Forms.Panel pVideoClip;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem tsmiExit;
		private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
		private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
		private System.Windows.Forms.ToolStripMenuItem tsmiAccessories;
		private System.Windows.Forms.ToolStripMenuItem tsmiGetSounds;
		private System.Windows.Forms.ToolStripMenuItem tsmiArkenForge;
		private System.Windows.Forms.Panel pNowPlayingMusic;
		private System.Windows.Forms.GroupBox gbNowPlayingMusic;
		private System.Windows.Forms.ListView lvNowPlayingMusic;
		private System.Windows.Forms.GroupBox gbAllMusic;
		private System.Windows.Forms.ContextMenuStrip cmdMusicPlayControls;
		private System.Windows.Forms.ToolStripMenuItem tsmiRemoveMusic;
		private System.Windows.Forms.ColumnHeader chMusic;
		private System.Windows.Forms.Panel pNowPlayingSounds;
		private System.Windows.Forms.GroupBox gbNowPlayingSounds;
		private System.Windows.Forms.ListView lvNowPlayingSounds;
		private System.Windows.Forms.ColumnHeader chSounds;
		private System.Windows.Forms.ToolStripMenuItem tsmiGetImages;
		private System.Windows.Forms.ContextMenuStrip cmdSoundsPlayControls;
		private System.Windows.Forms.ToolStripMenuItem tsmiRemoveSounds;
		private System.Windows.Forms.CheckBox chkMusicLoop;
		private System.Windows.Forms.GroupBox gbAllSounds;
		private System.Windows.Forms.CheckBox chkSoundsLoop;
		private System.Windows.Forms.ColumnHeader chLoop;
		private System.Windows.Forms.ColumnHeader chLoopMusic;
		private System.Windows.Forms.ToolStripMenuItem tsmiCastes;
		private System.Windows.Forms.ToolStripMenuItem tsmiKranichWarlock;
		private System.Windows.Forms.ToolStripMenuItem tsmiNastarPriest;
		private System.Windows.Forms.ToolStripMenuItem tsmiVelarPriest;
		private System.Windows.Forms.ToolStripMenuItem tsmiOther;
		private System.Windows.Forms.ToolStripMenuItem tsmiWeaponsAndArmors;
		private System.Windows.Forms.ToolStripMenuItem tsmiHttpsKalandozokHu;
		private System.Windows.Forms.ToolStripMenuItem racesToolStripMenuItem;
		private System.Windows.Forms.TextBox tbMusicFilter;
		private System.Windows.Forms.TextBox tbSoundFilter;
		private System.Windows.Forms.CheckBox chkSoundFilter;
		private System.Windows.Forms.CheckBox chkMusicFilter;
		private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
		private System.Windows.Forms.ToolStripMenuItem tsmiLanguages;
		private System.Windows.Forms.TabPage tpMap;
		private System.Windows.Forms.WebBrowser wbMap;
		private System.Windows.Forms.ToolStripMenuItem tsmiGoogle;
		private System.Windows.Forms.ToolStripMenuItem tsmiPinterest;
	}
}

