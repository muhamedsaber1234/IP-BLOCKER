using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Bussiness_logic.DTOS;
using Microsoft.Extensions.Configuration;

namespace Bussiness_logic.Services
{
    public class GeolocationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string URL;
        public GeolocationService( IConfiguration config)
        {
            _httpClient = new HttpClient();
            _apiKey = config["GeolocationApi:ApiKey"];
            URL = config["GeolocationApi:BaseUrl"] ?? "https://api.ipgeolocation.io/ipgeo";

        }

        public async Task<GeolocationDTO> GetGeolocationAsync(string ip)
        {
            var surl = $"{URL}?apiKey={_apiKey}&ip={ip}";
            var response = await _httpClient.GetAsync(surl);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadFromJsonAsync<JsonElement>();

            return new GeolocationDTO(
                json.GetProperty("ip").GetString()!,
                json.GetProperty("country_code2").GetString()!,
                json.GetProperty("country_name").GetString()!,
                json.GetProperty("isp").GetString()!
            );
        }
    }
}
