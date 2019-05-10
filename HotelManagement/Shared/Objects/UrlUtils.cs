using System;
using System.Collections;
using System.Linq;

namespace HotelManagement.Shared.Objects
{
    public static class UrlUtils
    {
        public static string ToQueryString(this object request, string separator = ",")
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var properties = request.GetType().GetProperties()
                .Where(x => !Attribute.IsDefined(x, typeof(QueryStringIgnoreAttribute)))
                .Where(x => x.CanRead)
                .Where(x => x.GetValue(request, null) != null)
                .ToDictionary(x => x.Name, x => x.GetValue(request, null));

            var propertyNames = properties
                .Where(x => !(x.Value is string) && x.Value is IEnumerable)
                .Select(x => x.Key)
                .ToList();

            foreach (var key in propertyNames)
            {
                var valueType = properties[key].GetType();
                var valueElemType = valueType.IsGenericType
                    ? valueType.GetGenericArguments()[0]
                    : valueType.GetElementType();
                if (valueElemType.IsPrimitive || valueElemType == typeof(string))
                {
                    var enumerable = properties[key] as IEnumerable;
                    properties[key] = string.Join(separator, enumerable.Cast<object>());
                }
            }

            return string.Join("&", properties
                .Select(x => string.Concat(
                    Uri.EscapeDataString(x.Key), "=",
                    Uri.EscapeDataString(GetValue(x.Value)))));
        }

        private static string GetValue(object item)
        {
            if (item is DateTime dt)
            {
                return dt.ToString("MM/dd/yyyy HH:m:s");
            }

            return item.ToString();
        }
    }

    public class QueryStringIgnoreAttribute : Attribute
    {

    }
}
