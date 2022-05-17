using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Repository.Extensions.Utility;

namespace Repository.Extensions
{
    public static class RepositoryCountryExtension
    {
        public static IQueryable<Country> SearchByName(this IQueryable<Country> countries,
                string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return countries;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return countries.Where(e => e.CountryName.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Country> Sort(this IQueryable<Country> countries, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return countries.OrderBy(e => e.CountryName);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Country>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return countries.OrderBy(e => e.CountryName);
            return countries.OrderBy(orderQuery);
        }



    }
}
