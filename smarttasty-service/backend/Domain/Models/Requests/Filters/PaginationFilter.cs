namespace backend.Domain.Models.Requests.Filters
{
    public class PaginationFilter
    {
        private int _pageNumber = 1;
        private int _pageSize = 10;

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = (value < 1) ? 1 : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > 100) ? 100 : (value < 1 ? 10 : value);
        }

        public PaginationFilter() { }

        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
