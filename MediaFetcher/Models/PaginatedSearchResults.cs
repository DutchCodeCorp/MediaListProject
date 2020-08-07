namespace MediaFetcher.Models
{
    public class PaginatedSearchResults<T>
    {
        // Filled by the API
        public T[] Search { get; set; }
        public string totalResults { get; set; }

        // Filled by hand
        public int CurrentPage;
        public int ItemsPerPage = 10;

        // Calculated
        public int NumberOfPages() =>
            int.TryParse(totalResults, out int total)
                ? total / ItemsPerPage
                : 1;
    }
}
