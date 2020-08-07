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

        public Task<Movie[]> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
