namespace Entrega3Netify
{
    partial class SongMenuForm
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
            this.ROPanel = new System.Windows.Forms.Panel();
            this.UploadSongButton = new System.Windows.Forms.Button();
            this.VolLabel = new System.Windows.Forms.Label();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.SongTimeLabel = new System.Windows.Forms.Label();
            this.VolumeTrackBar = new System.Windows.Forms.TrackBar();
            this.SongTimeProgressBar = new System.Windows.Forms.ProgressBar();
            this.PreviouSongButton = new System.Windows.Forms.Button();
            this.NextSongButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SongTimeTrackBar = new System.Windows.Forms.TrackBar();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SSFLPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ImportSongPanel = new System.Windows.Forms.Panel();
            this.BackButton = new System.Windows.Forms.Button();
            this.GenreTextBox = new System.Windows.Forms.TextBox();
            this.GenreLabel = new System.Windows.Forms.Label();
            this.ConfirmUploadButton = new System.Windows.Forms.Button();
            this.YearTextBox = new System.Windows.Forms.TextBox();
            this.YearLabel = new System.Windows.Forms.Label();
            this.ArtistTextBox = new System.Windows.Forms.TextBox();
            this.ArtistLabel = new System.Windows.Forms.Label();
            this.AlbumTextBox = new System.Windows.Forms.TextBox();
            this.AlbumLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SongTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.PlaylistsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.NewPlaylistButton = new System.Windows.Forms.Button();
            this.PlaylistCreatorPanel = new System.Windows.Forms.Panel();
            this.PrivateCheckBox = new System.Windows.Forms.CheckBox();
            this.SongplLabel = new System.Windows.Forms.Label();
            this.SongsComboBox = new System.Windows.Forms.ComboBox();
            this.PlaylistNameLabel = new System.Windows.Forms.Label();
            this.CreatePlaylistButton = new System.Windows.Forms.Button();
            this.PlaylistNameTextBox = new System.Windows.Forms.TextBox();
            this.BackcrButton = new System.Windows.Forms.Button();
            this.DeleteSongButton = new System.Windows.Forms.Button();
            this.DeleteSongPanel = new System.Windows.Forms.Panel();
            this.DeleteSongComboBox = new System.Windows.Forms.ComboBox();
            this.ConfirmDeleteButton = new System.Windows.Forms.Button();
            this.DeleteBackButton = new System.Windows.Forms.Button();
            this.DeletePlaylistButton = new System.Windows.Forms.Button();
            this.DeletePlaylistPanel = new System.Windows.Forms.Panel();
            this.DeletePlaylistBackButton = new System.Windows.Forms.Button();
            this.DefDeletePlaylistButton = new System.Windows.Forms.Button();
            this.DeletePlaylistComboBox = new System.Windows.Forms.ComboBox();
            this.ROPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SongTimeTrackBar)).BeginInit();
            this.SSFLPanel.SuspendLayout();
            this.ImportSongPanel.SuspendLayout();
            this.PlaylistsFlowLayoutPanel.SuspendLayout();
            this.PlaylistCreatorPanel.SuspendLayout();
            this.DeleteSongPanel.SuspendLayout();
            this.DeletePlaylistPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ROPanel
            // 
            this.ROPanel.Controls.Add(this.DeleteSongButton);
            this.ROPanel.Controls.Add(this.UploadSongButton);
            this.ROPanel.Controls.Add(this.VolLabel);
            this.ROPanel.Controls.Add(this.VolumeLabel);
            this.ROPanel.Controls.Add(this.SongTimeLabel);
            this.ROPanel.Controls.Add(this.VolumeTrackBar);
            this.ROPanel.Controls.Add(this.SongTimeProgressBar);
            this.ROPanel.Controls.Add(this.PreviouSongButton);
            this.ROPanel.Controls.Add(this.NextSongButton);
            this.ROPanel.Controls.Add(this.StopButton);
            this.ROPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ROPanel.Location = new System.Drawing.Point(0, 283);
            this.ROPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ROPanel.Name = "ROPanel";
            this.ROPanel.Size = new System.Drawing.Size(639, 81);
            this.ROPanel.TabIndex = 5;
            // 
            // UploadSongButton
            // 
            this.UploadSongButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UploadSongButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadSongButton.ForeColor = System.Drawing.Color.Aqua;
            this.UploadSongButton.Location = new System.Drawing.Point(477, 49);
            this.UploadSongButton.Margin = new System.Windows.Forms.Padding(2);
            this.UploadSongButton.Name = "UploadSongButton";
            this.UploadSongButton.Size = new System.Drawing.Size(142, 30);
            this.UploadSongButton.TabIndex = 8;
            this.UploadSongButton.Text = "Upload Song";
            this.UploadSongButton.UseVisualStyleBackColor = false;
            this.UploadSongButton.Click += new System.EventHandler(this.UploadSongButton_Click);
            // 
            // VolLabel
            // 
            this.VolLabel.AutoSize = true;
            this.VolLabel.Location = new System.Drawing.Point(9, 32);
            this.VolLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VolLabel.Name = "VolLabel";
            this.VolLabel.Size = new System.Drawing.Size(42, 13);
            this.VolLabel.TabIndex = 0;
            this.VolLabel.Text = "Volume";
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.AutoSize = true;
            this.VolumeLabel.Location = new System.Drawing.Point(72, 32);
            this.VolumeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(35, 13);
            this.VolumeLabel.TabIndex = 4;
            this.VolumeLabel.Text = "label1";
            this.VolumeLabel.Visible = false;
            // 
            // SongTimeLabel
            // 
            this.SongTimeLabel.AutoSize = true;
            this.SongTimeLabel.Location = new System.Drawing.Point(491, 11);
            this.SongTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SongTimeLabel.Name = "SongTimeLabel";
            this.SongTimeLabel.Size = new System.Drawing.Size(28, 13);
            this.SongTimeLabel.TabIndex = 4;
            this.SongTimeLabel.Text = "0:00";
            // 
            // VolumeTrackBar
            // 
            this.VolumeTrackBar.Location = new System.Drawing.Point(2, 0);
            this.VolumeTrackBar.Margin = new System.Windows.Forms.Padding(2);
            this.VolumeTrackBar.Name = "VolumeTrackBar";
            this.VolumeTrackBar.Size = new System.Drawing.Size(104, 45);
            this.VolumeTrackBar.TabIndex = 3;
            this.VolumeTrackBar.Scroll += new System.EventHandler(this.VolumeTrackBar_Scroll);
            // 
            // SongTimeProgressBar
            // 
            this.SongTimeProgressBar.Location = new System.Drawing.Point(128, 11);
            this.SongTimeProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.SongTimeProgressBar.Name = "SongTimeProgressBar";
            this.SongTimeProgressBar.Size = new System.Drawing.Size(324, 19);
            this.SongTimeProgressBar.TabIndex = 7;
            // 
            // PreviouSongButton
            // 
            this.PreviouSongButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PreviouSongButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviouSongButton.ForeColor = System.Drawing.Color.Aqua;
            this.PreviouSongButton.Location = new System.Drawing.Point(168, 49);
            this.PreviouSongButton.Margin = new System.Windows.Forms.Padding(2);
            this.PreviouSongButton.Name = "PreviouSongButton";
            this.PreviouSongButton.Size = new System.Drawing.Size(66, 30);
            this.PreviouSongButton.TabIndex = 2;
            this.PreviouSongButton.Text = "⏮";
            this.PreviouSongButton.UseVisualStyleBackColor = false;
            this.PreviouSongButton.Click += new System.EventHandler(this.PreviouSongButton_Click);
            // 
            // NextSongButton
            // 
            this.NextSongButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.NextSongButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextSongButton.ForeColor = System.Drawing.Color.Aqua;
            this.NextSongButton.Location = new System.Drawing.Point(386, 49);
            this.NextSongButton.Margin = new System.Windows.Forms.Padding(2);
            this.NextSongButton.Name = "NextSongButton";
            this.NextSongButton.Size = new System.Drawing.Size(66, 30);
            this.NextSongButton.TabIndex = 1;
            this.NextSongButton.Text = "⏭";
            this.NextSongButton.UseVisualStyleBackColor = false;
            this.NextSongButton.Click += new System.EventHandler(this.NextSongButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopButton.ForeColor = System.Drawing.Color.Aqua;
            this.StopButton.Location = new System.Drawing.Point(276, 49);
            this.StopButton.Margin = new System.Windows.Forms.Padding(2);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(66, 30);
            this.StopButton.TabIndex = 0;
            this.StopButton.Text = "⏸️";
            this.StopButton.UseVisualStyleBackColor = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SongTimeTrackBar);
            this.panel1.Controls.Add(this.SearchButton);
            this.panel1.Controls.Add(this.SearchTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 40);
            this.panel1.TabIndex = 6;
            // 
            // SongTimeTrackBar
            // 
            this.SongTimeTrackBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.SongTimeTrackBar.Location = new System.Drawing.Point(0, 0);
            this.SongTimeTrackBar.Margin = new System.Windows.Forms.Padding(2);
            this.SongTimeTrackBar.Name = "SongTimeTrackBar";
            this.SongTimeTrackBar.Size = new System.Drawing.Size(324, 40);
            this.SongTimeTrackBar.TabIndex = 6;
            this.SongTimeTrackBar.UseWaitCursor = true;
            this.SongTimeTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SongTimeTrackBar_MouseUp);
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SearchButton.ForeColor = System.Drawing.Color.Aqua;
            this.SearchButton.Location = new System.Drawing.Point(494, 5);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(2);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(88, 28);
            this.SearchButton.TabIndex = 0;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(410, 10);
            this.SearchTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(82, 20);
            this.SearchTextBox.TabIndex = 1;
            // 
            // SSFLPanel
            // 
            this.SSFLPanel.AutoScroll = true;
            this.SSFLPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SSFLPanel.Controls.Add(this.flowLayoutPanel1);
            this.SSFLPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.SSFLPanel.Location = new System.Drawing.Point(199, 40);
            this.SSFLPanel.Margin = new System.Windows.Forms.Padding(2);
            this.SSFLPanel.Name = "SSFLPanel";
            this.SSFLPanel.Size = new System.Drawing.Size(440, 243);
            this.SSFLPanel.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 243);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // ImportSongPanel
            // 
            this.ImportSongPanel.Controls.Add(this.BackButton);
            this.ImportSongPanel.Controls.Add(this.GenreTextBox);
            this.ImportSongPanel.Controls.Add(this.GenreLabel);
            this.ImportSongPanel.Controls.Add(this.ConfirmUploadButton);
            this.ImportSongPanel.Controls.Add(this.YearTextBox);
            this.ImportSongPanel.Controls.Add(this.YearLabel);
            this.ImportSongPanel.Controls.Add(this.ArtistTextBox);
            this.ImportSongPanel.Controls.Add(this.ArtistLabel);
            this.ImportSongPanel.Controls.Add(this.AlbumTextBox);
            this.ImportSongPanel.Controls.Add(this.AlbumLabel);
            this.ImportSongPanel.Controls.Add(this.NameTextBox);
            this.ImportSongPanel.Controls.Add(this.NameLabel);
            this.ImportSongPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImportSongPanel.Location = new System.Drawing.Point(200, 40);
            this.ImportSongPanel.Name = "ImportSongPanel";
            this.ImportSongPanel.Size = new System.Drawing.Size(439, 243);
            this.ImportSongPanel.TabIndex = 8;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackButton.ForeColor = System.Drawing.Color.Aqua;
            this.BackButton.Location = new System.Drawing.Point(257, 207);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(100, 27);
            this.BackButton.TabIndex = 11;
            this.BackButton.Text = "Atras";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // GenreTextBox
            // 
            this.GenreTextBox.Location = new System.Drawing.Point(198, 134);
            this.GenreTextBox.Name = "GenreTextBox";
            this.GenreTextBox.Size = new System.Drawing.Size(100, 20);
            this.GenreTextBox.TabIndex = 10;
            // 
            // GenreLabel
            // 
            this.GenreLabel.AutoSize = true;
            this.GenreLabel.Location = new System.Drawing.Point(125, 137);
            this.GenreLabel.Name = "GenreLabel";
            this.GenreLabel.Size = new System.Drawing.Size(39, 13);
            this.GenreLabel.TabIndex = 9;
            this.GenreLabel.Text = "Genre:";
            // 
            // ConfirmUploadButton
            // 
            this.ConfirmUploadButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.ConfirmUploadButton.ForeColor = System.Drawing.Color.Aqua;
            this.ConfirmUploadButton.Location = new System.Drawing.Point(128, 207);
            this.ConfirmUploadButton.Name = "ConfirmUploadButton";
            this.ConfirmUploadButton.Size = new System.Drawing.Size(100, 27);
            this.ConfirmUploadButton.TabIndex = 8;
            this.ConfirmUploadButton.Text = "Importar";
            this.ConfirmUploadButton.UseVisualStyleBackColor = false;
            this.ConfirmUploadButton.Click += new System.EventHandler(this.ConfirmUploadButton_Click);
            // 
            // YearTextBox
            // 
            this.YearTextBox.Location = new System.Drawing.Point(198, 172);
            this.YearTextBox.Name = "YearTextBox";
            this.YearTextBox.Size = new System.Drawing.Size(100, 20);
            this.YearTextBox.TabIndex = 7;
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.Location = new System.Drawing.Point(125, 175);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(32, 13);
            this.YearLabel.TabIndex = 6;
            this.YearLabel.Text = "Year:";
            // 
            // ArtistTextBox
            // 
            this.ArtistTextBox.Location = new System.Drawing.Point(198, 95);
            this.ArtistTextBox.Name = "ArtistTextBox";
            this.ArtistTextBox.Size = new System.Drawing.Size(100, 20);
            this.ArtistTextBox.TabIndex = 5;
            // 
            // ArtistLabel
            // 
            this.ArtistLabel.AutoSize = true;
            this.ArtistLabel.Location = new System.Drawing.Point(125, 98);
            this.ArtistLabel.Name = "ArtistLabel";
            this.ArtistLabel.Size = new System.Drawing.Size(33, 13);
            this.ArtistLabel.TabIndex = 4;
            this.ArtistLabel.Text = "Artist:";
            // 
            // AlbumTextBox
            // 
            this.AlbumTextBox.Location = new System.Drawing.Point(198, 48);
            this.AlbumTextBox.Name = "AlbumTextBox";
            this.AlbumTextBox.Size = new System.Drawing.Size(100, 20);
            this.AlbumTextBox.TabIndex = 3;
            // 
            // AlbumLabel
            // 
            this.AlbumLabel.AutoSize = true;
            this.AlbumLabel.Location = new System.Drawing.Point(125, 51);
            this.AlbumLabel.Name = "AlbumLabel";
            this.AlbumLabel.Size = new System.Drawing.Size(39, 13);
            this.AlbumLabel.TabIndex = 2;
            this.AlbumLabel.Text = "Album:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(198, 10);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(125, 13);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name:";
            // 
            // SongTimeTimer
            // 
            this.SongTimeTimer.Tick += new System.EventHandler(this.SongTimeTimer_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "WAV|*.wav|MP3|*.mp3|MP4|*.mp4";
            this.openFileDialog1.Title = "Song";
            // 
            // PlaylistsFlowLayoutPanel
            // 
            this.PlaylistsFlowLayoutPanel.AutoScroll = true;
            this.PlaylistsFlowLayoutPanel.Controls.Add(this.NewPlaylistButton);
            this.PlaylistsFlowLayoutPanel.Controls.Add(this.DeletePlaylistButton);
            this.PlaylistsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.PlaylistsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PlaylistsFlowLayoutPanel.Location = new System.Drawing.Point(0, 40);
            this.PlaylistsFlowLayoutPanel.Name = "PlaylistsFlowLayoutPanel";
            this.PlaylistsFlowLayoutPanel.Size = new System.Drawing.Size(200, 243);
            this.PlaylistsFlowLayoutPanel.TabIndex = 11;
            // 
            // NewPlaylistButton
            // 
            this.NewPlaylistButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.NewPlaylistButton.ForeColor = System.Drawing.Color.Aqua;
            this.NewPlaylistButton.Location = new System.Drawing.Point(2, 2);
            this.NewPlaylistButton.Margin = new System.Windows.Forms.Padding(2);
            this.NewPlaylistButton.Name = "NewPlaylistButton";
            this.NewPlaylistButton.Size = new System.Drawing.Size(88, 28);
            this.NewPlaylistButton.TabIndex = 1;
            this.NewPlaylistButton.Text = "New Playlist";
            this.NewPlaylistButton.UseVisualStyleBackColor = false;
            this.NewPlaylistButton.Click += new System.EventHandler(this.NewPlaylistButton_Click);
            // 
            // PlaylistCreatorPanel
            // 
            this.PlaylistCreatorPanel.Controls.Add(this.BackcrButton);
            this.PlaylistCreatorPanel.Controls.Add(this.PrivateCheckBox);
            this.PlaylistCreatorPanel.Controls.Add(this.SongplLabel);
            this.PlaylistCreatorPanel.Controls.Add(this.SongsComboBox);
            this.PlaylistCreatorPanel.Controls.Add(this.PlaylistNameLabel);
            this.PlaylistCreatorPanel.Controls.Add(this.CreatePlaylistButton);
            this.PlaylistCreatorPanel.Controls.Add(this.PlaylistNameTextBox);
            this.PlaylistCreatorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlaylistCreatorPanel.Location = new System.Drawing.Point(200, 40);
            this.PlaylistCreatorPanel.Name = "PlaylistCreatorPanel";
            this.PlaylistCreatorPanel.Size = new System.Drawing.Size(439, 243);
            this.PlaylistCreatorPanel.TabIndex = 12;
            // 
            // PrivateCheckBox
            // 
            this.PrivateCheckBox.AutoSize = true;
            this.PrivateCheckBox.Location = new System.Drawing.Point(151, 114);
            this.PrivateCheckBox.Name = "PrivateCheckBox";
            this.PrivateCheckBox.Size = new System.Drawing.Size(62, 17);
            this.PrivateCheckBox.TabIndex = 7;
            this.PrivateCheckBox.Text = "Privado";
            this.PrivateCheckBox.UseVisualStyleBackColor = true;
            // 
            // SongplLabel
            // 
            this.SongplLabel.AutoSize = true;
            this.SongplLabel.Location = new System.Drawing.Point(151, 82);
            this.SongplLabel.Name = "SongplLabel";
            this.SongplLabel.Size = new System.Drawing.Size(35, 13);
            this.SongplLabel.TabIndex = 6;
            this.SongplLabel.Text = "Song:";
            // 
            // SongsComboBox
            // 
            this.SongsComboBox.FormattingEnabled = true;
            this.SongsComboBox.Location = new System.Drawing.Point(210, 74);
            this.SongsComboBox.Name = "SongsComboBox";
            this.SongsComboBox.Size = new System.Drawing.Size(121, 21);
            this.SongsComboBox.TabIndex = 5;
            this.SongsComboBox.SelectedIndexChanged += new System.EventHandler(this.SongsComboBox_SelectedIndexChanged);
            // 
            // PlaylistNameLabel
            // 
            this.PlaylistNameLabel.AutoSize = true;
            this.PlaylistNameLabel.Location = new System.Drawing.Point(148, 38);
            this.PlaylistNameLabel.Name = "PlaylistNameLabel";
            this.PlaylistNameLabel.Size = new System.Drawing.Size(38, 13);
            this.PlaylistNameLabel.TabIndex = 4;
            this.PlaylistNameLabel.Text = "Name:";
            // 
            // CreatePlaylistButton
            // 
            this.CreatePlaylistButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CreatePlaylistButton.ForeColor = System.Drawing.Color.Aqua;
            this.CreatePlaylistButton.Location = new System.Drawing.Point(204, 134);
            this.CreatePlaylistButton.Margin = new System.Windows.Forms.Padding(2);
            this.CreatePlaylistButton.Name = "CreatePlaylistButton";
            this.CreatePlaylistButton.Size = new System.Drawing.Size(88, 28);
            this.CreatePlaylistButton.TabIndex = 2;
            this.CreatePlaylistButton.Text = "Create";
            this.CreatePlaylistButton.UseVisualStyleBackColor = false;
            this.CreatePlaylistButton.Click += new System.EventHandler(this.CreatePlaylistButton_Click);
            // 
            // PlaylistNameTextBox
            // 
            this.PlaylistNameTextBox.Location = new System.Drawing.Point(210, 35);
            this.PlaylistNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.PlaylistNameTextBox.Name = "PlaylistNameTextBox";
            this.PlaylistNameTextBox.Size = new System.Drawing.Size(82, 20);
            this.PlaylistNameTextBox.TabIndex = 3;
            // 
            // BackcrButton
            // 
            this.BackcrButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackcrButton.ForeColor = System.Drawing.Color.Aqua;
            this.BackcrButton.Location = new System.Drawing.Point(204, 175);
            this.BackcrButton.Margin = new System.Windows.Forms.Padding(2);
            this.BackcrButton.Name = "BackcrButton";
            this.BackcrButton.Size = new System.Drawing.Size(88, 28);
            this.BackcrButton.TabIndex = 8;
            this.BackcrButton.Text = "Back";
            this.BackcrButton.UseVisualStyleBackColor = false;
            this.BackcrButton.Click += new System.EventHandler(this.BackcrButton_Click);
            // 
            // DeleteSongButton
            // 
            this.DeleteSongButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DeleteSongButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteSongButton.ForeColor = System.Drawing.Color.Aqua;
            this.DeleteSongButton.Location = new System.Drawing.Point(2, 49);
            this.DeleteSongButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteSongButton.Name = "DeleteSongButton";
            this.DeleteSongButton.Size = new System.Drawing.Size(142, 30);
            this.DeleteSongButton.TabIndex = 9;
            this.DeleteSongButton.Text = "Delete Song\r\n";
            this.DeleteSongButton.UseVisualStyleBackColor = false;
            this.DeleteSongButton.Click += new System.EventHandler(this.DeleteSongButton_Click);
            // 
            // DeleteSongPanel
            // 
            this.DeleteSongPanel.Controls.Add(this.DeleteBackButton);
            this.DeleteSongPanel.Controls.Add(this.ConfirmDeleteButton);
            this.DeleteSongPanel.Controls.Add(this.DeleteSongComboBox);
            this.DeleteSongPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteSongPanel.Location = new System.Drawing.Point(200, 40);
            this.DeleteSongPanel.Name = "DeleteSongPanel";
            this.DeleteSongPanel.Size = new System.Drawing.Size(439, 243);
            this.DeleteSongPanel.TabIndex = 9;
            // 
            // DeleteSongComboBox
            // 
            this.DeleteSongComboBox.FormattingEnabled = true;
            this.DeleteSongComboBox.Location = new System.Drawing.Point(142, 48);
            this.DeleteSongComboBox.Name = "DeleteSongComboBox";
            this.DeleteSongComboBox.Size = new System.Drawing.Size(121, 21);
            this.DeleteSongComboBox.TabIndex = 0;
            // 
            // ConfirmDeleteButton
            // 
            this.ConfirmDeleteButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ConfirmDeleteButton.ForeColor = System.Drawing.Color.Aqua;
            this.ConfirmDeleteButton.Location = new System.Drawing.Point(154, 90);
            this.ConfirmDeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.ConfirmDeleteButton.Name = "ConfirmDeleteButton";
            this.ConfirmDeleteButton.Size = new System.Drawing.Size(88, 28);
            this.ConfirmDeleteButton.TabIndex = 1;
            this.ConfirmDeleteButton.Text = "Delete";
            this.ConfirmDeleteButton.UseVisualStyleBackColor = false;
            this.ConfirmDeleteButton.Click += new System.EventHandler(this.ConfirmDeleteButton_Click);
            // 
            // DeleteBackButton
            // 
            this.DeleteBackButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DeleteBackButton.ForeColor = System.Drawing.Color.Aqua;
            this.DeleteBackButton.Location = new System.Drawing.Point(154, 137);
            this.DeleteBackButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteBackButton.Name = "DeleteBackButton";
            this.DeleteBackButton.Size = new System.Drawing.Size(88, 28);
            this.DeleteBackButton.TabIndex = 2;
            this.DeleteBackButton.Text = "Back\r\n";
            this.DeleteBackButton.UseVisualStyleBackColor = false;
            this.DeleteBackButton.Click += new System.EventHandler(this.DeleteBackButton_Click);
            // 
            // DeletePlaylistButton
            // 
            this.DeletePlaylistButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DeletePlaylistButton.ForeColor = System.Drawing.Color.Aqua;
            this.DeletePlaylistButton.Location = new System.Drawing.Point(2, 34);
            this.DeletePlaylistButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeletePlaylistButton.Name = "DeletePlaylistButton";
            this.DeletePlaylistButton.Size = new System.Drawing.Size(88, 28);
            this.DeletePlaylistButton.TabIndex = 2;
            this.DeletePlaylistButton.Text = "Delete Playlist";
            this.DeletePlaylistButton.UseVisualStyleBackColor = false;
            this.DeletePlaylistButton.Click += new System.EventHandler(this.DeletePlaylistButton_Click);
            // 
            // DeletePlaylistPanel
            // 
            this.DeletePlaylistPanel.Controls.Add(this.DeletePlaylistBackButton);
            this.DeletePlaylistPanel.Controls.Add(this.DefDeletePlaylistButton);
            this.DeletePlaylistPanel.Controls.Add(this.DeletePlaylistComboBox);
            this.DeletePlaylistPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeletePlaylistPanel.Location = new System.Drawing.Point(200, 40);
            this.DeletePlaylistPanel.Name = "DeletePlaylistPanel";
            this.DeletePlaylistPanel.Size = new System.Drawing.Size(439, 243);
            this.DeletePlaylistPanel.TabIndex = 10;
            // 
            // DeletePlaylistBackButton
            // 
            this.DeletePlaylistBackButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DeletePlaylistBackButton.ForeColor = System.Drawing.Color.Aqua;
            this.DeletePlaylistBackButton.Location = new System.Drawing.Point(154, 137);
            this.DeletePlaylistBackButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeletePlaylistBackButton.Name = "DeletePlaylistBackButton";
            this.DeletePlaylistBackButton.Size = new System.Drawing.Size(88, 28);
            this.DeletePlaylistBackButton.TabIndex = 2;
            this.DeletePlaylistBackButton.Text = "Back\r\n";
            this.DeletePlaylistBackButton.UseVisualStyleBackColor = false;
            this.DeletePlaylistBackButton.Click += new System.EventHandler(this.DeletePlaylistBackButton_Click);
            // 
            // DefDeletePlaylistButton
            // 
            this.DefDeletePlaylistButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DefDeletePlaylistButton.ForeColor = System.Drawing.Color.Aqua;
            this.DefDeletePlaylistButton.Location = new System.Drawing.Point(154, 90);
            this.DefDeletePlaylistButton.Margin = new System.Windows.Forms.Padding(2);
            this.DefDeletePlaylistButton.Name = "DefDeletePlaylistButton";
            this.DefDeletePlaylistButton.Size = new System.Drawing.Size(88, 28);
            this.DefDeletePlaylistButton.TabIndex = 1;
            this.DefDeletePlaylistButton.Text = "Delete";
            this.DefDeletePlaylistButton.UseVisualStyleBackColor = false;
            this.DefDeletePlaylistButton.Click += new System.EventHandler(this.DefDeletePlaylistButton_Click);
            // 
            // DeletePlaylistComboBox
            // 
            this.DeletePlaylistComboBox.FormattingEnabled = true;
            this.DeletePlaylistComboBox.Location = new System.Drawing.Point(142, 48);
            this.DeletePlaylistComboBox.Name = "DeletePlaylistComboBox";
            this.DeletePlaylistComboBox.Size = new System.Drawing.Size(121, 21);
            this.DeletePlaylistComboBox.TabIndex = 0;
            // 
            // SongMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 364);
            this.Controls.Add(this.DeletePlaylistPanel);
            this.Controls.Add(this.DeleteSongPanel);
            this.Controls.Add(this.PlaylistCreatorPanel);
            this.Controls.Add(this.ImportSongPanel);
            this.Controls.Add(this.PlaylistsFlowLayoutPanel);
            this.Controls.Add(this.SSFLPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ROPanel);
            this.Name = "SongMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Canciones";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SongMenuForm_FormClosed);
            this.Load += new System.EventHandler(this.SongMenuForm_Load);
            this.ROPanel.ResumeLayout(false);
            this.ROPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SongTimeTrackBar)).EndInit();
            this.SSFLPanel.ResumeLayout(false);
            this.ImportSongPanel.ResumeLayout(false);
            this.ImportSongPanel.PerformLayout();
            this.PlaylistsFlowLayoutPanel.ResumeLayout(false);
            this.PlaylistCreatorPanel.ResumeLayout(false);
            this.PlaylistCreatorPanel.PerformLayout();
            this.DeleteSongPanel.ResumeLayout(false);
            this.DeletePlaylistPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ROPanel;
        private System.Windows.Forms.Button UploadSongButton;
        private System.Windows.Forms.Label VolLabel;
        private System.Windows.Forms.Label VolumeLabel;
        private System.Windows.Forms.Label SongTimeLabel;
        private System.Windows.Forms.TrackBar VolumeTrackBar;
        private System.Windows.Forms.ProgressBar SongTimeProgressBar;
        private System.Windows.Forms.Button PreviouSongButton;
        private System.Windows.Forms.Button NextSongButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar SongTimeTrackBar;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.FlowLayoutPanel SSFLPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel ImportSongPanel;
        private System.Windows.Forms.TextBox GenreTextBox;
        private System.Windows.Forms.Label GenreLabel;
        private System.Windows.Forms.Button ConfirmUploadButton;
        private System.Windows.Forms.TextBox YearTextBox;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.TextBox ArtistTextBox;
        private System.Windows.Forms.Label ArtistLabel;
        private System.Windows.Forms.TextBox AlbumTextBox;
        private System.Windows.Forms.Label AlbumLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Timer SongTimeTimer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel PlaylistsFlowLayoutPanel;
        private System.Windows.Forms.Button NewPlaylistButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Panel PlaylistCreatorPanel;
        private System.Windows.Forms.Label PlaylistNameLabel;
        private System.Windows.Forms.Button CreatePlaylistButton;
        private System.Windows.Forms.TextBox PlaylistNameTextBox;
        private System.Windows.Forms.Label SongplLabel;
        private System.Windows.Forms.ComboBox SongsComboBox;
        private System.Windows.Forms.CheckBox PrivateCheckBox;
        private System.Windows.Forms.Button BackcrButton;
        private System.Windows.Forms.Button DeleteSongButton;
        private System.Windows.Forms.Panel DeleteSongPanel;
        private System.Windows.Forms.ComboBox DeleteSongComboBox;
        private System.Windows.Forms.Button ConfirmDeleteButton;
        private System.Windows.Forms.Button DeleteBackButton;
        private System.Windows.Forms.Button DeletePlaylistButton;
        private System.Windows.Forms.Panel DeletePlaylistPanel;
        private System.Windows.Forms.Button DeletePlaylistBackButton;
        private System.Windows.Forms.Button DefDeletePlaylistButton;
        private System.Windows.Forms.ComboBox DeletePlaylistComboBox;
    }
}