using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

using System.Text.Json;
namespace Songic
{
    public class AudioSearcher
    {
        private HttpClient hc = new();
        public SearcherState State { get; private set; } = SearcherState.none;
        private readonly string apiKey;
        public AudioSearcher()
        {
            apiKey = Environment.GetEnvironmentVariable("SONGIC_YOUTUBE_API_KEY")
                ?? throw new Exception("API Key가 없습니다.");
        }


        public async Task<(YoutubeData[] data,string mes,bool success)> SearchAudioData(SongRequestData rd)
        {
            if (State == SearcherState.searching) return (new YoutubeData[0], "이미 정보 검색중", false);

            State = SearcherState.searching;

            string query = Uri.EscapeDataString($"{rd.title} {rd.artist}");
            string url = $"https://www.googleapis.com/youtube/v3/search?part=snippet&type=video&maxResults=20&q={query}&key={apiKey}";

            HttpResponseMessage response = await hc.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(json);
                return (Array.Empty<YoutubeData>(), "API 요청 실패", false);
            }

            try
            {
                using JsonDocument doc = JsonDocument.Parse(json);
                List<YoutubeData> data = new();


                foreach (JsonElement item in doc.RootElement.GetProperty("items").EnumerateArray())
                {
                    if (!item.TryGetProperty("id", out JsonElement id)) continue;
                    if (!id.TryGetProperty("videoId", out JsonElement videoId)) continue;
                    if (!item.TryGetProperty("snippet", out JsonElement snippet)) continue;

                    YoutubeData video = new()
                    {
                        id = videoId.GetString() ?? "",
                        title = snippet.TryGetProperty("title", out JsonElement title) ? title.GetString() ?? "" : "",
                        channelTitle = snippet.TryGetProperty("channelTitle", out JsonElement channel) ? channel.GetString() ?? "" : ""
                    };

                    data.Add(video);
                }


                if (data.Count == 0) return (new YoutubeData[0], "검색 결과 없음", false);

                return (data.ToArray(), "성공", true);
            }
            catch (JsonException ex)
            {
                return (new YoutubeData[0], $"JSON 변환 실패: {ex.Message}", false);
            }

            finally
            {
                State = SearcherState.none;
            }
        }
    }

    public struct YoutubeData
    {
        public string id;
        public string title;
        public string channelTitle;
    }
}
