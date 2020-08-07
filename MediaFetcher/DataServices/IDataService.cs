using MediaFetcher.Models;
using System.Threading.Tasks;

namespace MediaFetcher.DataServices
{
    public interface IDataService<FULLENTITY, SHORTENTITY>
    {
        // Methods for connecting to the service
        string GetKey();
        string GetBaseUrl();

        // Methods for getting data
        Task<FULLENTITY> GetById(string id);
        Task<PaginatedSearchResults<SHORTENTITY>> GetByName(string name, int page_number);
    }
}
