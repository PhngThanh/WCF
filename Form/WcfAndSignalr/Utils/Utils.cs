using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WcfAndSignalr.Utils
{
    public class Utils
    {
        public static T GetFromQueryString<T>() where T : new()
        {
            var obj = new T();
            var properties = typeof(T).GetProperties(); // to get all properties from Class(Object)  
            foreach (var property in properties)
            {
                var valueAsString = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters[property.Name];
                if (string.IsNullOrEmpty(valueAsString) )
                {
                    continue;
                }
                object value = Parse(property.PropertyType, valueAsString); // parse data types  

                if (value == null)
                    continue;

                property.SetValue(obj, value, null); //set values to properties.  
            }
            return obj;
        }
        private static object Parse(Type dataType, string ValueToConvert)
        {
            TypeConverter obj = TypeDescriptor.GetConverter(dataType);
            object value = obj.ConvertFromString(null, CultureInfo.InvariantCulture, ValueToConvert);
            return value;
        }

        /// <summary>
        /// Method này sẽ hốt tất cả parameter của generic T + thêm 2 parameter
        /// là offset và limit từ http request đổ vào trong Dictionary<string, object>
        /// Trong Dictionary<string, object> thì string sẽ là tên parameter, object là value của parameter
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu để get parameter đổ vào dictionary</typeparam>
        /// <returns></returns>
        public static Dictionary<string, object> GetFromQueryString2<T>() where T : new()
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            var properties = typeof(T).GetProperties(); // to get all properties from Class(Object)  
            foreach (var property in properties)
            {
                var valueAsString = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters[property.Name];
                if (string.IsNullOrEmpty(valueAsString))
                {
                    continue;
                }
                object value = Parse(property.PropertyType, valueAsString); // parse data types  

                if (value == null)
                    continue;

                map.Add(property.Name, value);
            }
            var offset = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["offset"];
            if(offset != null)
            {
                map.Add("offset", offset);
            }
            var limit = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["limit"];
            if(limit != null)
            {
                map.Add("limit", limit);
            }
            return map;
        }
    }
}
