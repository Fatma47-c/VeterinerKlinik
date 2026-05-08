using System.Text;
using System.Text.Json;

namespace VeterinerKlinik
{
    public class VeterinerAsistanServisi
    {
        private readonly string _apiKey = "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";
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<string> SoruSor(string kullaniciMesaji)
        {
            var requestBody = new
            {
                model = "llama-3.3-70b-versatile",
                messages = new[]
                {
                    new { role = "system", content = "Sen uzman bir veteriner asistanısın. Hayvan sağlığı hakkında kısa, nazik ve bilgilendirici cevaplar ver. Türkçe yanıt ver." },
                    new { role = "user", content = kullaniciMesaji }
                },
                max_tokens = 1024
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            var response = await _httpClient.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return $"Hata: {responseString}";

            using var doc = JsonDocument.Parse(responseString);
            var text = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return text ?? "Cevap alınamadı.";
        }
    }
}