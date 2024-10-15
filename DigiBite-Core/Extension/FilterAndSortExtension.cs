using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using System.Reflection;

namespace DigiBite_Core.Extension
{
    public static class FilterAndSortExtension
    {
        public static IQueryable<T> ApplyFilterAndSort<T>(this IQueryable<T> query, Dictionary<string, string> filters, string sortBy = null, bool isDescending = false)
        {
            // Apply filtering
            if (!filters.IsNullOrEmpty())
            {
                foreach (var filter in filters)
                {
                    var propertyInfo = typeof(T).GetProperty(filter.Key.Split(':')[0], BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (propertyInfo == null) continue;

                    var operatorType = filter.Key.Contains(":") ? filter.Key.Split(':')[1] : "eq";
                    var parameter = Expression.Parameter(typeof(T), "x");
                    var property = Expression.Property(parameter, propertyInfo);
                    var value = Expression.Constant(Convert.ChangeType(filter.Value, propertyInfo.PropertyType));

                    Expression comparison;
                    switch (operatorType)
                    {
                        case "gt": // Greater than
                            comparison = Expression.GreaterThan(property, value);
                            break;
                        case "lt": // Less than
                            comparison = Expression.LessThan(property, value);
                            break;
                        case "eq": // Equal
                        default:
                            comparison = Expression.Equal(property, value);
                            break;
                    }

                    var lambda = Expression.Lambda<Func<T, bool>>(comparison, parameter);
                    query = query.Where(lambda);
                }
            }
            // Apply sorting if sortBy is provided
            if (!string.IsNullOrEmpty(sortBy))
            {
                var sortProperty = typeof(T).GetProperty(sortBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (sortProperty != null)
                {
                    var parameter = Expression.Parameter(typeof(T), "x");
                    var property = Expression.Property(parameter, sortProperty);
                    var lambda = Expression.Lambda(property, parameter);

                    var methodName = isDescending ? "OrderByDescending" : "OrderBy";
                    var orderByMethod = typeof(Queryable).GetMethods()
                        .First(method => method.Name == methodName && method.GetParameters().Length == 2)
                        .MakeGenericMethod(typeof(T), sortProperty.PropertyType);

                    query = (IQueryable<T>)orderByMethod.Invoke(null, new object[] { query, lambda });
                }
            }

            return query;
        }

    }
}
