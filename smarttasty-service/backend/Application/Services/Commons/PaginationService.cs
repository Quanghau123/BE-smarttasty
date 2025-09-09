using backend.Application.DTOs.Commons;
using backend.Application.Interfaces.Commons;
using backend.Domain.Models.Requests.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace backend.Application.Services.Commons
{
    public class PaginationService : IPaginationService
    {
        public async Task<PagedDto<T>> GetPagedResultAsync<T>(
            IQueryable<T> query,
            PagedRequest filter
        )
        {
            if (filter.Filters != null)
            {
                foreach (var f in filter.Filters)
                {
                    var param = Expression.Parameter(typeof(T), "x");
                    var property = Expression.Property(param, f.Key);

                    object? convertedValue;
                    try
                    {
                        if (property.Type.IsEnum)
                        {
                            convertedValue = Enum.Parse(property.Type, f.Value.ToString(), ignoreCase: true);
                        }
                        else
                        {
                            convertedValue = Convert.ChangeType(f.Value, property.Type);
                        }
                    }
                    catch
                    {
                        continue;
                    }

                    var constant = Expression.Constant(convertedValue);
                    var equal = Expression.Equal(property, constant);
                    var lambda = Expression.Lambda<Func<T, bool>>(equal, param);
                    query = query.Where(lambda);
                }
            }

            if (!string.IsNullOrEmpty(filter.SortBy))
            {
                query = ApplyOrdering(query, filter.SortBy, filter.SortDirection?.ToLower() == "desc");
            }

            var totalRecords = await query.CountAsync();

            var pageNumber = filter.PageNumber < 1 ? 1 : filter.PageNumber;
            var pageSize = filter.PageSize < 1 ? 10 : (filter.PageSize > 100 ? 100 : filter.PageSize);

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedDto<T>(data, totalRecords, pageNumber, pageSize);
        }

        private IQueryable<T> ApplyOrdering<T>(IQueryable<T> source, string propertyName, bool desc)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(param, propertyName);
            var lambda = Expression.Lambda(property, param);

            string methodName = desc ? "OrderByDescending" : "OrderBy";

            var types = new Type[] { source.ElementType, property.Type };

            var mce = Expression.Call(typeof(Queryable), methodName, types, source.Expression, Expression.Quote(lambda));

            return source.Provider.CreateQuery<T>(mce);
        }
    }
}
