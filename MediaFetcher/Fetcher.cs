using MediaFetcher.DataServices;
using MediaFetcher.Models;
using System;
using System.Threading.Tasks;

namespace MediaFetcher
{
    public class Fetcher
    {
        private async static Task<T> PerformAction<T>(Func<IDataService<Movie>, Task<T>> action)
        {
            //TODO: Create and use a service factory
            IDataService<Movie> service = new OmdbService();
            return service != null ? await action(service) : default;
        }

        public async static Task<PaginatedSearchResults<Movie>> Search(string search, int page_number = 1)
        {
            return await PerformAction(
                async service => await service.GetByName(search, page_number)
            );
        }

        public async static Task<Movie> Fetch(string id)
        {
            return await PerformAction(
                async service => await service.GetById(id)
            );
        }
    }
}
