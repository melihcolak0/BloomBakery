using _15PC_BloomBakery.DTOs.AboutDTOs;
using _15PC_BloomBakery.DTOs.AIDTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _15PC_BloomBakery.AIIntegration
{
    public class RapidApiGPT4oIntegration
    {
        private readonly string _apiKey = "my_rapid_api_key";
        private readonly string _apiHost = "rapid_api_host";
        private readonly string _endpoint = "rapid_api_endpoint";

        public async Task<string> GenerateTextAsync(string prompt)
        {
            using var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_endpoint),
                Headers =
                {
                    { "x-rapidapi-key", _apiKey },
                    { "x-rapidapi-host", _apiHost },
                },
                Content = new StringContent(
                    JsonConvert.SerializeObject(new
                    {
                        messages = new[]
                        {
                            new { role = "user", content = prompt }
                        },
                        web_access = false
                    }),
                    Encoding.UTF8,
                    "application/json"
                )
            };

            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(body);

            return json["result"]?.ToString() ?? "Sonuç alınamadı.";
        }

        public CreateAboutDto ParseAboutText(string text)
        {
            var dto = new CreateAboutDto
            {
                Title = "HAKKIMIZDA",
                ImageUrl = "/baker-1.0.0/img/about-1.jpg",
                ImageUrl2 = "/baker-1.0.0/img/about-2.jpg"
            };

            // Metni temizle
            text = text.Trim();

            // Alt Başlık - ## satırındaki metni al
            var subTitleMatch = Regex.Match(text, @"##\s*(.+?)(?=\r?\n|$)");
            if (subTitleMatch.Success)
            {
                dto.SubTitle = subTitleMatch.Groups[1].Value.Trim();
            }

            // Description - ## ile ### arasındaki tüm metni al (## başlığı hariç)
            var descMatch = Regex.Match(text, @"##.+?[\r\n]+([\s\S]*?)(?=###)", RegexOptions.Singleline);
            if (descMatch.Success)
            {
                dto.Description = descMatch.Groups[1].Value.Trim();
            }

            // Özellikler - **Özellik Adı:** + açıklama (Groups[1]=başlık, Groups[2]=açıklama)
            var featureMatches = Regex.Matches(text, @"-\s*\*\*(.*?)\*\*(?:\s*:(?:\s*.*)?)?");

            dto.Feature1 = featureMatches.Count > 0 ? featureMatches[0].Groups[1].Value.Trim() : "";
            dto.Feature2 = featureMatches.Count > 1 ? featureMatches[1].Groups[1].Value.Trim() : "";
            dto.Feature3 = featureMatches.Count > 2 ? featureMatches[2].Groups[1].Value.Trim() : "";
            dto.Feature4 = featureMatches.Count > 3 ? featureMatches[3].Groups[1].Value.Trim() : "";

            return dto;
        }
    }
}
