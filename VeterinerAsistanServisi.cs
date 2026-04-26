namespace VeterinerKlinik
{
    using Mscc.GenerativeAI;

    public class VeterinerAsistanServisi
    {
        // Kopyaladığın AIza... ile başlayan anahtarı tırnak içine yapıştır
        private readonly string _apiKey = "AIzaSyBUH8iYoj15LlP6fRVV5UP-GcBtHLCsWlU";

        public async Task<string> SoruSor(string kullaniciMesaji)
        {
            var googleAI = new GoogleAI(_apiKey);
            var model = googleAI.GenerativeModel("models/gemini-pro");

            // Burası yapay zekanın "rolü"
            string sistemTalimati = "Sen uzman bir veteriner asistanısın. Hayvan sağlığı hakkında kısa, nazik ve bilgilendirici cevaplar ver.";

            var response = await model.GenerateContent($"{sistemTalimati} Kullanıcı sorusu: {kullaniciMesaji}");
            return response.Text;
        }
    }
}

