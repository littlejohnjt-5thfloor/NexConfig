using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    class CriteriaEvaluator<T> where T: BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ICriteria<T> criteria)
        {
            var query = inputQuery;

            // modify the IQueryable using the specification's criteria expression
            if (criteria.Criterian != null)
            {
                query = query.Where(criteria.Criterian);
            }

            // Includes all expression-based includes
            query = criteria.Includes.Aggregate(query,
                                    (current, include) => current.Include(include));

            // Include any string-based include statements
            query = criteria.IncludeStrings.Aggregate(query,
                                    (current, include) => current.Include(include));

            // Apply ordering if expressions are set
            if (criteria.OrderBy != null)
            {
                query = query.OrderBy(criteria.OrderBy);
            }
            else if (criteria.OrderByDescending != null)
            {
                query = query.OrderByDescending(criteria.OrderByDescending);
            }

            if (criteria.GroupBy != null)
            {
                query = query.GroupBy(criteria.GroupBy).SelectMany(x => x);
            }

            // Apply paging if enabled
            if (criteria.IsPagingEnabled)
            {
                query = query.Skip(criteria.Skip)
                             .Take(criteria.Take);
            }
            return query;
        }
    }
}
