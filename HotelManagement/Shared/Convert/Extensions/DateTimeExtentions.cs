using System;

namespace HotelManagement.Shared.Convert
{
    public static class DateTimeExtentions
    {
        public static DateTime ChangeTime(this DateTime dateTime, int hours, int minutes, int seconds)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                dateTime.Kind);
        }

        public static DateTime ChangeTimeToEndOfDay(this DateTime dateTime)
        {
            return dateTime.AddDays(1).AddSeconds(-1);
        }
    }
}
