using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Songic
{
    public class AudioConverter
    {
        private static readonly HttpClient hc = new();
        private static readonly string apiUrl = Environment.GetEnvironmentVariable("SONGIC_COBALT_URL") ?? "http://localhost:9000";
        private static SearcherState State = SearcherState.none;
        public static async Task<(string path, string mes, bool success)> ConvertAudio(YoutubeData data)
        {
            if(State == SearcherState.searching) return ("", "이미 오디오 변환중입니다", false);

            if (string.IsNullOrWhiteSpace(apiUrl)) return ("", "Cobalt 서버 주소 없음", false);
            if (string.IsNullOrWhiteSpace(data.id)) return ("", "영상 ID 없음", false);

            State = SearcherState.searching;
            try
            {
                string videoUrl = $"https://www.youtube.com/watch?v={data.id}";
                string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "Songic");
                Directory.CreateDirectory(savePath);

                var body = new
                {
                    url = videoUrl,
                    downloadMode = "audio",
                    audioFormat = "mp3",
                    audioBitrate = "192"
                };

                using HttpRequestMessage request = new(HttpMethod.Post, apiUrl.TrimEnd('/') + "/");
                request.Content = JsonContent.Create(body);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string? apiKey = Environment.GetEnvironmentVariable("SONGIC_COBALT_API_KEY");
                if (!string.IsNullOrWhiteSpace(apiKey)) request.Headers.TryAddWithoutValidation("Authorization", $"Api-Key {apiKey}");

                using HttpResponseMessage response = await hc.SendAsync(request);
                string json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode) return ("", $"HTTP {(int)response.StatusCode}: {json}", false);

                using JsonDocument doc = JsonDocument.Parse(json);
                JsonElement root = doc.RootElement;

                string status = root.GetProperty("status").GetString() ?? "";

                if (status == "error")
                {
                    string error = root.GetProperty("error").GetProperty("code").GetString() ?? "알 수 없는 오류";
                    return ("", error, false);
                }

                if (status != "tunnel" && status != "redirect") return ("", $"지원하지 않는 응답: {status}", false);

                string downloadUrl = root.GetProperty("url").GetString() ?? "";
                if (string.IsNullOrWhiteSpace(downloadUrl)) return ("", "다운로드 주소 없음", false);
                if (!Uri.TryCreate(downloadUrl, UriKind.Absolute, out Uri? downloadUri) || downloadUri.Scheme != Uri.UriSchemeHttps) return ("", "잘못된 다운로드 주소", false);

                string path = Path.Combine(savePath, $"{data.id}.mp3");

                using HttpResponseMessage fileResponse = await hc.GetAsync(downloadUri, HttpCompletionOption.ResponseHeadersRead);
                fileResponse.EnsureSuccessStatusCode();

                await using Stream source = await fileResponse.Content.ReadAsStreamAsync();
                await using FileStream file = new(path, FileMode.Create, FileAccess.Write, FileShare.None);
                await source.CopyToAsync(file);

                return (path, "변환 성공", true);
            }
            catch (Exception ex)
            {
                return ("", ex.Message, false);
            }
            finally
            {
                State = SearcherState.none;
            }
        }
    }
}