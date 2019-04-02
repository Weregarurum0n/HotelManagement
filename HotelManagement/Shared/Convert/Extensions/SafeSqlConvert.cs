using System;
using System.Linq;

namespace HotelManagement.Shared.Convert.Extensions
{
    public static class SafeSqlConvert
    {
        public static int ToSafeInt32(this object value)
        {
            if (value == null)
                return 0;
            int num = 0;
            int.TryParse(value.ToString(), out num);
            return num;
        }
        
        public static double ToSafeDouble(this object value)
        {
            if (value == null)
                return 0;
            double num = 0;
            double.TryParse(value.ToString(), out num);
            return num;
        }

        public static decimal ToSafeDecimal(this object value)
        {
            if (value == null)
                return 0;
            decimal num = 0;
            decimal.TryParse(value.ToString(), out num);
            return num;
        }

        public static float ToSafeFloat(this object value)
        {
            if (value == null)
                return 0;
            float num = 0;
            float.TryParse(value.ToString(), out num);
            return num;
        }

        public static bool ToSafeBool(this object value)
        {
            if (value == null || value is DBNull)
                return false;
            try
            {
                return (bool)(value);
            }
            catch
            {
                return false;
            }

            //bool b;
            //bool.TryParse(value.ToString(), value);
            //return b;
        }
        
        public static long ToSafeLong(this object value)
        {
            if (value == null)
                return 0;
            long num = 0;
            long.TryParse(value.ToString(), out num);
            return num;
        }

        public static DateTime ToSafeDateTime(this object value)
        {
            if (value == null)
                return DateTime.MinValue;
            DateTime date;
            DateTime.TryParse(value.ToString(), out date);
            return date;
        }

        public static DateTime? ToSafeNullableDateTime(this DateTime value)
        {
            return value as DateTime? <= new DateTime(1900, 1, 1) || value as DateTime? >= new DateTime(2999, 12, 31) ? null : (DateTime?)value;
        }

        public static DateTime ToUtcDateTime(this DateTime dateTime)
        {
            var offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);

            return dateTime.Add(offset);
        }

        public static DateTime ToLocalDateTime(this DateTime dateTime)
        {
            var offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);
            return dateTime.Subtract(offset);
        }

        public static DateTime ToPst(this DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"));
        }

        public static DateTime ToCurrentDateTime(this DateTime value)
        {
            if (value <= DateTime.MinValue)
                return DateTime.Now;
            return value;
        }
        
        public static string ToSafeString(this object value)
        {
            if (value == null)
                return "";

            return value.ToString().Trim();
        }

        public static string ToSafeUpperString(this object value)
        {
            if (value == null)
                return "";

            return value.ToString().Trim().ToUpper();
        }

        public static string ToSafeLowerString(this object value)
        {
            if (value == null)
                return "";

            return value.ToString().Trim().ToLower();
        }

        public static string ToSafeNullableString(this object value)
        {
            if (value == DBNull.Value)
                return null;
            return value?.ToString().Trim();
        }

        public static string ToDay(this DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Sunday:
                    return "Sun";
                case DayOfWeek.Monday:
                    return "Mon";
                case DayOfWeek.Tuesday:
                    return "Tue";
                case DayOfWeek.Wednesday:
                    return "Wed";
                case DayOfWeek.Thursday:
                    return "Thu";
                case DayOfWeek.Friday:
                    return "Fri";
                case DayOfWeek.Saturday:
                    return "Sat";
                default:
                    return "";
            }
        }
        
        public static string GetNumbersOnly(this string input)
        {
            return string.IsNullOrEmpty(input) ? "" : new string(input.Where(char.IsDigit).ToArray());
        }
    }
}
