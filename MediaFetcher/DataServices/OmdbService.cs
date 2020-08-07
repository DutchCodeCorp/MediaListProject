using MediaFetcher.Data;
using MediaFetcher.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MediaFetcher.DataServices
{
    public class OmdbService : IDataService<Movie>
    {
        private static HttpClient Client = new HttpClient();
        public string GetKey() => ConfigurationHandler.GetConfigValue("OmdbKey");
        public string GetBaseUrl() => $"http://www.omdbapi.com/?apikey={this.GetKey()}";

        public async Task<Movie> GetById(string id)
        {
            HttpResponseMessage message = await Client.GetAsync(GetBaseUrl() + $"&i={id}");
            return message.Content.Headers.ContentLength > 100
                ? JsonSerializer.Deserialize<Movie>(await message.Content.ReadAsStringAsync())
                : null;
        }

        public async Task<PaginatedSearchResults<Movie>> GetByName(string name, int page_number = 1)
        {
            HttpResponseMessage message = await Client.GetAsync(GetBaseUrl() + $"&s={name}&type=movie&page={page_number}");

            if (message.Content.Headers.ContentLength > 100)
            {
                var result = JsonSerializer.Deserialize<PaginatedSearchResults<Movie>>(await message.Content.ReadAsStringAsync());
                result.CurrentPage = page_number;
                return result;
            }

            return null;
        }
    }
}
