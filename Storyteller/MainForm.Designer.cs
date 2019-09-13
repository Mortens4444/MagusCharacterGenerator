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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Accomodation", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Animals", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Clothes", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Debauchery", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Food", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Other", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Trappings", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Travelling", System.Windows.Forms.HorizontalAlignment.Left);
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiCharacter = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmiCharacterSheetOdt = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiCharacterSheetPdf = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiAccessories = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiArkenForge = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiGetSounds = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiGetImages = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiGoogle = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiPinterest = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiCastes = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiKranichWarlock = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiNastarPriest = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiVelarPriest = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiOther = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiHttpsKalandozokHu = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiWeaponsAndArmors = new System.Windows.Forms.ToolStripMenuItem();
			this.racesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiLanguages = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tpStory = new System.Windows.Forms.TabPage();
			this.pStory = new System.Windows.Forms.Panel();
			this.rtbStory = new System.Windows.Forms.RichTextBox();
			this.tpCharacters = new System.Windows.Forms.TabPage();
			this.pCharacters = new System.Windows.Forms.Panel();
			this.pCharacterContent = new System.Windows.Forms.Panel();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.pCharacterList = new System.Windows.Forms.Panel();
			this.tvCharacters = new System.Windows.Forms.TreeView();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.tpMap = new System.Windows.Forms.TabPage();
			this.wbMap = new System.Windows.Forms.WebBrowser();
			this.tpImages = new System.Windows.Forms.TabPage();
			this.pImages = new System.Windows.Forms.Panel();
			this.pImageContent = new System.Windows.Forms.Panel();
			this.pbImages = new System.Windows.Forms.PictureBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pImagesLeft = new System.Windows.Forms.Panel();
			this.tvImages = new System.Windows.Forms.TreeView();
			this.tpVideoClips = new System.Windows.Forms.TabPage();
			this.pVideoClip = new System.Windows.Forms.Panel();
			this.pAllVideo = new System.Windows.Forms.Panel();
			this.tvVideoClips = new System.Windows.Forms.TreeView();
			this.tpMusic = new System.Windows.Forms.TabPage();
			this.panelMusic = new System.Windows.Forms.Panel();
			this.panelMusicContent = new System.Windows.Forms.Panel();
			this.pNowPlayingMusic = new System.Windows.Forms.Panel();
			this.gbNowPlayingMusic = new System.Windows.Forms.GroupBox();
			this.lvNowPlayingMusic = new System.Windows.Forms.ListView();
			this.chMusic = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chLoopMusic = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cmdMusicPlayControls = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmiRemoveMusic = new System.Windows.Forms.ToolStripMenuItem();
			this.splitter5 = new System.Windows.Forms.Splitter();
			this.pAllMusic = new System.Windows.Forms.Panel();
			this.gbAllMusic = new System.Windows.Forms.GroupBox();
			this.chkMusicFilter = new System.Windows.Forms.CheckBox();
			this.tbMusicFilter = new System.Windows.Forms.TextBox();
			this.chkMusicLoop = new System.Windows.Forms.CheckBox();
			this.tvMusic = new System.Windows.Forms.TreeView();
			this.tpSoundEffects = new System.Windows.Forms.TabPage();
			this.pSoundEffects = new System.Windows.Forms.Panel();
			this.panelSoundEffectsContent = new System.Windows.Forms.Panel();
			this.pNowPlayingSounds = new System.Windows.Forms.Panel();
			this.gbNowPlayingSounds = new System.Windows.Forms.GroupBox();
			this.lvNowPlayingSounds = new System.Windows.Forms.ListView();
			this.chSounds = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chLoop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cmdSoundsPlayControls = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmiRemoveSounds = new System.Windows.Forms.ToolStripMenuItem();
			this.splitter4 = new System.Windows.Forms.Splitter();
			this.pAllSounds = new System.Windows.Forms.Panel();
			this.gbAllSounds = new System.Windows.Forms.GroupBox();
			this.chkSoundFilter = new System.Windows.Forms.CheckBox();
			this.tbSoundFilter = new System.Windows.Forms.TextBox();
			this.chkSoundsLoop = new System.Windows.Forms.CheckBox();
			this.tvSoundEffects = new System.Windows.Forms.TreeView();
			this.tpCombat = new System.Windows.Forms.TabPage();
			this.panelCombat = new System.Windows.Forms.Panel();
			this.panelCombatContent = new System.Windows.Forms.Panel();
			this.splitter3 = new System.Windows.Forms.Splitter();
			this.pAllCharacters = new System.Windows.Forms.Panel();
			this.tpMarket = new System.Windows.Forms.TabPage();
			this.lvMarket = new System.Windows.Forms.ListView();
			this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.menuStrip.SuspendLayout();
			this.MainPanel.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tpStory.SuspendLayout();
			this.pStory.SuspendLayout();
			this.tpCharacters.SuspendLayout();
			this.pCharacters.SuspendLayout();
			this.pCharacterList.SuspendLayout();
			this.tpMap.SuspendLayout();
			this.tpImages.SuspendLayout();
			this.pImages.SuspendLayout();
			this.pImageContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbImages)).BeginInit();
			this.pImagesLeft.SuspendLayout();
			this.tpVideoClips.SuspendLayout();
			this.pAllVideo.SuspendLayout();
			this.tpMusic.SuspendLayout();
			this.panelMusic.SuspendLayout();
			this.panelMusicContent.SuspendLayout();
			this.pNowPlayingMusic.SuspendLayout();
			this.gbNowPlayingMusic.SuspendLayout();
			this.cmdMusicPlayControls.SuspendLayout();
			this.pAllMusic.SuspendLayout();
			this.gbAllMusic.SuspendLayout();
			this.tpSoundEffects.SuspendLayout();
			this.pSoundEffects.SuspendLayout();
			this.panelSoundEffectsContent.SuspendLayout();
			this.pNowPlayingSounds.SuspendLayout();
			this.gbNowPlayingSounds.SuspendLayout();
			this.cmdSoundsPlayControls.SuspendLayout();
			this.pAllSounds.SuspendLayout();
			this.gbAllSounds.SuspendLayout();
			this.tpCombat.SuspendLayout();
			this.panelCombat.SuspendLayout();
			this.tpMarket.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.tsmiAccessories,
            this.tsmiSettings,
            this.tsmiHelp});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(800, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// tsmiNew
			// 
			this.tsmiNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCharacter,
            this.toolStripSeparator1,
            this.tsmiCharacterSheetOdt,
            this.tsmiCharacterSheetPdf,
            this.toolStripSeparator2,
            this.tsmiExit});
			this.tsmiNew.Name = "tsmiNew";
			this.tsmiNew.Size = new System.Drawing.Size(43, 20);
			this.tsmiNew.Text = "New";
			// 
			// tsmiCharacter
			// 
			this.tsmiCharacter.Name = "tsmiCharacter";
			this.tsmiCharacter.Size = new System.Drawing.Size(185, 22);
			this.tsmiCharacter.Text = "Character";
			this.tsmiCharacter.Click += new System.EventHandler(this.TsmiCharacter_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
			// 
			// tsmiCharacterSheetOdt
			// 
			this.tsmiCharacterSheetOdt.Name = "tsmiCharacterSheetOdt";
			this.tsmiCharacterSheetOdt.Size = new System.Drawing.Size(185, 22);
			this.tsmiCharacterSheetOdt.Text = "Character sheet (odt)";
			this.tsmiCharacterSheetOdt.Click += new System.EventHandler(this.TsmiCharacterSheetOdt_Click);
			// 
			// tsmiCharacterSheetPdf
			// 
			this.tsmiCharacterSheetPdf.Name = "tsmiCharacterSheetPdf";
			this.tsmiCharacterSheetPdf.Size = new System.Drawing.Size(185, 22);
			this.tsmiCharacterSheetPdf.Text = "Character sheet (pdf)";
			this.tsmiCharacterSheetPdf.Click += new System.EventHandler(this.TsmiCharacterSheetPdf_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
			// 
			// tsmiExit
			// 
			this.tsmiExit.Name = "tsmiExit";
			this.tsmiExit.Size = new System.Drawing.Size(185, 22);
			this.tsmiExit.Text = "Exit";
			this.tsmiExit.Click += new System.EventHandler(this.TsmiExit_Click);
			// 
			// tsmiAccessories
			// 
			this.tsmiAccessories.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiArkenForge,
            this.tsmiGetSounds,
            this.tsmiGetImages,
            this.tsmiCastes,
            this.tsmiOther});
			this.tsmiAccessories.Name = "tsmiAccessories";
			this.tsmiAccessories.Size = new System.Drawing.Size(80, 20);
			this.tsmiAccessories.Text = "Accessories";
			// 
			// tsmiArkenForge
			// 
			this.tsmiArkenForge.Name = "tsmiArkenForge";
			this.tsmiArkenForge.Size = new System.Drawing.Size(133, 22);
			this.tsmiArkenForge.Text = "Arkenforge";
			this.tsmiArkenForge.Click += new System.EventHandler(this.TsmiArkenForge_Click);
			// 
			// tsmiGetSounds
			// 
			this.tsmiGetSounds.Name = "tsmiGetSounds";
			this.tsmiGetSounds.Size = new System.Drawing.Size(133, 22);
			this.tsmiGetSounds.Text = "Get sounds";
			this.tsmiGetSounds.Click += new System.EventHandler(this.TsmiGetSounds_Click);
			// 
			// tsmiGetImages
			// 
			this.tsmiGetImages.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGoogle,
            this.tsmiPinterest});
			this.tsmiGetImages.Name = "tsmiGetImages";
			this.tsmiGetImages.Size = new System.Drawing.Size(133, 22);
			this.tsmiGetImages.Text = "Get images";
			// 
			// tsmiGoogle
			// 
			this.tsmiGoogle.Name = "tsmiGoogle";
			this.tsmiGoogle.Size = new System.Drawing.Size(120, 22);
			this.tsmiGoogle.Text = "Google";
			this.tsmiGoogle.Click += new System.EventHandler(this.TsmiGoogle_Click);
			// 
			// tsmiPinterest
			// 
			this.tsmiPinterest.Name = "tsmiPinterest";
			this.tsmiPinterest.Size = new System.Drawing.Size(120, 22);
			this.tsmiPinterest.Text = "Pinterest";
			this.tsmiPinterest.Click += new System.EventHandler(this.TsmiPinterest_Click);
			// 
			// tsmiCastes
			// 
			this.tsmiCastes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiKranichWarlock,
            this.tsmiNastarPriest,
            this.tsmiVelarPriest});
			this.tsmiCastes.Name = "tsmiCastes";
			this.tsmiCastes.Size = new System.Drawing.Size(133, 22);
			this.tsmiCastes.Text = "Castes";
			// 
			// tsmiKranichWarlock
			// 
			this.tsmiKranichWarlock.Name = "tsmiKranichWarlock";
			this.tsmiKranichWarlock.Size = new System.Drawing.Size(158, 22);
			this.tsmiKranichWarlock.Text = "Kranich warlock";
			this.tsmiKranichWarlock.Click += new System.EventHandler(this.TsmiKranichWarlock_Click);
			// 
			// tsmiNastarPriest
			// 
			this.tsmiNastarPriest.Name = "tsmiNastarPriest";
			this.tsmiNastarPriest.Size = new System.Drawing.Size(158, 22);
			this.tsmiNastarPriest.Text = "Nastar priest";
			this.tsmiNastarPriest.Click += new System.EventHandler(this.TsmiNastarPriest_Click);
			// 
			// tsmiVelarPriest
			// 
			this.tsmiVelarPriest.Name = "tsmiVelarPriest";
			this.tsmiVelarPriest.Size = new System.Drawing.Size(158, 22);
			this.tsmiVelarPriest.Text = "Velar priest";
			this.tsmiVelarPriest.Click += new System.EventHandler(this.TsmiVelarPriest_Click);
			// 
			// tsmiOther
			// 
			this.tsmiOther.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHttpsKalandozokHu,
            this.tsmiWeaponsAndArmors,
            this.racesToolStripMenuItem});
			this.tsmiOther.Name = "tsmiOther";
			this.tsmiOther.Size = new System.Drawing.Size(133, 22);
			this.tsmiOther.Text = "Other";
			// 
			// tsmiHttpsKalandozokHu
			// 
			this.tsmiHttpsKalandozokHu.Name = "tsmiHttpsKalandozokHu";
			this.tsmiHttpsKalandozokHu.Size = new System.Drawing.Size(196, 22);
			this.tsmiHttpsKalandozokHu.Text = "https://kalandozok.hu/";
			this.tsmiHttpsKalandozokHu.Click += new System.EventHandler(this.TsmiHttpsKalandozokHu_Click);
			// 
			// tsmiWeaponsAndArmors
			// 
			this.tsmiWeaponsAndArmors.Name = "tsmiWeaponsAndArmors";
			this.tsmiWeaponsAndArmors.Size = new System.Drawing.Size(196, 22);
			this.tsmiWeaponsAndArmors.Text = "Weapons and armors";
			this.tsmiWeaponsAndArmors.Click += new System.EventHandler(this.TsmiWeapons_Click);
			// 
			// racesToolStripMenuItem
			// 
			this.racesToolStripMenuItem.Name = "racesToolStripMenuItem";
			this.racesToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.racesToolStripMenuItem.Text = "Races";
			this.racesToolStripMenuItem.Click += new System.EventHandler(this.RacesToolStripMenuItem_Click);
			// 
			// tsmiSettings
			// 
			this.tsmiSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLanguages});
			this.tsmiSettings.Name = "tsmiSettings";
			this.tsmiSettings.Size = new System.Drawing.Size(61, 20);
			this.tsmiSettings.Text = "Settings";
			// 
			// tsmiLanguages
			// 
			this.tsmiLanguages.Name = "tsmiLanguages";
			this.tsmiLanguages.Size = new System.Drawing.Size(131, 22);
			this.tsmiLanguages.Text = "Languages";
			// 
			// tsmiHelp
			// 
			this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
			this.tsmiHelp.Name = "tsmiHelp";
			this.tsmiHelp.Size = new System.Drawing.Size(44, 20);
			this.tsmiHelp.Text = "Help";
			// 
			// tsmiAbout
			// 
			this.tsmiAbout.Name = "tsmiAbout";
			this.tsmiAbout.Size = new System.Drawing.Size(107, 22);
			this.tsmiAbout.Text = "About";
			this.tsmiAbout.Click += new System.EventHandler(this.TsmiAbout_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Location = new System.Drawing.Point(0, 562);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(800, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// MainPanel
			// 
			this.MainPanel.Controls.Add(this.tabControl);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(0, 24);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(800, 538);
			this.MainPanel.TabIndex = 2;
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tpMap);
			this.tabControl.Controls.Add(this.tpStory);
			this.tabControl.Controls.Add(this.tpCharacters);
			this.tabControl.Controls.Add(this.tpImages);
			this.tabControl.Controls.Add(this.tpVideoClips);
			this.tabControl.Controls.Add(this.tpMusic);
			this.tabControl.Controls.Add(this.tpSoundEffects);
			this.tabControl.Controls.Add(this.tpCombat);
			this.tabControl.Controls.Add(this.tpMarket);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.ImageList = this.imageList;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(800, 538);
			this.tabControl.TabIndex = 0;
			// 
			// tpStory
			// 
			this.tpStory.Controls.Add(this.pStory);
			this.tpStory.Location = new System.Drawing.Point(4, 23);
			this.tpStory.Name = "tpStory";
			this.tpStory.Padding = new System.Windows.Forms.Padding(3);
			this.tpStory.Size = new System.Drawing.Size(792, 511);
			this.tpStory.TabIndex = 6;
			this.tpStory.Text = "Story";
			this.tpStory.UseVisualStyleBackColor = true;
			// 
			// pStory
			// 
			this.pStory.Controls.Add(this.rtbStory);
			this.pStory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pStory.Location = new System.Drawing.Point(3, 3);
			this.pStory.Name = "pStory";
			this.pStory.Size = new System.Drawing.Size(786, 505);
			this.pStory.TabIndex = 0;
			// 
			// rtbStory
			// 
			this.rtbStory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbStory.Location = new System.Drawing.Point(0, 0);
			this.rtbStory.Name = "rtbStory";
			this.rtbStory.Size = new System.Drawing.Size(786, 505);
			this.rtbStory.TabIndex = 0;
			this.rtbStory.Text = "";
			this.rtbStory.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RtbStory_LinkClicked);
			// 
			// tpCharacters
			// 
			this.tpCharacters.Controls.Add(this.pCharacters);
			this.tpCharacters.Location = new System.Drawing.Point(4, 23);
			this.tpCharacters.Name = "tpCharacters";
			this.tpCharacters.Padding = new System.Windows.Forms.Padding(3);
			this.tpCharacters.Size = new System.Drawing.Size(792, 511);
			this.tpCharacters.TabIndex = 3;
			this.tpCharacters.Text = "Characters";
			this.tpCharacters.UseVisualStyleBackColor = true;
			// 
			// pCharacters
			// 
			this.pCharacters.Controls.Add(this.pCharacterContent);
			this.pCharacters.Controls.Add(this.splitter2);
			this.pCharacters.Controls.Add(this.pCharacterList);
			this.pCharacters.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pCharacters.Location = new System.Drawing.Point(3, 3);
			this.pCharacters.Name = "pCharacters";
			this.pCharacters.Size = new System.Drawing.Size(786, 505);
			this.pCharacters.TabIndex = 0;
			// 
			// pCharacterContent
			// 
			this.pCharacterContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pCharacterContent.Location = new System.Drawing.Point(245, 0);
			this.pCharacterContent.Name = "pCharacterContent";
			this.pCharacterContent.Size = new System.Drawing.Size(541, 505);
			this.pCharacterContent.TabIndex = 2;
			// 
			// splitter2
			// 
			this.splitter2.Location = new System.Drawing.Point(242, 0);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(3, 505);
			this.splitter2.TabIndex = 1;
			this.splitter2.TabStop = false;
			// 
			// pCharacterList
			// 
			this.pCharacterList.Controls.Add(this.tvCharacters);
			this.pCharacterList.Dock = System.Windows.Forms.DockStyle.Left;
			this.pCharacterList.Location = new System.Drawing.Point(0, 0);
			this.pCharacterList.Name = "pCharacterList";
			this.pCharacterList.Size = new System.Drawing.Size(242, 505);
			this.pCharacterList.TabIndex = 0;
			// 
			// tvCharacters
			// 
			this.tvCharacters.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvCharacters.ImageIndex = 0;
			this.tvCharacters.ImageList = this.imageList;
			this.tvCharacters.Location = new System.Drawing.Point(0, 0);
			this.tvCharacters.Name = "tvCharacters";
			this.tvCharacters.SelectedImageIndex = 0;
			this.tvCharacters.Size = new System.Drawing.Size(242, 505);
			this.tvCharacters.TabIndex = 0;
			this.tvCharacters.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvCharacters_AfterSelect);
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tpMap
			// 
			this.tpMap.Controls.Add(this.wbMap);
			this.tpMap.Location = new System.Drawing.Point(4, 23);
			this.tpMap.Name = "tpMap";
			this.tpMap.Padding = new System.Windows.Forms.Padding(3);
			this.tpMap.Size = new System.Drawing.Size(792, 511);
			this.tpMap.TabIndex = 8;
			this.tpMap.Text = "Map";
			this.tpMap.UseVisualStyleBackColor = true;
			// 
			// wbMap
			// 
			this.wbMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wbMap.Location = new System.Drawing.Point(3, 3);
			this.wbMap.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbMap.Name = "wbMap";
			this.wbMap.ScriptErrorsSuppressed = true;
			this.wbMap.Size = new System.Drawing.Size(786, 505);
			this.wbMap.TabIndex = 0;
			this.wbMap.Url = new System.Uri("https://kalandozok.hu/ynev/", System.UriKind.Absolute);
			// 
			// tpImages
			// 
			this.tpImages.Controls.Add(this.pImages);
			this.tpImages.Location = new System.Drawing.Point(4, 23);
			this.tpImages.Name = "tpImages";
			this.tpImages.Padding = new System.Windows.Forms.Padding(3);
			this.tpImages.Size = new System.Drawing.Size(792, 511);
			this.tpImages.TabIndex = 0;
			this.tpImages.Text = "Images";
			this.tpImages.UseVisualStyleBackColor = true;
			// 
			// pImages
			// 
			this.pImages.Controls.Add(this.pImageContent);
			this.pImages.Controls.Add(this.splitter1);
			this.pImages.Controls.Add(this.pImagesLeft);
			this.pImages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pImages.Location = new System.Drawing.Point(3, 3);
			this.pImages.Name = "pImages";
			this.pImages.Size = new System.Drawing.Size(786, 505);
			this.pImages.TabIndex = 0;
			// 
			// pImageContent
			// 
			this.pImageContent.Controls.Add(this.pbImages);
			this.pImageContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pImageContent.Location = new System.Drawing.Point(245, 0);
			this.pImageContent.Name = "pImageContent";
			this.pImageContent.Size = new System.Drawing.Size(541, 505);
			this.pImageContent.TabIndex = 2;
			// 
			// pbImages
			// 
			this.pbImages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbImages.Location = new System.Drawing.Point(0, 0);
			this.pbImages.Name = "pbImages";
			this.pbImages.Size = new System.Drawing.Size(541, 505);
			this.pbImages.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbImages.TabIndex = 0;
			this.pbImages.TabStop = false;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(242, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 505);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// pImagesLeft
			// 
			this.pImagesLeft.Controls.Add(this.tvImages);
			this.pImagesLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pImagesLeft.Location = new System.Drawing.Point(0, 0);
			this.pImagesLeft.Name = "pImagesLeft";
			this.pImagesLeft.Size = new System.Drawing.Size(242, 505);
			this.pImagesLeft.TabIndex = 0;
			// 
			// tvImages
			// 
			this.tvImages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvImages.ImageIndex = 0;
			this.tvImages.ImageList = this.imageList;
			this.tvImages.Location = new System.Drawing.Point(0, 0);
			this.tvImages.Name = "tvImages";
			this.tvImages.SelectedImageIndex = 0;
			this.tvImages.Size = new System.Drawing.Size(242, 505);
			this.tvImages.TabIndex = 0;
			this.tvImages.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvMaps_AfterSelect);
			this.tvImages.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvMaps_NodeMouseClick);
			// 
			// tpVideoClips
			// 
			this.tpVideoClips.Controls.Add(this.pVideoClip);
			this.tpVideoClips.Controls.Add(this.pAllVideo);
			this.tpVideoClips.Location = new System.Drawing.Point(4, 23);
			this.tpVideoClips.Name = "tpVideoClips";
			this.tpVideoClips.Padding = new System.Windows.Forms.Padding(3);
			this.tpVideoClips.Size = new System.Drawing.Size(792, 511);
			this.tpVideoClips.TabIndex = 5;
			this.tpVideoClips.Text = "Video clips";
			this.tpVideoClips.UseVisualStyleBackColor = true;
			// 
			// pVideoClip
			// 
			this.pVideoClip.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pVideoClip.Location = new System.Drawing.Point(245, 3);
			this.pVideoClip.Name = "pVideoClip";
			this.pVideoClip.Size = new System.Drawing.Size(544, 505);
			this.pVideoClip.TabIndex = 3;
			// 
			// pAllVideo
			// 
			this.pAllVideo.Controls.Add(this.tvVideoClips);
			this.pAllVideo.Dock = System.Windows.Forms.DockStyle.Left;
			this.pAllVideo.Location = new System.Drawing.Point(3, 3);
			this.pAllVideo.Name = "pAllVideo";
			this.pAllVideo.Size = new System.Drawing.Size(242, 505);
			this.pAllVideo.TabIndex = 2;
			// 
			// tvVideoClips
			// 
			this.tvVideoClips.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvVideoClips.ImageIndex = 0;
			this.tvVideoClips.ImageList = this.imageList;
			this.tvVideoClips.Location = new System.Drawing.Point(0, 0);
			this.tvVideoClips.Name = "tvVideoClips";
			this.tvVideoClips.SelectedImageIndex = 0;
			this.tvVideoClips.Size = new System.Drawing.Size(242, 505);
			this.tvVideoClips.TabIndex = 0;
			this.tvVideoClips.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvVideoClips_NodeMouseDoubleClick);
			// 
			// tpMusic
			// 
			this.tpMusic.Controls.Add(this.panelMusic);
			this.tpMusic.Location = new System.Drawing.Point(4, 23);
			this.tpMusic.Name = "tpMusic";
			this.tpMusic.Padding = new System.Windows.Forms.Padding(3);
			this.tpMusic.Size = new System.Drawing.Size(792, 511);
			this.tpMusic.TabIndex = 1;
			this.tpMusic.Text = "Music";
			this.tpMusic.UseVisualStyleBackColor = true;
			// 
			// panelMusic
			// 
			this.panelMusic.Controls.Add(this.panelMusicContent);
			this.panelMusic.Controls.Add(this.splitter5);
			this.panelMusic.Controls.Add(this.pAllMusic);
			this.panelMusic.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMusic.Location = new System.Drawing.Point(3, 3);
			this.panelMusic.Name = "panelMusic";
			this.panelMusic.Size = new System.Drawing.Size(786, 505);
			this.panelMusic.TabIndex = 1;
			// 
			// panelMusicContent
			// 
			this.panelMusicContent.Controls.Add(this.pNowPlayingMusic);
			this.panelMusicContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMusicContent.Location = new System.Drawing.Point(245, 0);
			this.panelMusicContent.Name = "panelMusicContent";
			this.panelMusicContent.Size = new System.Drawing.Size(541, 505);
			this.panelMusicContent.TabIndex = 3;
			// 
			// pNowPlayingMusic
			// 
			this.pNowPlayingMusic.Controls.Add(this.gbNowPlayingMusic);
			this.pNowPlayingMusic.Dock = System.Windows.Forms.DockStyle.Left;
			this.pNowPlayingMusic.Location = new System.Drawing.Point(0, 0);
			this.pNowPlayingMusic.Name = "pNowPlayingMusic";
			this.pNowPlayingMusic.Size = new System.Drawing.Size(245, 505);
			this.pNowPlayingMusic.TabIndex = 0;
			// 
			// gbNowPlayingMusic
			// 
			this.gbNowPlayingMusic.Controls.Add(this.lvNowPlayingMusic);
			this.gbNowPlayingMusic.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbNowPlayingMusic.Location = new System.Drawing.Point(0, 0);
			this.gbNowPlayingMusic.Name = "gbNowPlayingMusic";
			this.gbNowPlayingMusic.Size = new System.Drawing.Size(245, 505);
			this.gbNowPlayingMusic.TabIndex = 0;
			this.gbNowPlayingMusic.TabStop = false;
			this.gbNowPlayingMusic.Text = "Now playing";
			// 
			// lvNowPlayingMusic
			// 
			this.lvNowPlayingMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvNowPlayingMusic.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chMusic,
            this.chLoopMusic});
			this.lvNowPlayingMusic.ContextMenuStrip = this.cmdMusicPlayControls;
			this.lvNowPlayingMusic.FullRowSelect = true;
			this.lvNowPlayingMusic.HideSelection = false;
			this.lvNowPlayingMusic.Location = new System.Drawing.Point(3, 49);
			this.lvNowPlayingMusic.Name = "lvNowPlayingMusic";
			this.lvNowPlayingMusic.Size = new System.Drawing.Size(239, 453);
			this.lvNowPlayingMusic.TabIndex = 0;
			this.lvNowPlayingMusic.UseCompatibleStateImageBehavior = false;
			this.lvNowPlayingMusic.View = System.Windows.Forms.View.Details;
			// 
			// chMusic
			// 
			this.chMusic.Text = "Music";
			this.chMusic.Width = 177;
			// 
			// chLoopMusic
			// 
			this.chLoopMusic.Text = "Loop";
			// 
			// cmdMusicPlayControls
			// 
			this.cmdMusicPlayControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRemoveMusic});
			this.cmdMusicPlayControls.Name = "cmdMusicPlayControls";
			this.cmdMusicPlayControls.Size = new System.Drawing.Size(153, 26);
			// 
			// tsmiRemoveMusic
			// 
			this.tsmiRemoveMusic.Name = "tsmiRemoveMusic";
			this.tsmiRemoveMusic.Size = new System.Drawing.Size(152, 22);
			this.tsmiRemoveMusic.Text = "Remove music";
			this.tsmiRemoveMusic.Click += new System.EventHandler(this.TsmiRemoveMusic_Click);
			// 
			// splitter5
			// 
			this.splitter5.Location = new System.Drawing.Point(242, 0);
			this.splitter5.Name = "splitter5";
			this.splitter5.Size = new System.Drawing.Size(3, 505);
			this.splitter5.TabIndex = 2;
			this.splitter5.TabStop = false;
			// 
			// pAllMusic
			// 
			this.pAllMusic.Controls.Add(this.gbAllMusic);
			this.pAllMusic.Dock = System.Windows.Forms.DockStyle.Left;
			this.pAllMusic.Location = new System.Drawing.Point(0, 0);
			this.pAllMusic.Name = "pAllMusic";
			this.pAllMusic.Size = new System.Drawing.Size(242, 505);
			this.pAllMusic.TabIndex = 1;
			// 
			// gbAllMusic
			// 
			this.gbAllMusic.Controls.Add(this.chkMusicFilter);
			this.gbAllMusic.Controls.Add(this.tbMusicFilter);
			this.gbAllMusic.Controls.Add(this.chkMusicLoop);
			this.gbAllMusic.Controls.Add(this.tvMusic);
			this.gbAllMusic.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbAllMusic.Location = new System.Drawing.Point(0, 0);
			this.gbAllMusic.Name = "gbAllMusic";
			this.gbAllMusic.Size = new System.Drawing.Size(242, 505);
			this.gbAllMusic.TabIndex = 0;
			this.gbAllMusic.TabStop = false;
			this.gbAllMusic.Text = "All music";
			// 
			// chkMusicFilter
			// 
			this.chkMusicFilter.AutoSize = true;
			this.chkMusicFilter.Location = new System.Drawing.Point(128, 7);
			this.chkMusicFilter.Name = "chkMusicFilter";
			this.chkMusicFilter.Size = new System.Drawing.Size(48, 17);
			this.chkMusicFilter.TabIndex = 7;
			this.chkMusicFilter.Text = "Filter";
			this.chkMusicFilter.UseVisualStyleBackColor = true;
			this.chkMusicFilter.CheckedChanged += new System.EventHandler(this.ChkMusicFilter_CheckedChanged);
			// 
			// tbMusicFilter
			// 
			this.tbMusicFilter.Location = new System.Drawing.Point(128, 26);
			this.tbMusicFilter.Name = "tbMusicFilter";
			this.tbMusicFilter.Size = new System.Drawing.Size(111, 20);
			this.tbMusicFilter.TabIndex = 2;
			this.tbMusicFilter.TextChanged += new System.EventHandler(this.TbMusicFilter_TextChanged);
			// 
			// chkMusicLoop
			// 
			this.chkMusicLoop.AutoSize = true;
			this.chkMusicLoop.Location = new System.Drawing.Point(6, 26);
			this.chkMusicLoop.Name = "chkMusicLoop";
			this.chkMusicLoop.Size = new System.Drawing.Size(50, 17);
			this.chkMusicLoop.TabIndex = 1;
			this.chkMusicLoop.Text = "Loop";
			this.chkMusicLoop.UseVisualStyleBackColor = true;
			// 
			// tvMusic
			// 
			this.tvMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tvMusic.FullRowSelect = true;
			this.tvMusic.ImageIndex = 0;
			this.tvMusic.ImageList = this.imageList;
			this.tvMusic.Location = new System.Drawing.Point(3, 49);
			this.tvMusic.Name = "tvMusic";
			this.tvMusic.SelectedImageIndex = 0;
			this.tvMusic.Size = new System.Drawing.Size(236, 453);
			this.tvMusic.TabIndex = 0;
			this.tvMusic.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvMusic_NodeMouseDoubleClick);
			// 
			// tpSoundEffects
			// 
			this.tpSoundEffects.Controls.Add(this.pSoundEffects);
			this.tpSoundEffects.Location = new System.Drawing.Point(4, 23);
			this.tpSoundEffects.Name = "tpSoundEffects";
			this.tpSoundEffects.Padding = new System.Windows.Forms.Padding(3);
			this.tpSoundEffects.Size = new System.Drawing.Size(792, 511);
			this.tpSoundEffects.TabIndex = 4;
			this.tpSoundEffects.Text = "Sound effects";
			this.tpSoundEffects.UseVisualStyleBackColor = true;
			// 
			// pSoundEffects
			// 
			this.pSoundEffects.Controls.Add(this.panelSoundEffectsContent);
			this.pSoundEffects.Controls.Add(this.splitter4);
			this.pSoundEffects.Controls.Add(this.pAllSounds);
			this.pSoundEffects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pSoundEffects.Location = new System.Drawing.Point(3, 3);
			this.pSoundEffects.Name = "pSoundEffects";
			this.pSoundEffects.Size = new System.Drawing.Size(786, 505);
			this.pSoundEffects.TabIndex = 1;
			// 
			// panelSoundEffectsContent
			// 
			this.panelSoundEffectsContent.Controls.Add(this.pNowPlayingSounds);
			this.panelSoundEffectsContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelSoundEffectsContent.Location = new System.Drawing.Point(245, 0);
			this.panelSoundEffectsContent.Name = "panelSoundEffectsContent";
			this.panelSoundEffectsContent.Size = new System.Drawing.Size(541, 505);
			this.panelSoundEffectsContent.TabIndex = 3;
			// 
			// pNowPlayingSounds
			// 
			this.pNowPlayingSounds.Controls.Add(this.gbNowPlayingSounds);
			this.pNowPlayingSounds.Dock = System.Windows.Forms.DockStyle.Left;
			this.pNowPlayingSounds.Location = new System.Drawing.Point(0, 0);
			this.pNowPlayingSounds.Name = "pNowPlayingSounds";
			this.pNowPlayingSounds.Size = new System.Drawing.Size(245, 505);
			this.pNowPlayingSounds.TabIndex = 1;
			// 
			// gbNowPlayingSounds
			// 
			this.gbNowPlayingSounds.Controls.Add(this.lvNowPlayingSounds);
			this.gbNowPlayingSounds.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbNowPlayingSounds.Location = new System.Drawing.Point(0, 0);
			this.gbNowPlayingSounds.Name = "gbNowPlayingSounds";
			this.gbNowPlayingSounds.Size = new System.Drawing.Size(245, 505);
			this.gbNowPlayingSounds.TabIndex = 0;
			this.gbNowPlayingSounds.TabStop = false;
			this.gbNowPlayingSounds.Text = "Now playing";
			// 
			// lvNowPlayingSounds
			// 
			this.lvNowPlayingSounds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvNowPlayingSounds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSounds,
            this.chLoop});
			this.lvNowPlayingSounds.ContextMenuStrip = this.cmdSoundsPlayControls;
			this.lvNowPlayingSounds.FullRowSelect = true;
			this.lvNowPlayingSounds.HideSelection = false;
			this.lvNowPlayingSounds.Location = new System.Drawing.Point(3, 49);
			this.lvNowPlayingSounds.Name = "lvNowPlayingSounds";
			this.lvNowPlayingSounds.Size = new System.Drawing.Size(239, 453);
			this.lvNowPlayingSounds.TabIndex = 0;
			this.lvNowPlayingSounds.UseCompatibleStateImageBehavior = false;
			this.lvNowPlayingSounds.View = System.Windows.Forms.View.Details;
			// 
			// chSounds
			// 
			this.chSounds.Text = "Sounds";
			this.chSounds.Width = 177;
			// 
			// chLoop
			// 
			this.chLoop.Text = "Loop";
			// 
			// cmdSoundsPlayControls
			// 
			this.cmdSoundsPlayControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRemoveSounds});
			this.cmdSoundsPlayControls.Name = "cmdMusicPlayControls";
			this.cmdSoundsPlayControls.Size = new System.Drawing.Size(167, 26);
			// 
			// tsmiRemoveSounds
			// 
			this.tsmiRemoveSounds.Name = "tsmiRemoveSounds";
			this.tsmiRemoveSounds.Size = new System.Drawing.Size(166, 22);
			this.tsmiRemoveSounds.Text = "Remove sound(s)";
			this.tsmiRemoveSounds.Click += new System.EventHandler(this.TsmiRemoveSounds_Click);
			// 
			// splitter4
			// 
			this.splitter4.Location = new System.Drawing.Point(242, 0);
			this.splitter4.Name = "splitter4";
			this.splitter4.Size = new System.Drawing.Size(3, 505);
			this.splitter4.TabIndex = 2;
			this.splitter4.TabStop = false;
			// 
			// pAllSounds
			// 
			this.pAllSounds.Controls.Add(this.gbAllSounds);
			this.pAllSounds.Dock = System.Windows.Forms.DockStyle.Left;
			this.pAllSounds.Location = new System.Drawing.Point(0, 0);
			this.pAllSounds.Name = "pAllSounds";
			this.pAllSounds.Size = new System.Drawing.Size(242, 505);
			this.pAllSounds.TabIndex = 1;
			// 
			// gbAllSounds
			// 
			this.gbAllSounds.Controls.Add(this.chkSoundFilter);
			this.gbAllSounds.Controls.Add(this.tbSoundFilter);
			this.gbAllSounds.Controls.Add(this.chkSoundsLoop);
			this.gbAllSounds.Controls.Add(this.tvSoundEffects);
			this.gbAllSounds.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbAllSounds.Location = new System.Drawing.Point(0, 0);
			this.gbAllSounds.Name = "gbAllSounds";
			this.gbAllSounds.Size = new System.Drawing.Size(242, 505);
			this.gbAllSounds.TabIndex = 0;
			this.gbAllSounds.TabStop = false;
			this.gbAllSounds.Text = "All sound effects";
			// 
			// chkSoundFilter
			// 
			this.chkSoundFilter.AutoSize = true;
			this.chkSoundFilter.Location = new System.Drawing.Point(128, 7);
			this.chkSoundFilter.Name = "chkSoundFilter";
			this.chkSoundFilter.Size = new System.Drawing.Size(48, 17);
			this.chkSoundFilter.TabIndex = 6;
			this.chkSoundFilter.Text = "Filter";
			this.chkSoundFilter.UseVisualStyleBackColor = true;
			this.chkSoundFilter.CheckedChanged += new System.EventHandler(this.ChkSoundFilter_CheckedChanged);
			// 
			// tbSoundFilter
			// 
			this.tbSoundFilter.Location = new System.Drawing.Point(128, 26);
			this.tbSoundFilter.Name = "tbSoundFilter";
			this.tbSoundFilter.Size = new System.Drawing.Size(111, 20);
			this.tbSoundFilter.TabIndex = 4;
			this.tbSoundFilter.TextChanged += new System.EventHandler(this.TbSoundFilter_TextChanged);
			// 
			// chkSoundsLoop
			// 
			this.chkSoundsLoop.AutoSize = true;
			this.chkSoundsLoop.Location = new System.Drawing.Point(6, 26);
			this.chkSoundsLoop.Name = "chkSoundsLoop";
			this.chkSoundsLoop.Size = new System.Drawing.Size(50, 17);
			this.chkSoundsLoop.TabIndex = 2;
			this.chkSoundsLoop.Text = "Loop";
			this.chkSoundsLoop.UseVisualStyleBackColor = true;
			// 
			// tvSoundEffects
			// 
			this.tvSoundEffects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tvSoundEffects.ImageIndex = 0;
			this.tvSoundEffects.ImageList = this.imageList;
			this.tvSoundEffects.Location = new System.Drawing.Point(-3, 49);
			this.tvSoundEffects.Name = "tvSoundEffects";
			this.tvSoundEffects.SelectedImageIndex = 0;
			this.tvSoundEffects.Size = new System.Drawing.Size(242, 450);
			this.tvSoundEffects.TabIndex = 0;
			this.tvSoundEffects.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvSoundEffects_NodeMouseDoubleClick);
			// 
			// tpCombat
			// 
			this.tpCombat.Controls.Add(this.panelCombat);
			this.tpCombat.Location = new System.Drawing.Point(4, 23);
			this.tpCombat.Name = "tpCombat";
			this.tpCombat.Padding = new System.Windows.Forms.Padding(3);
			this.tpCombat.Size = new System.Drawing.Size(792, 511);
			this.tpCombat.TabIndex = 2;
			this.tpCombat.Text = "Combat";
			this.tpCombat.UseVisualStyleBackColor = true;
			// 
			// panelCombat
			// 
			this.panelCombat.Controls.Add(this.panelCombatContent);
			this.panelCombat.Controls.Add(this.splitter3);
			this.panelCombat.Controls.Add(this.pAllCharacters);
			this.panelCombat.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelCombat.Location = new System.Drawing.Point(3, 3);
			this.panelCombat.Name = "panelCombat";
			this.panelCombat.Size = new System.Drawing.Size(786, 505);
			this.panelCombat.TabIndex = 1;
			// 
			// panelCombatContent
			// 
			this.panelCombatContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelCombatContent.Location = new System.Drawing.Point(245, 0);
			this.panelCombatContent.Name = "panelCombatContent";
			this.panelCombatContent.Size = new System.Drawing.Size(541, 505);
			this.panelCombatContent.TabIndex = 3;
			// 
			// splitter3
			// 
			this.splitter3.Location = new System.Drawing.Point(242, 0);
			this.splitter3.Name = "splitter3";
			this.splitter3.Size = new System.Drawing.Size(3, 505);
			this.splitter3.TabIndex = 2;
			this.splitter3.TabStop = false;
			// 
			// pAllCharacters
			// 
			this.pAllCharacters.Dock = System.Windows.Forms.DockStyle.Left;
			this.pAllCharacters.Location = new System.Drawing.Point(0, 0);
			this.pAllCharacters.Name = "pAllCharacters";
			this.pAllCharacters.Size = new System.Drawing.Size(242, 505);
			this.pAllCharacters.TabIndex = 1;
			// 
			// tpMarket
			// 
			this.tpMarket.Controls.Add(this.lvMarket);
			this.tpMarket.Location = new System.Drawing.Point(4, 23);
			this.tpMarket.Name = "tpMarket";
			this.tpMarket.Padding = new System.Windows.Forms.Padding(3);
			this.tpMarket.Size = new System.Drawing.Size(792, 511);
			this.tpMarket.TabIndex = 7;
			this.tpMarket.Text = "Market";
			this.tpMarket.UseVisualStyleBackColor = true;
			// 
			// lvMarket
			// 
			this.lvMarket.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chPrice});
			this.lvMarket.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvMarket.FullRowSelect = true;
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
			this.lvMarket.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6,
            listViewGroup7,
            listViewGroup8});
			this.lvMarket.HideSelection = false;
			this.lvMarket.Location = new System.Drawing.Point(3, 3);
			this.lvMarket.Name = "lvMarket";
			this.lvMarket.Size = new System.Drawing.Size(786, 505);
			this.lvMarket.TabIndex = 0;
			this.lvMarket.UseCompatibleStateImageBehavior = false;
			this.lvMarket.View = System.Windows.Forms.View.Details;
			// 
			// chName
			// 
			this.chName.Text = "Name";
			this.chName.Width = 151;
			// 
			// chPrice
			// 
			this.chPrice.Text = "Price";
			this.chPrice.Width = 126;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 584);
			this.Controls.Add(this.MainPanel);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Storyteller";
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.MainPanel.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.tpStory.ResumeLayout(false);
			this.pStory.ResumeLayout(false);
			this.tpCharacters.ResumeLayout(false);
			this.pCharacters.ResumeLayout(false);
			this.pCharacterList.ResumeLayout(false);
			this.tpMap.ResumeLayout(false);
			this.tpImages.ResumeLayout(false);
			this.pImages.ResumeLayout(false);
			this.pImageContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbImages)).EndInit();
			this.pImagesLeft.ResumeLayout(false);
			this.tpVideoClips.ResumeLayout(false);
			this.pAllVideo.ResumeLayout(false);
			this.tpMusic.ResumeLayout(false);
			this.panelMusic.ResumeLayout(false);
			this.panelMusicContent.ResumeLayout(false);
			this.pNowPlayingMusic.ResumeLayout(false);
			this.gbNowPlayingMusic.ResumeLayout(false);
			this.cmdMusicPlayControls.ResumeLayout(false);
			this.pAllMusic.ResumeLayout(false);
			this.gbAllMusic.ResumeLayout(false);
			this.gbAllMusic.PerformLayout();
			this.tpSoundEffects.ResumeLayout(false);
			this.pSoundEffects.ResumeLayout(false);
			this.panelSoundEffectsContent.ResumeLayout(false);
			this.pNowPlayingSounds.ResumeLayout(false);
			this.gbNowPlayingSounds.ResumeLayout(false);
			this.cmdSoundsPlayControls.ResumeLayout(false);
			this.pAllSounds.ResumeLayout(false);
			this.gbAllSounds.ResumeLayout(false);
			this.gbAllSounds.PerformLayout();
			this.tpCombat.ResumeLayout(false);
			this.panelCombat.ResumeLayout(false);
			this.tpMarket.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

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

