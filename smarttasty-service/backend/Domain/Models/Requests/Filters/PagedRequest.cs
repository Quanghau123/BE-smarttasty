using System.Collections.Generic;

namespace backend.Domain.Models.Requests.Filters
{
    public class PagedRequest : PaginationFilter
    {
        public string? SortBy { get; set; } = null;
        public string SortDirection { get; set; } = "asc";

        public Dictionary<string, string>? Filters { get; set; } = null;

        public PagedRequest() : base() { }

        public PagedRequest(int pageNumber, int pageSize) : base(pageNumber, pageSize) { }
    }
}
