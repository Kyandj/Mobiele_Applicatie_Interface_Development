using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace Mobiele_Applicatie_Interface_Studio.Services
{
    public class BestellingService
    {
        private readonly HttpClient _httpClient;

        public BestellingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Bestelling?> GetBestellingAsync(string bestellingId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Bestelling>($"http://51.137.100.120:5000/{bestellingId}");
            }
            catch (Exception ex)
            {
                // Log of handel de fout af
                return null;
            }
        }
    }
}
