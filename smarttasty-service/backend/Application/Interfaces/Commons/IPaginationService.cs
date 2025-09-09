using System.Linq;
using System.Threading.Tasks;
using backend.Application.DTOs.Commons;
using backend.Domain.Models.Requests.Filters;

namespace backend.Application.Interfaces.Commons
{
    public interface IPaginationService
    {
        Task<PagedDto<T>> GetPagedResultAsync<T>(
            IQueryable<T> query,
            PagedRequest filter
        );
    }
}
