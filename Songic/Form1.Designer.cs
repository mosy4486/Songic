namespace Songic
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            title1 = new Label();
            ArtistTextBox = new TextBox();
            TitleTextBox = new TextBox();
            panel1 = new Panel();
            ResultTextBox = new TextBox();
            foundListPanel = new FlowLayoutPanel();
            LogTextBox = new TextBox();
            panel2 = new Panel();
            PlayButton = new Button();
            OpenAudioFolder = new Button();
            panel4 = new Panel();
            ArtistShowLabel = new Label();
            FindAudioButton = new Button();
            panel3 = new Panel();
            TitleShowLabel = new Label();
            SearchDataButton = new Button();
            contextMenuStrip2 = new ContextMenuStrip(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // title1
            // 
            title1.Anchor = AnchorStyles.None;
            title1.AutoSize = true;
            title1.Font = new Font("궁서", 30F, FontStyle.Bold, GraphicsUnit.Point, 129);
            title1.Location = new Point(254, 44);
            title1.Name = "title1";
            title1.Size = new Size(170, 40);
            title1.TabIndex = 2;
            title1.Text = "Songic";
            title1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ArtistTextBox
            // 
            ArtistTextBox.Anchor = AnchorStyles.None;
            ArtistTextBox.Font = new Font("굴림", 9F);
            ArtistTextBox.Location = new Point(137, 135);
            ArtistTextBox.Name = "ArtistTextBox";
            ArtistTextBox.PlaceholderText = "아티스트 입력 (선택)";
            ArtistTextBox.Size = new Size(376, 21);
            ArtistTextBox.TabIndex = 3;
            ArtistTextBox.TextAlign = HorizontalAlignment.Center;
            ArtistTextBox.TextChanged += ArtistTextBox_TextChanged;
            // 
            // TitleTextBox
            // 
            TitleTextBox.Anchor = AnchorStyles.None;
            TitleTextBox.Font = new Font("굴림", 9F);
            TitleTextBox.Location = new Point(137, 102);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.PlaceholderText = "제목 입력 (선택)";
            TitleTextBox.Size = new Size(376, 21);
            TitleTextBox.TabIndex = 4;
            TitleTextBox.TextAlign = HorizontalAlignment.Center;
            TitleTextBox.TextChanged += SongNameTextBox_TextChanged;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.Lavender;
            panel1.Controls.Add(ResultTextBox);
            panel1.Controls.Add(foundListPanel);
            panel1.Controls.Add(LogTextBox);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(32, 179);
            panel1.Name = "panel1";
            panel1.Size = new Size(596, 430);
            panel1.TabIndex = 5;
            // 
            // ResultTextBox
            // 
            ResultTextBox.Anchor = AnchorStyles.None;
            ResultTextBox.BackColor = SystemColors.Control;
            ResultTextBox.Font = new Font("굴림체", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            ResultTextBox.Location = new Point(216, 64);
            ResultTextBox.Multiline = true;
            ResultTextBox.Name = "ResultTextBox";
            ResultTextBox.ReadOnly = true;
            ResultTextBox.ScrollBars = ScrollBars.Vertical;
            ResultTextBox.Size = new Size(377, 351);
            ResultTextBox.TabIndex = 8;
            ResultTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // foundListPanel
            // 
            foundListPanel.Anchor = AnchorStyles.None;
            foundListPanel.AutoScroll = true;
            foundListPanel.BackColor = SystemColors.InactiveBorder;
            foundListPanel.FlowDirection = FlowDirection.TopDown;
            foundListPanel.Font = new Font("굴림", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            foundListPanel.Location = new Point(19, 92);
            foundListPanel.Name = "foundListPanel";
            foundListPanel.Size = new Size(176, 323);
            foundListPanel.TabIndex = 6;
            // 
            // LogTextBox
            // 
            LogTextBox.Anchor = AnchorStyles.None;
            LogTextBox.BackColor = SystemColors.Control;
            LogTextBox.Font = new Font("굴림", 9.75F);
            LogTextBox.Location = new Point(22, 64);
            LogTextBox.Name = "LogTextBox";
            LogTextBox.ReadOnly = true;
            LogTextBox.Size = new Size(173, 22);
            LogTextBox.TabIndex = 7;
            LogTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = SystemColors.InactiveCaption;
            panel2.Controls.Add(PlayButton);
            panel2.Controls.Add(OpenAudioFolder);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(FindAudioButton);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(SearchDataButton);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(596, 58);
            panel2.TabIndex = 6;
            // 
            // PlayButton
            // 
            PlayButton.Anchor = AnchorStyles.None;
            PlayButton.Font = new Font("굴림", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            PlayButton.Location = new Point(529, 11);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(44, 37);
            PlayButton.TabIndex = 6;
            PlayButton.UseVisualStyleBackColor = true;
            PlayButton.Visible = false;
            PlayButton.Click += PlayButton_Click;
            // 
            // OpenAudioFolder
            // 
            OpenAudioFolder.Anchor = AnchorStyles.None;
            OpenAudioFolder.Font = new Font("굴림", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            OpenAudioFolder.Location = new Point(479, 11);
            OpenAudioFolder.Name = "OpenAudioFolder";
            OpenAudioFolder.Size = new Size(44, 37);
            OpenAudioFolder.TabIndex = 5;
            OpenAudioFolder.Text = "파일 선택";
            OpenAudioFolder.UseVisualStyleBackColor = true;
            OpenAudioFolder.Visible = false;
            OpenAudioFolder.Click += OpenAudioFolder_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Gainsboro;
            panel4.Controls.Add(ArtistShowLabel);
            panel4.Location = new Point(3, 28);
            panel4.Name = "panel4";
            panel4.Size = new Size(204, 24);
            panel4.TabIndex = 4;
            // 
            // ArtistShowLabel
            // 
            ArtistShowLabel.Anchor = AnchorStyles.None;
            ArtistShowLabel.BackColor = Color.GhostWhite;
            ArtistShowLabel.Font = new Font("굴림", 9F);
            ArtistShowLabel.Location = new Point(0, 2);
            ArtistShowLabel.Name = "ArtistShowLabel";
            ArtistShowLabel.Size = new Size(204, 22);
            ArtistShowLabel.TabIndex = 0;
            ArtistShowLabel.Text = "Artist";
            // 
            // FindAudioButton
            // 
            FindAudioButton.Anchor = AnchorStyles.None;
            FindAudioButton.Font = new Font("굴림", 9F, FontStyle.Bold);
            FindAudioButton.Location = new Point(354, 11);
            FindAudioButton.Name = "FindAudioButton";
            FindAudioButton.Size = new Size(119, 37);
            FindAudioButton.TabIndex = 2;
            FindAudioButton.Text = "재생 파일 찾기";
            FindAudioButton.UseVisualStyleBackColor = true;
            FindAudioButton.Click += FindAudioButton_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Gainsboro;
            panel3.Controls.Add(TitleShowLabel);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(204, 24);
            panel3.TabIndex = 3;
            // 
            // TitleShowLabel
            // 
            TitleShowLabel.Anchor = AnchorStyles.None;
            TitleShowLabel.BackColor = Color.GhostWhite;
            TitleShowLabel.Font = new Font("굴림", 9F);
            TitleShowLabel.Location = new Point(-3, 0);
            TitleShowLabel.Name = "TitleShowLabel";
            TitleShowLabel.Size = new Size(207, 22);
            TitleShowLabel.TabIndex = 1;
            TitleShowLabel.Text = "Title";
            // 
            // SearchDataButton
            // 
            SearchDataButton.Anchor = AnchorStyles.None;
            SearchDataButton.Font = new Font("굴림", 9F, FontStyle.Bold);
            SearchDataButton.Location = new Point(229, 11);
            SearchDataButton.Name = "SearchDataButton";
            SearchDataButton.Size = new Size(119, 37);
            SearchDataButton.TabIndex = 1;
            SearchDataButton.Text = "노래 정보 찾기";
            SearchDataButton.UseVisualStyleBackColor = true;
            SearchDataButton.Click += SearchDataButton_Click;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(657, 632);
            Controls.Add(panel1);
            Controls.Add(TitleTextBox);
            Controls.Add(ArtistTextBox);
            Controls.Add(title1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private Label title1;
        private TextBox ArtistTextBox;
        private TextBox TitleTextBox;
        private Panel panel1;
        private Panel panel2;
        private Button FindAudioButton;
        private Button SearchDataButton;
        private Panel panel3;
        private Label TitleShowLabel;
        private Label ArtistShowLabel;
        private TextBox LogTextBox;
        private Panel panel4;
        private TextBox ResultTextBox;
        private ContextMenuStrip contextMenuStrip2;
        private FlowLayoutPanel foundListPanel;
        private Button PlayButton;
        private Button OpenAudioFolder;
    }
}
