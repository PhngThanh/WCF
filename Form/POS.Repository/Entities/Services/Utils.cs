using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Dynamic;
using System.Reflection;
using System.ComponentModel;
using System.IO;
using System.Drawing;

namespace POS.Repository.Entities.Services
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var attribute = (DisplayNameAttribute)value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(false)
                .Where(a => a is DisplayNameAttribute)
                .FirstOrDefault();

            return attribute != null ? attribute.DisplayName : value.ToString();
        }
    }
    public static class Utils
    {
        public static DateTime GetEndOfDate(DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, 23, 59, 59);
        }

        public static DateTime GetStartOfDate(DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);
        }

        public static DateTime UtcDateTimeNow()
        {
            #region Get DateTime.Now
            //Get time UTC 
            DateTime utcNow = DateTime.UtcNow;
            //Parse UTC to time SE Asia
            DateTime datetimeNow = TimeZoneInfo.ConvertTime(utcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
            #endregion

            return datetimeNow;
        }

        /// <summary>
        /// Method này sẽ lọc tất cả các đối tượng trong IQueryable<T>
        /// có các thuộc tính == thuộc tính trong param Dictionary<string, object> dictionary.
        /// </summary>
        public static IQueryable<T> FilterIQueryableByDictionary<T>(IQueryable<T> queryable, Dictionary<string, object> dictionary, string orderBy)
        {
            var properties = typeof(T).GetProperties();
            queryable = queryable.OrderBy(orderBy);
            foreach(var item in dictionary)
            {
                PropertyInfo propertyInfo = properties.FirstOrDefault(p => p.Name == item.Key);
                if(propertyInfo != null)
                {
                    //Sử dụng dynamic linq (using System.Linq.Dynamic;)
                    string whereClause = string.Format("{0} = {1}", propertyInfo.Name, item.Value.ToString());
                    queryable = queryable.Where(whereClause);
                }
            }
            return queryable;
        }

        public class PagingInfo
        {
            public int Offset { get; set; }
            public int? Limit { get; set; }
            public int DefaultLimit { get; set; }
            public int MaximumLimit { get; set; }
        }

        public static IQueryable<T> PagingIQueryable<T>(IQueryable<T> queryable, 
            string orderBy, PagingInfo pagingInfo)
        {
            queryable = queryable.OrderBy(orderBy);
            queryable = queryable.Skip(pagingInfo.Offset);
            if(pagingInfo.Limit == null)
            {
                queryable = queryable.Take(pagingInfo.DefaultLimit);
            } else
            {
                if(pagingInfo.Limit > pagingInfo.MaximumLimit)
                {
                    pagingInfo.Limit = pagingInfo.MaximumLimit;
                }
                queryable = queryable.Take((int)pagingInfo.Limit);
            }
            return queryable;
        }
        public static System.Drawing.Bitmap GetImage(string imageName)
        {
            string imagePath = Path.Combine(Environment.CurrentDirectory, @"Resources\", imageName);
            try
            {
                Bitmap bitmap = new Bitmap(imagePath);
                return bitmap;
            }
            catch (Exception)
            {
                string imagePathDefault = Path.Combine(Environment.CurrentDirectory, @"Resources\", "logo-skypos.png");
                Bitmap bitmap = new Bitmap(imagePathDefault);
                return bitmap;
            }
        }
        public static IQueryable<T> PagingIQueryable<T>(IQueryable<T> queryable, 
            Dictionary<string, object> dictionary, string orderBy)
        {
            PagingInfo pagingInfo = new PagingInfo
            {
                DefaultLimit = Constants.DEFAULT_LIMIT_PAGING,
                MaximumLimit = Constants.MAX_LIMIT_PAGING,
            };
            if (dictionary.ContainsKey("offset"))
            {
                pagingInfo.Offset = int.Parse(dictionary["offset"].ToString());
            }
            if (dictionary.ContainsKey("limit"))
            {
                pagingInfo.Limit = int.Parse(dictionary["limit"].ToString());
            }

            return PagingIQueryable(queryable, orderBy, pagingInfo);
        }

    }
}
