using System.Threading.Tasks;

namespace MediaFetcher.DataServices
{
    public interface IDataService<T>
    {
        // Methods for connecting to the service
        string GetKey();
        string GetBaseUrl();

        // Methods for getting data
        Task<T> GetById(string id);
        Task<T[]> GetByName(string name);
    }
}
