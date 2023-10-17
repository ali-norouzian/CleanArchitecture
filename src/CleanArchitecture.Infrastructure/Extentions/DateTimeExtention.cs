using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extention
{
    public static class DateTimeExtention
    {
        public static string ToShamsi(this DateTime dateTime)
        {
            var persianCalender = new PersianCalendar();

            var year = $"{persianCalender.GetYear(dateTime):0000}";
            var month = $"{persianCalender.GetMonth(dateTime):00}";
            var day = $"{persianCalender.GetDayOfMonth(dateTime):00}";
            var hour = $"{persianCalender.GetHour(dateTime):00}";
            var minute = $"{persianCalender.GetMinute(dateTime):00}";

            var result = $"{year}-{month}-{day} {hour}:{minute}";
            return result;

        }

        public static string GetPersianDayOfWeek(this DateTime dateTime)
        {
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return "شنبه";
                case DayOfWeek.Sunday:
                    return "یک شنبه";
                case DayOfWeek.Monday:
                    return "دو شنبه";
                case DayOfWeek.Tuesday:
                    return "سه شنبه";
                case DayOfWeek.Wednesday:
                    return "چهار شنبه";
                case DayOfWeek.Thursday:
                    return "پنج شنبه";
                case DayOfWeek.Friday:
                    return "جمعه";
                default:
                    throw new Exception();
            }
        }
    }
}
