using CineReview.Application.DTOs;
using CineReview.Domain;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CineReview.Application.Service
{
    public class TmdbService
    {
        private readonly HttpClient _http;
        private readonly string _apiKey = "3674f184927b08e46a4f797e04493710";

        public TmdbService(HttpClient http)
        {
            _http = http;
        }

        public async Task<TmdbFilmeDto> BuscarFilme(int id)
        {
            string url = $"https://api.themoviedb.org/3/movie/{id}?api_key={_apiKey}&language=pt-BR";

            var response = await _http.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TmdbFilmeDto>(json);
        }


        public async Task<object> BuscarFilmePorTitulo(string titulo)
        {
            string url = $"https://www.omdbapi.com/?t={titulo}&apikey={_apiKey}";

            var response = await _http.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<object>(json);
        }


    }
}
