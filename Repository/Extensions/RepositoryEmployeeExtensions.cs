using Entities.Models;
using Repository.Extensions.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositoryEmployeeExtensions
    {
        public static IQueryable<Employee> FilterEmployees(this IQueryable<Employee>
        employees, uint minAge, uint maxAge) =>
        employees.Where(e => (e.Age >= minAge && e.Age <= maxAge));

        public static IQueryable<Employee> Search(this IQueryable<Employee>
        employees, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return employees;
            string lowerCaseTerm = searchTerm.Trim().ToLower();
            return employees.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Employee> Sort(this IQueryable<Employee> employees, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return employees.OrderBy(e => e.Name);

            string[] orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(Employee).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            IList<IOrderedQueryable<Employee>> queries = new List<IOrderedQueryable<Employee>>();
            bool firstQuery = true;

            foreach (string param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                string propertyFromQueryName = param.Split(' ')[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName,
                    StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                bool descending = param.EndsWith(" desc") ? true : false;

                if (firstQuery)
                {
                    queries.Add(descending ? employees.OrderByDescending(e => e.GetType().GetProperty(objectProperty.Name).GetValue(e, null))
                    : employees.OrderBy(e => e.GetType().GetProperty(objectProperty.Name).GetValue(e, null)));

                    firstQuery = false;
                }
                else
                {
                    queries[queries.Count - 1] = descending ? ((IOrderedQueryable<Employee>)queries[queries.Count - 1]).ThenByDescending(e => e.GetType().GetProperty(objectProperty.Name).GetValue(e, null))
                    : ((IOrderedQueryable<Employee>)queries[queries.Count - 1]).ThenBy(e => e.GetType().GetProperty(objectProperty.Name).GetValue(e, null));
                }
            }

            return queries.Count == 0 ? employees.OrderBy(e => e.Name) : queries[queries.Count - 1];
        }
    }

}
