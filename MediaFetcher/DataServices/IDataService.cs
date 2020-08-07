using MediaFetcher.Models;
using System.Threading.Tasks;

namespace MediaFetcher.DataServices
{
    public interface IDataService<MEDIA>
    {
        // Methods for connecting to the service
        string GetKey();
        string GetBaseUrl();

        // Methods for getting data
        Task<MEDIA> GetById(string id);
        Task<PaginatedSearchResults<MEDIA>> GetByName(string name, int page_number);
    }
}
