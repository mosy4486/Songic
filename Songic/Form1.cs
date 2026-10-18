using System.Text;

namespace Songic
{
    public partial class Form1 : Form
    {
        private SongRequestData curRequest = new();
        private SongDataSearcher dataSearcher = new SongDataSearcher();
        private AudioSearcher audioSearcher = new AudioSearcher();
        private Song curSong;

        private AudioPlayer audioPlayer = new();

        private string? curAudioPath;
        public Form1()
        {
            InitializeComponent();
            RefreshUI();
        }

        private void RefreshUI()
        {
            curRequest.artist = ArtistTextBox.Text;
            curRequest.title = TitleTextBox.Text;

            SearchDataButton.Visible = SongRequestData.ValidData(curRequest);
            FindAudioButton.Visible = SongRequestData.ValidData(curRequest);
            PlayButton.Visible = File.Exists(curAudioPath);

            PlayButton.BackColor = audioPlayer.isPlaying? Color.Red : Color.Green;
            PlayButton.Text = audioPlayer.isPlaying ? "중지" : "재생";
        }

        private void ArtistTextBox_TextChanged(object sender, EventArgs e)
        {
            ArtistShowLabel.Text = $"아티스트: {ArtistTextBox.Text}";
            RefreshUI();
        }

        private void SongNameTextBox_TextChanged(object sender, EventArgs e)
        {
            TitleShowLabel.Text = $"제목: {TitleTextBox.Text}";
            RefreshUI();
        }
        private void ShowDataList(Song[] songs)
        {
            foundListPanel.Controls.Clear();

            for (int i = 0; i < songs.Length; i++)
            {
                Button btn = new Button();

                btn.Width = 173;
                btn.Height = 34;

                Font font = new Font("굴림", 8f);
                btn.Font = font;

                btn.Text = $"{i + 1}:{songs[i].artistName}-{songs[i].trackName}\r\n[{songs[i].albumName}]";

                btn.TextAlign = ContentAlignment.MiddleCenter;

                btn.Tag = songs[i];

                btn.Click += SongResult_Click;

                foundListPanel.Controls.Add(btn);
            }
        }

        private void ShowAudioList(YoutubeData[] datas)
        {
            foundListPanel.Controls.Clear();

            for (int i = 0; i < datas.Length; i++)
            {
                Button btn = new Button();

                btn.Width = 173;
                btn.Height = 34;

                Font font = new Font("굴림", 8f);
                btn.Font = font;

                btn.Text = $"{i + 1}:{datas[i].title}\r\n[{datas[i].channelTitle}";

                btn.TextAlign = ContentAlignment.MiddleCenter;

                btn.Tag = datas[i];

                btn.Click += SongResult_Click;

                foundListPanel.Controls.Add(btn);
            }
        }

        private void SongResult_Click(object? sender, EventArgs e)
        {
            Button btn = (Button)sender!;

            var result = btn.Tag;

            if (result is Song)
            {
                ShowSongData((Song)result);
            }
            else if (result is YoutubeData)
            {
                ConvertAudioData((YoutubeData)result);
            }
        }
        private void ShowSongData(Song data)
        {

            StringBuilder sb = new();
            sb.AppendLine(Environment.NewLine + $"제목: {data.trackName}");
            sb.AppendLine($"아티스트: {data.artistName}");
            sb.AppendLine($"앨범: {data.albumName}");
            sb.AppendLine($"길이: {data.duration}초" + Environment.NewLine);

            var result = GetLyricsByAll(data.plainLyrics);

            if (!result.success) sb.AppendLine("가사 로딩 실패");

            foreach (var lyric in result.lyrics) sb.AppendLine(lyric.content);

            ResultTextBox.Text = sb.ToString();
        }

        private async void ConvertAudioData(YoutubeData data)
        {
            LogTextBox.Text = $"오디오 변환중";

            var result = await AudioConverter.ConvertAudio(data);

            if (result.success)
            {
                LogTextBox.Text = $"오디오 저장 완료: {result.path}";
            }
            else
            {
                LogTextBox.Text = $"{result.mes}";
            }


            StringBuilder sb = new();
            sb.AppendLine(Environment.NewLine + $"제목: {data.title}");
            sb.AppendLine($"채널: {data.channelTitle}");
            sb.AppendLine($"Id: {data.id}");

            ResultTextBox.Text = sb.ToString();
        }

        private (List<Lyric> lyrics, bool success) GetLyricsByAll(string lyric)
        {
            List<Lyric> lyrics = new();
            if (string.IsNullOrWhiteSpace(lyric) || string.IsNullOrEmpty(lyric)) return (lyrics, false);
            string[] lines = lyric.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                // 빈 줄은 일단 제외
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                lyrics.Add(new Lyric
                {
                    content = line
                });
            }
            return (lyrics, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void FindAudioButton_Click(object sender, EventArgs e)
        {
            LogTextBox.Text = "오디오 검색중";
            var result = await audioSearcher.SearchAudioData(curRequest);
            LogTextBox.Text = result.mes;

            if (result.success)
            {
                ShowAudioList(result.data);
            }
        }

        private async void SearchDataButton_Click(object sender, EventArgs e)
        {
            LogTextBox.Text = "정보 검색중";
            var result = await dataSearcher.SearchSongData(curRequest);
            LogTextBox.Text = result.mes;
            if (result.success)
            {
                ShowDataList(result.song);
            }
        }

        private void OpenAudioFolder_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new();

            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            dialog.Title = "음악 파일 선택";
            dialog.Filter = "MP3 파일 (*.mp3)|*.mp3|모든 파일 (*.*)|*.*";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                curAudioPath = dialog.FileName;
                LogTextBox.Text = Path.GetFileNameWithoutExtension(curAudioPath) + "  선택됨";
            }
            else
            {
                LogTextBox.Text = "파일 선택 오류";
            }

            RefreshUI();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (curAudioPath == null) return;
            audioPlayer.PlayAudio(curAudioPath);
        }
    }
}
